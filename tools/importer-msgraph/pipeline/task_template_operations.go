package pipeline

import (
	"fmt"
	"strconv"
	"strings"

	"github.com/hashicorp/go-hclog"
)

func (pipelineTask) templateOperationsForService(files *Tree, serviceName string, resources []*Resource, logger hclog.Logger) error {
	operations := make(map[string]string)

	// First build all the methods
	for _, resource := range resources {
		// Skip functions and casts for now
		if lastSegment := resource.ID.Segments[len(resource.ID.Segments)-1]; lastSegment.Type == SegmentCast || lastSegment.Type == SegmentFunction || lastSegment.Type == SegmentODataFunction {
			logger.Debug("Skipping suspected function/cast resource", "resource", resource.ID.ID())
			continue
		}

		for _, operation := range resource.Operations {
			// Skip unknown operations
			if operation.Type == OperationTypeUnknown {
				logger.Debug("Skipping unknown operation", "resource", resource.ID.ID(), "method", operation.Method)
				continue
			}

			// Build string arguments from user-specified URI segments
			args := make([]string, 0)
			argNames := make([]string, 0)
			for _, segment := range resource.ID.Segments {
				if segment.Type == SegmentUserValue {
					argName := cleanNameCamel(segment.Value)
					argNames = append(argNames, argName)
					args = append(args, fmt.Sprintf("%s string", argName))
				}
			}

			// Determine request model
			var requestModel, requestModelVar string
			if operation.Type == OperationTypeCreate || operation.Type == OperationTypeUpdate || operation.Type == OperationTypeCreateUpdate {
				if operation.RequestModel != nil {
					requestModelVar = cleanNameCamel(*operation.RequestModel)
					requestModel = *operation.RequestModel
					args = append(args, fmt.Sprintf("%s models.%s", requestModelVar, *operation.RequestModel))
				} else if lastSegment := resource.ID.Segments[len(resource.ID.Segments)-1]; lastSegment.Value == "$ref" {
					requestModel = "DirectoryObject"
					requestModelVar = "directoryObject"
					args = append(args, fmt.Sprintf("%s models.%s", requestModelVar, requestModel))
				}
			}

			// Determine response model and return values
			var responseModel string
			if operation.Type != OperationTypeDelete {
				responseModel = findModel(operation.Responses)
				if responseModel == "" {
					if lastSegment := resource.ID.Segments[len(resource.ID.Segments)-1]; lastSegment.Value == "$ref" {
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
					logger.Debug("Skipping operation with empty response model", "resource", resource.ID.ID(), "method", operation.Method)
					continue
				}
				methodCode = templateListMethod(resource, &operation, responseModel, args)
			case OperationTypeRead:
				if responseModel == "" {
					logger.Debug("Skipping operation with empty response model", "resource", resource.ID.ID(), "method", operation.Method)
					continue
				}
				methodCode = templateReadMethod(resource, &operation, responseModel, statuses)
			case OperationTypeCreate, OperationTypeUpdate, OperationTypeCreateUpdate:
				if requestModelVar == "" {
					logger.Debug("Skipping operation with empty request model var", "resource", resource.ID.ID(), "method", operation.Method)
					continue
				}
				methodCode = templateCreateUpdateMethod(resource, &operation, requestModel, responseModel, statuses)
			case OperationTypeDelete:
				methodCode = templateDeleteMethod(resource, &operation, statuses)
			}

			// Build it
			clientMethodFile := fmt.Sprintf("%s/%s/%s/Operation-%s.cs", resource.Service, cleanVersion(resource.Version), pluralize(resource.Name), operation.Name)
			operations[clientMethodFile] = methodCode
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

func templateListMethod(resource *Resource, operation *Operation, responseModel string, args []string) string {
	return fmt.Sprintf(`using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Models;
using System;

// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

namespace Pandora.Definitions.MicrosoftGraph.%[1]s.%[2]s.%[3]s;

internal class %[4]sOperation : Operations.%[5]sOperation
{
   public override string? FieldContainingPaginationDetails() => "nextLink";

   public override ResourceID? ResourceId() => null;

   public override Type NestedItemType() => typeof(%[6]sModel);

   public override string? UriSuffix() => "%[7]s";


}
`, resource.Service, cleanVersion(resource.Version), pluralize(resource.Name), operation.Name, strings.Title(strings.ToLower(operation.Method)), responseModel, resource.ID.ID()) // TODO: resource ID to be calculated

}

func templateReadMethod(resource *Resource, operation *Operation, responseModel string, statuses []string) string {
	statusEnums := make([]string, len(statuses))
	for i, status := range statuses {
		code, _ := strconv.Atoi(status)
		statusEnums[i] = csHttpStatusCode(code)
	}
	expectedStatusesCode := indentSpace(strings.Join(statusEnums, ",\n"), 16)
	resourceIdName := fmt.Sprintf("%sId", resource.Name)

	return fmt.Sprintf(`using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Models;
using System.Collections.Generic;
using System.Net;
using System;

// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

namespace Pandora.Definitions.MicrosoftGraph.%[1]s.%[2]s.%[3]s;

internal class %[4]sOperation : Operations.%[5]sOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
%[6]s,
        };

    public override ResourceID? ResourceId() => new %[7]s();

    public override Type? ResponseObject() => typeof(%[8]sModel);


}
`, resource.Service, cleanVersion(resource.Version), pluralize(resource.Name), operation.Name, strings.Title(strings.ToLower(operation.Method)), expectedStatusesCode, resourceIdName, responseModel)
}

func templateCreateUpdateMethod(resource *Resource, operation *Operation, requestModel, responseModel string, statuses []string) string {
	statusEnums := make([]string, len(statuses))
	for i, status := range statuses {
		code, _ := strconv.Atoi(status)
		statusEnums[i] = csHttpStatusCode(code)
	}
	expectedStatusesCode := indentSpace(strings.Join(statusEnums, ",\n"), 16)
	resourceIdName := fmt.Sprintf("%sId", resource.Name)

	//var path string
	//if len(args) > 0 {
	//	path = fmt.Sprintf(`fmt.Sprintf("%s", %s)`, endpoint.Id.IDf(), strings.Join(args, ", "))
	//} else {
	//	path = fmt.Sprintf("%q", endpoint.Id.ID())
	//}

	return fmt.Sprintf(`using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Models;
using System.Collections.Generic;
using System.Net;
using System;

// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

namespace Pandora.Definitions.MicrosoftGraph.%[1]s.%[2]s.%[3]s;

internal class %[4]sOperation : Operations.%[5]sOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
%[6]s,
        };

    public override Type? RequestObject() => typeof(%[7]sModel);

    public override ResourceID? ResourceId() => new %[8]s();

    public override Type? ResponseObject() => typeof(%[9]sModel);


}
`, resource.Service, cleanVersion(resource.Version), pluralize(resource.Name), operation.Name, strings.Title(strings.ToLower(operation.Method)), expectedStatusesCode, requestModel, resourceIdName, responseModel)
}

func templateDeleteMethod(resource *Resource, operation *Operation, statuses []string) string {
	statusEnums := make([]string, len(statuses))
	for i, status := range statuses {
		code, _ := strconv.Atoi(status)
		statusEnums[i] = csHttpStatusCode(code)
	}
	expectedStatusesCode := indentSpace(strings.Join(statusEnums, ",\n"), 16)
	resourceIdName := fmt.Sprintf("%sId", resource.Name)

	//var path string
	//if len(args) > 0 {
	//	path = fmt.Sprintf(`fmt.Sprintf("%s", %s)`, endpoint.Id.IDf(), strings.Join(args, ", "))
	//} else {
	//	path = fmt.Sprintf("%q", endpoint.Id.ID())
	//}

	return fmt.Sprintf(`using Pandora.Definitions.Interfaces;
using System.Collections.Generic;
using System.Net;

// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

namespace Pandora.Definitions.MicrosoftGraph.%[1]s.%[2]s.%[3]s;

internal class %[4]sOperation : Operations.%[5]sOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
%[6]s,
        };

    public override ResourceID? ResourceId() => new %[7]s();


}
`, resource.Service, cleanVersion(resource.Version), pluralize(resource.Name), operation.Name, strings.Title(strings.ToLower(operation.Method)), expectedStatusesCode, resourceIdName)
}
