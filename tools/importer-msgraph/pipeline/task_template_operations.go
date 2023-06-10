package pipeline

import (
	"fmt"
	"os"
	"strconv"
	"strings"

	"github.com/hashicorp/go-hclog"
)

func (pipelineTask) templateOperationsForService(files *Tree, serviceName string, resources map[string]*Resource, logger hclog.Logger) error {
	operations := make(map[string]string)

	// First build all the methods
	for _, resource := range resources {
		for _, operation := range resource.Operations {
			// Skip unknown operations
			if operation.Type == OperationTypeUnknown {
				logger.Debug("Skipping unknown operation", "resource", resource.Id.ID(), "method", operation.Method)
				continue
			}

			// Skip functions and casts for now
			if resource.Id != nil && len(resource.Id.Segments) > 0 {
				if lastSegment := resource.Id.Segments[len(resource.Id.Segments)-1]; lastSegment.Type == SegmentCast || lastSegment.Type == SegmentFunction || lastSegment.Type == SegmentODataReference {
					logger.Debug(fmt.Sprintf("Skipping suspected cast/function/reference resource for ID %q", resource.Id.ID()))
					continue
				}
			}

			// Determine request model
			var requestModel string
			if operation.Type == OperationTypeCreate || operation.Type == OperationTypeUpdate || operation.Type == OperationTypeCreateUpdate {
				if operation.RequestModel != nil {
					requestModel = *operation.RequestModel
				} else if resource.Id != nil && len(resource.Id.Segments) > 0 && resource.Id.Segments[len(resource.Id.Segments)-1].Value == "$ref" {
					requestModel = "DirectoryObject"
				}
			}

			// Determine response model and return values
			var responseModel string
			if operation.Type != OperationTypeDelete {
				responseModel = findModel(operation.Responses)
				if responseModel == "" {
					if resource.Id != nil && len(resource.Id.Segments) > 0 && resource.Id.Segments[len(resource.Id.Segments)-1].Value == "$ref" {
						responseModel = "DirectoryObject"
					}
				}
			}

			statuses := make([]string, 0)
			for _, response := range operation.Responses {
				if response.Status >= 200 && response.Status < 400 {
					statuses = append(statuses, strconv.Itoa(response.Status))
				}
			}

			// Template the operationFile code
			var methodCode string
			switch operation.Type {
			case OperationTypeList:
				if responseModel == "" {
					id := "{unknown-id}"
					if resource.Id != nil {
						id = resource.Id.ID()
					}
					logger.Debug(fmt.Sprintf("Skipping operation with empty response model for ID %q, Method %q", id, operation.Method))
					continue
				}
				methodCode = templateListMethod(resource, &operation, responseModel)
			case OperationTypeRead:
				if responseModel == "" {
					id := "{unknown-id}"
					if resource.Id != nil {
						id = resource.Id.ID()
					}
					logger.Debug(fmt.Sprintf("Skipping operation with empty response model for ID %q, Method %q", id, operation.Method))
					continue
				}
				methodCode = templateReadMethod(resource, &operation, responseModel, statuses)
			case OperationTypeCreate, OperationTypeUpdate, OperationTypeCreateUpdate:
				methodCode = templateCreateUpdateMethod(resource, &operation, requestModel, responseModel, statuses)
			case OperationTypeDelete:
				methodCode = templateDeleteMethod(resource, &operation, statuses)
			}

			// Build it
			filename := fmt.Sprintf("Pandora.Definitions.%[2]s%[1]s%[3]s%[1]s%[4]s%[1]s%[5]s%[1]sOperation-%[6]s.cs", string(os.PathSeparator), versionDirectory(resource.Version), resource.Service, cleanName(resource.Version), resource.Category, operation.Name)
			operations[filename] = methodCode
		}
	}

	// Then output them as separate source files
	operationFiles := sortedKeys(operations)
	for _, operationFile := range operationFiles {
		if err := files.addFile(operationFile, operations[operationFile]); err != nil {
			return err
		}
	}

	return nil
}

func templateListMethod(resource *Resource, operation *Operation, responseModel string) string {
	resourceIdCode := "null"
	if resource.Id != nil {
		resourceIdCode = fmt.Sprintf(`new %sId()`, resource.Id.Name)
	}
	uriSuffixCode := "null"
	if operation.UriSuffix != nil {
		uriSuffixCode = fmt.Sprintf(`"%s"`, *operation.UriSuffix)
	}

	return fmt.Sprintf(`using Pandora.Definitions.Interfaces;
using Pandora.Definitions.%[2]s.Models;
using System;

// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

namespace Pandora.Definitions.%[2]s.%[1]s.%[3]s;

internal class %[4]sOperation : Operations.ListOperation
{
   public override string? FieldContainingPaginationDetails() => "nextLink";
   public override ResourceID? ResourceId() => %[5]s;
   public override Type NestedItemType() => typeof(%[6]sModel);
   public override string? UriSuffix() => %[7]s;
}
`, resource.Service, versionDirectory(resource.Version), cleanName(resource.Version), operation.Name, resourceIdCode, responseModel, uriSuffixCode)

}

func templateReadMethod(resource *Resource, operation *Operation, responseModel string, statuses []string) string {
	statusEnums := make([]string, len(statuses))
	for i, status := range statuses {
		code, _ := strconv.Atoi(status)
		statusEnums[i] = csHttpStatusCode(code)
	}
	expectedStatusesCode := indentSpace(strings.Join(statusEnums, ",\n"), 16)
	resourceIdCode := "null"
	if resource.Id != nil {
		resourceIdCode = fmt.Sprintf(`new %sId()`, resource.Id.Name)
	}
	uriSuffixCode := "null"
	if operation.UriSuffix != nil {
		uriSuffixCode = fmt.Sprintf(`"%s"`, *operation.UriSuffix)
	}

	return fmt.Sprintf(`using Pandora.Definitions.Interfaces;
using Pandora.Definitions.%[2]s.Models;
using System.Collections.Generic;
using System.Net;
using System;

// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

namespace Pandora.Definitions.%[2]s.%[1]s.%[3]s;

internal class %[4]sOperation : Operations.%[5]sOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
%[6]s,
        };
    public override ResourceID? ResourceId() => %[7]s;
    public override Type? ResponseObject() => typeof(%[8]sModel);
    public override string? UriSuffix() => %[9]s;
}
`, resource.Service, versionDirectory(resource.Version), cleanName(resource.Version), operation.Name, strings.Title(strings.ToLower(operation.Method)), expectedStatusesCode, resourceIdCode, responseModel, uriSuffixCode)
}

func templateCreateUpdateMethod(resource *Resource, operation *Operation, requestModel, responseModel string, statuses []string) string {
	statusEnums := make([]string, len(statuses))
	for i, status := range statuses {
		code, _ := strconv.Atoi(status)
		statusEnums[i] = csHttpStatusCode(code)
	}
	expectedStatusesCode := indentSpace(strings.Join(statusEnums, ",\n"), 16)
	resourceIdCode := "null"
	if resource.Id != nil {
		resourceIdCode = fmt.Sprintf(`new %sId()`, resource.Id.Name)
	}
	uriSuffixCode := "null"
	if operation.UriSuffix != nil {
		uriSuffixCode = fmt.Sprintf(`"%s"`, *operation.UriSuffix)
	}
	requestObjectCode := "null"
	if requestModel != "" {
		requestObjectCode = fmt.Sprintf("typeof(%sModel)", requestModel)
	}
	responseObjectCode := "null"
	if responseModel != "" {
		responseObjectCode = fmt.Sprintf("typeof(%sModel)", responseModel)
	}

	return fmt.Sprintf(`using Pandora.Definitions.Interfaces;
using Pandora.Definitions.%[2]s.Models;
using System.Collections.Generic;
using System.Net;
using System;

// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

namespace Pandora.Definitions.%[2]s.%[1]s.%[3]s;

internal class %[4]sOperation : Operations.%[5]sOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
%[6]s,
        };
    public override Type? RequestObject() => %[7]s;
    public override ResourceID? ResourceId() => %[8]s;
    public override Type? ResponseObject() => %[9]s;
    public override string? UriSuffix() => %[10]s;
}
`, resource.Service, versionDirectory(resource.Version), cleanName(resource.Version), operation.Name, strings.Title(strings.ToLower(operation.Method)), expectedStatusesCode, requestObjectCode, resourceIdCode, responseObjectCode, uriSuffixCode)
}

func templateDeleteMethod(resource *Resource, operation *Operation, statuses []string) string {
	statusEnums := make([]string, len(statuses))
	for i, status := range statuses {
		code, _ := strconv.Atoi(status)
		statusEnums[i] = csHttpStatusCode(code)
	}
	expectedStatusesCode := indentSpace(strings.Join(statusEnums, ",\n"), 16)
	resourceIdCode := "null"
	if resource.Id != nil {
		resourceIdCode = fmt.Sprintf(`new %sId()`, resource.Id.Name)
	}
	uriSuffixCode := "null"
	if operation.UriSuffix != nil {
		uriSuffixCode = fmt.Sprintf(`"%s"`, *operation.UriSuffix)
	}

	return fmt.Sprintf(`using Pandora.Definitions.Interfaces;
using System.Collections.Generic;
using System.Net;

// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

namespace Pandora.Definitions.%[2]s.%[1]s.%[3]s;

internal class %[4]sOperation : Operations.%[5]sOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
%[6]s,
        };
    public override ResourceID? ResourceId() => %[7]s;
    public override string? UriSuffix() => %[8]s;
}
`, resource.Service, versionDirectory(resource.Version), cleanName(resource.Version), operation.Name, strings.Title(strings.ToLower(operation.Method)), expectedStatusesCode, resourceIdCode, uriSuffixCode)
}
