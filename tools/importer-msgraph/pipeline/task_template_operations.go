package pipeline

import (
	"fmt"
	"strconv"
	"strings"

	"github.com/hashicorp/go-hclog"
)

func (pipelineTask) templateOperations(files *Tree, packageName string, resources []*Resource, logger hclog.Logger) error {
	operations := make(map[string]string)

	// First build all the methods
	for _, resource := range resources {
		// Skip functions and casts for now
		if lastSegment := resource.Id.segments[len(resource.Id.segments)-1]; lastSegment.Type == SegmentCast || lastSegment.Type == SegmentFunction {
			logger.Debug("Skipping suspected function/cast resource", "resource", resource.Id.ID())
			continue
		}

		for _, operation := range resource.Operations {
			// Skip unknown operations
			if operation.Type == OperationTypeUnknown {
				logger.Debug("Skipping unknown operation", "resource", resource.Id.ID(), "method", operation.Method)
				continue
			}

			// Build string arguments from user-specified URI segments
			args := make([]string, 0)
			argNames := make([]string, 0)
			for _, segment := range resource.Id.segments {
				if segment.Type == SegmentUserValue {
					argName := cleanNameCamel(segment.Value)
					argNames = append(argNames, argName)
					args = append(args, fmt.Sprintf("%s string", argName))
				}
			}

			operationType := operation.Type.Name(resource.Id)

			// Name the operationFile according to the final URI segment, or deriving it from the tag
			var clientMethodNameTarget string
			if lastLabel := resource.Id.LastLabel(); lastLabel != nil {
				if operation.Type == OperationTypeList {
					clientMethodNameTarget = pluralize(cleanName(lastLabel.Value))
				} else {
					clientMethodNameTarget = singularize(cleanName(lastLabel.Value))
				}
			}

			if clientMethodNameTarget == "" {
				if len(operation.Tags) > 1 {
					return fmt.Errorf("found %d tags for operation %s/%s: %s", len(operation.Tags), resource.Id.ID(), operationType, operation.Tags)
				} else if len(operation.Tags) == 1 {
					t := strings.Split(operation.Tags[0], ".")
					if len(t) != 2 {
						return fmt.Errorf("invalid tag for operation %s/%s: %s", resource.Id.ID(), operationType, operation.Tags[0])
					}
					clientMethodNameTarget = cleanName(t[1])
				}
			}

			// TODO: this shouldn't happen, but probably log/handle this
			if clientMethodNameTarget == "" {
				logger.Debug("Skipping operation with empty method name", "resource", resource.Id.ID(), "method", operation.Method)
				continue
			}

			// Pluralize for list operations
			if operation.Type == OperationTypeList {
				clientMethodNameTarget = pluralize(clientMethodNameTarget)
			}

			// Determine request model
			var requestModelVar string
			if operation.Type == OperationTypeCreate || operation.Type == OperationTypeUpdate || operation.Type == OperationTypeCreateUpdate {
				if operation.RequestModel != nil {
					requestModelVar = cleanNameCamel(*operation.RequestModel)
					args = append(args, fmt.Sprintf("%s models.%s", requestModelVar, *operation.RequestModel))
				} else if lastSegment := resource.Id.segments[len(resource.Id.segments)-1]; lastSegment.Value == "$ref" {
					requestModelVar = "directoryObject"
					args = append(args, fmt.Sprintf("%s models.DirectoryObject", requestModelVar))
				}
			}

			// Determine response model and return values
			var responseModel string
			if operation.Type != OperationTypeDelete {
				responseModel = findModel(operation.Responses)
				if responseModel == "" {
					if lastSegment := resource.Id.segments[len(resource.Id.segments)-1]; lastSegment.Value == "$ref" {
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
					logger.Debug("Skipping operation with empty response model", "resource", resource.Id.ID(), "method", operation.Method)
					continue
				}
				methodCode = templateListMethod(resource, &operation, operationType, responseModel, args)
			case OperationTypeRead:
				if responseModel == "" {
					logger.Debug("Skipping operation with empty response model", "resource", resource.Id.ID(), "method", operation.Method)
					continue
				}
				methodCode = templateReadMethod(resource, &operation, operationType, responseModel, statuses)
			case OperationTypeCreate, OperationTypeUpdate, OperationTypeCreateUpdate:
				if requestModelVar == "" {
					logger.Debug("Skipping operation with empty request model var", "resource", resource.Id.ID(), "method", operation.Method)
					continue
				}
				methodCode = templateCreateUpdateMethod(resource, &operation, operationType, requestModelVar, responseModel, statuses)
			case OperationTypeDelete:
				methodCode = templateDeleteMethod(resource, &operation, operationType, statuses)
			}

			// Build it
			clientMethodFile := fmt.Sprintf("%s/%s/%s/Operation-%s.cs", resource.Service, cleanVersion(resource.Version), resource.Name, operationType)
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

func templateListMethod(resource *Resource, operation *Operation, operationType, responseModel string, args []string) string {
	statuses := make([]string, 0)
	for _, response := range operation.Responses {
		if response.Status >= 200 && response.Status < 400 {
			statuses = append(statuses, strconv.Itoa(response.Status))
		}
	}

	var path string
	if len(args) > 0 {
		path = fmt.Sprintf(`fmt.Sprintf("%s", %s)`, resource.Id.IDf(), strings.Join(args, ", "))
	} else {
		path = fmt.Sprintf("%q", resource.Id.ID())
	}

	return fmt.Sprintf(`using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

namespace Pandora.Definitions.MicrosoftGraph.%[1]s.%[2]s.%[3]s;

internal class %[4]sOperation : Operations.%[4]sOperation
{
    public override string? FieldContainingPaginationDetails() => "nextLink";

    public override ResourceID? ResourceId() => null;

    public override Type NestedItemType() => typeof(%[5]s);

    public override string? UriSuffix() => "%[6]s";


}
`, resource.Service, cleanVersion(resource.Version), resource.Name, operationType, responseModel, path)

}

func templateReadMethod(resource *Resource, operation *Operation, operationType, responseModel string, statuses []string) string {
	expectedStatusesCode := indent(strings.Join(statuses, ",\n"), "                ")
	resourceIdName := fmt.Sprintf("%sId", resource.Name)

	return fmt.Sprintf(`using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

namespace Pandora.Definitions.MicrosoftGraph.%[1]s.%[2]s.%[3]s;

internal class %[4]sOperation : Operations.%[5]sOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
%[6]s
        };

    public override ResourceID? ResourceId() => new %[7]s();

    public override Type? ResponseObject() => typeof(%[8]s);


}
`, resource.Service, cleanVersion(resource.Version), resource.Name, operationType, operation.Method, expectedStatusesCode, resourceIdName, responseModel)
}

func templateCreateUpdateMethod(resource *Resource, operation *Operation, operationType, requestModel, responseModel string, statuses []string) string {
	expectedStatusesCode := indent(strings.Join(statuses, ",\n"), "                ")
	resourceIdName := fmt.Sprintf("%sId", resource.Name)

	//var path string
	//if len(args) > 0 {
	//	path = fmt.Sprintf(`fmt.Sprintf("%s", %s)`, endpoint.Id.IDf(), strings.Join(args, ", "))
	//} else {
	//	path = fmt.Sprintf("%q", endpoint.Id.ID())
	//}

	return fmt.Sprintf(`using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

namespace Pandora.Definitions.MicrosoftGraph.%[1]s.%[2]s.%[3]s;

internal class %[4]sOperation : Operations.%[5]sOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
%[6]s
        };

    public override Type? RequestObject() => typeof(%[7]s);

    public override ResourceID? ResourceId() => new %[8]s();

    public override Type? ResponseObject() => typeof(%[9]s);


}
`, resource.Service, cleanVersion(resource.Version), resource.Name, operationType, operation.Method, expectedStatusesCode, requestModel, resourceIdName, responseModel)
}

func templateDeleteMethod(resource *Resource, operation *Operation, operationType string, statuses []string) string {
	expectedStatusesCode := indent(strings.Join(statuses, ",\n"), "                ")
	resourceIdName := fmt.Sprintf("%sId", resource.Name)

	//var path string
	//if len(args) > 0 {
	//	path = fmt.Sprintf(`fmt.Sprintf("%s", %s)`, endpoint.Id.IDf(), strings.Join(args, ", "))
	//} else {
	//	path = fmt.Sprintf("%q", endpoint.Id.ID())
	//}

	return fmt.Sprintf(`using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

namespace Pandora.Definitions.MicrosoftGraph.%[1]s.%[2]s.%[3]s;

internal class %[4]sOperation : Operations.%[5]sOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
%[6]s
        };

    public override ResourceID? ResourceId() => new %[7]s();


}
`, resource.Service, cleanVersion(resource.Version), resource.Name, operationType, operation.Method, expectedStatusesCode, resourceIdName)
}
