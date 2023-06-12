package pipeline

import (
	"fmt"
	"os"
	"strconv"
	"strings"

	"github.com/hashicorp/go-hclog"
)

func (pipelineTask) templateOperationsForService(files *Tree, resources Resources, logger hclog.Logger) error {
	operations := make(map[string]string)

	// First build all the methods
	for _, resource := range resources {
		if resource.Category == "" {
			continue // TODO do something about orphaned resources
		}

		for _, operation := range resource.Operations {
			// Skip unknown operations
			if operation.Type == OperationTypeUnknown {
				logger.Debug("Skipping unknown operation", "resource", operation.ResourceId.ID(), "method", operation.Method)
				logger.Debug(fmt.Sprintf("Skipping unknown operation for ID %q (category %q, service %q, version %q)", operation.ResourceId.ID(), resource.Category, resource.Service, resource.Version))
				continue
			}

			// Skip functions and casts for now
			if operation.ResourceId != nil && len(operation.ResourceId.Segments) > 0 {
				if lastSegment := operation.ResourceId.Segments[len(operation.ResourceId.Segments)-1]; lastSegment.Type == SegmentCast || lastSegment.Type == SegmentFunction || lastSegment.Type == SegmentODataReference {
					logger.Debug(fmt.Sprintf("Skipping suspected cast/function/reference resource for ID %q (category %q, service %q, version %q)", operation.ResourceId.ID(), resource.Category, resource.Service, resource.Version))
					continue
				}
			}

			// Determine request model
			var requestModel string
			if operation.RequestModel != nil {
				requestModel = *operation.RequestModel
			}

			// Determine response model and return values
			var responseModel string
			if operation.Type != OperationTypeDelete {
				responseModel = findModel(operation.Responses)
				if responseModel == "" {
					if operation.ResourceId != nil && len(operation.ResourceId.Segments) > 0 && operation.ResourceId.Segments[len(operation.ResourceId.Segments)-1].Value == "$ref" {
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
					if operation.ResourceId != nil {
						id = operation.ResourceId.ID()
					}
					logger.Debug(fmt.Sprintf("Skipping operation with empty response model for method %q (ID %q, category %q, service %q, version %q)", operation.Method, id, resource.Category, resource.Service, resource.Version))
					continue
				}
				methodCode = templateListOperation(resource, &operation, responseModel)
			case OperationTypeRead:
				if responseModel == "" {
					id := "{unknown-id}"
					if operation.ResourceId != nil {
						id = operation.ResourceId.ID()
					}
					logger.Debug(fmt.Sprintf("Skipping operation with empty response model for method %q (ID %q, category %q, service %q, version %q)", operation.Method, id, resource.Category, resource.Service, resource.Version))
					continue
				}
				methodCode = templateReadOperation(resource, &operation, responseModel, statuses)
			case OperationTypeCreate, OperationTypeUpdate, OperationTypeCreateUpdate:
				methodCode = templateCreateUpdateOperation(resource, &operation, requestModel, responseModel, statuses)
			case OperationTypeDelete:
				methodCode = templateDeleteOperation(resource, &operation, statuses)
			}

			// Build it
			filename := fmt.Sprintf("Pandora.Definitions.%[2]s%[1]s%[3]s%[1]s%[4]s%[1]s%[5]s%[1]sOperation-%[6]s.cs", string(os.PathSeparator), definitionsDirectory(resource.Version), resource.Service, cleanVersion(resource.Version), resource.Category, operation.Name)
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

func templateListOperation(resource *Resource, operation *Operation, responseModel string) string {
	resourceIdCode := "null"
	if operation.ResourceId != nil {
		resourceIdCode = fmt.Sprintf(`new %sId()`, operation.ResourceId.Name)
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

namespace Pandora.Definitions.%[2]s.%[1]s.%[3]s.%[4]s;

internal class %[5]sOperation : Operations.ListOperation
{
   public override string? FieldContainingPaginationDetails() => "nextLink";
   public override ResourceID? ResourceId() => %[6]s;
   public override Type NestedItemType() => typeof(%[7]sModel);
   public override string? UriSuffix() => %[8]s;
}
`, resource.Service, definitionsDirectory(resource.Version), cleanVersion(resource.Version), resource.Category, operation.Name, resourceIdCode, responseModel, uriSuffixCode)

}

func templateReadOperation(resource *Resource, operation *Operation, responseModel string, statuses []string) string {
	statusEnums := make([]string, len(statuses))
	for i, status := range statuses {
		code, _ := strconv.Atoi(status)
		statusEnums[i] = csHttpStatusCode(code)
	}
	expectedStatusesCode := indentSpace(strings.Join(statusEnums, ",\n"), 16)
	resourceIdCode := "null"
	if operation.ResourceId != nil {
		resourceIdCode = fmt.Sprintf(`new %sId()`, operation.ResourceId.Name)
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

namespace Pandora.Definitions.%[2]s.%[1]s.%[3]s.%[4]s;

internal class %[5]sOperation : Operations.%[6]sOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
%[7]s,
        };
    public override ResourceID? ResourceId() => %[8]s;
    public override Type? ResponseObject() => typeof(%[9]sModel);
    public override string? UriSuffix() => %[10]s;
}
`, resource.Service, definitionsDirectory(resource.Version), cleanVersion(resource.Version), resource.Category, operation.Name, strings.Title(strings.ToLower(operation.Method)), expectedStatusesCode, resourceIdCode, responseModel, uriSuffixCode)
}

func templateCreateUpdateOperation(resource *Resource, operation *Operation, requestModel, responseModel string, statuses []string) string {
	statusEnums := make([]string, len(statuses))
	for i, status := range statuses {
		code, _ := strconv.Atoi(status)
		statusEnums[i] = csHttpStatusCode(code)
	}
	expectedStatusesCode := indentSpace(strings.Join(statusEnums, ",\n"), 16)
	resourceIdCode := "null"
	if operation.ResourceId != nil {
		resourceIdCode = fmt.Sprintf(`new %sId()`, operation.ResourceId.Name)
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

namespace Pandora.Definitions.%[2]s.%[1]s.%[3]s.%[4]s;

internal class %[5]sOperation : Operations.%[6]sOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
%[7]s,
        };
    public override Type? RequestObject() => %[8]s;
    public override ResourceID? ResourceId() => %[9]s;
    public override Type? ResponseObject() => %[10]s;
    public override string? UriSuffix() => %[11]s;
}
`, resource.Service, definitionsDirectory(resource.Version), cleanVersion(resource.Version), resource.Category, operation.Name, strings.Title(strings.ToLower(operation.Method)), expectedStatusesCode, requestObjectCode, resourceIdCode, responseObjectCode, uriSuffixCode)
}

func templateDeleteOperation(resource *Resource, operation *Operation, statuses []string) string {
	statusEnums := make([]string, len(statuses))
	for i, status := range statuses {
		code, _ := strconv.Atoi(status)
		statusEnums[i] = csHttpStatusCode(code)
	}
	expectedStatusesCode := indentSpace(strings.Join(statusEnums, ",\n"), 16)
	resourceIdCode := "null"
	if operation.ResourceId != nil {
		resourceIdCode = fmt.Sprintf(`new %sId()`, operation.ResourceId.Name)
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

namespace Pandora.Definitions.%[2]s.%[1]s.%[3]s.%[4]s;

internal class %[5]sOperation : Operations.%[6]sOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
%[7]s,
        };
    public override ResourceID? ResourceId() => %[8]s;
    public override string? UriSuffix() => %[9]s;
}
`, resource.Service, definitionsDirectory(resource.Version), cleanVersion(resource.Version), resource.Category, operation.Name, strings.Title(strings.ToLower(operation.Method)), expectedStatusesCode, resourceIdCode, uriSuffixCode)
}
