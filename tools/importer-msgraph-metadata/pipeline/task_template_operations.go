package pipeline

import (
	"fmt"
	"os"
	"strconv"
	"strings"
)

func (p pipelineTask) templateOperationsForService(resources Resources) error {
	operations := make(map[string]string)

	// First build all the methods
	for _, resource := range resources {
		if resource.Category == "" {
			continue
		}

		for _, operation := range resource.Operations {
			// Determine request model
			var requestModel string
			if operation.RequestModel != nil {
				requestModel = *operation.RequestModel
			}

			// Determine response model and return values
			var responseModel string
			if operation.Type != OperationTypeDelete {
				responseModel = operation.Responses.FindModelName()

				// Infer a DirectoryObject response model when no model found and the final ID segment indicates an OData reference
				if responseModel == "" {
					if operation.ResourceId != nil && len(operation.ResourceId.Segments) > 0 && operation.ResourceId.Segments[len(operation.ResourceId.Segments)-1].Value == "$ref" {
						responseModel = "DirectoryObject"
					}
				}
			}

			contentType := ""
			statuses := make([]string, 0)
			for _, response := range operation.Responses {
				if response.ContentType != nil && *response.ContentType != "" {
					contentType = strings.ToLower(*response.ContentType)
				}
				statuses = append(statuses, strconv.Itoa(response.Status))
			}

			namespace := fmt.Sprintf("Pandora.Definitions.%[1]s.%[2]s.%[3]s.%[4]s", definitionsDirectory(resource.Version), resource.Service, cleanVersion(resource.Version), resource.Category)
			modelsNamespace := fmt.Sprintf("Pandora.Definitions.%[1]s.Models", definitionsDirectory(resource.Version))

			// Template the operationFile code
			var methodCode string
			switch operation.Type {
			case OperationTypeList:
				if responseModel == "" {
					id := ""
					if operation.ResourceId != nil {
						id = operation.ResourceId.ID()
					}
					uriSuffix := ""
					if operation.UriSuffix != nil {
						uriSuffix = *operation.UriSuffix
					}
					p.logger.Warn(fmt.Sprintf("Skipping operation with empty response model for method %q (ID %q, suffix %q, category %q, service %q, version %q)", operation.Method, id, uriSuffix, resource.Category, resource.Service, resource.Version))
					continue
				}
				methodCode = templateListOperation(namespace, modelsNamespace, &operation, responseModel)
			case OperationTypeRead:
				methodCode = templateReadOperation(namespace, modelsNamespace, &operation, contentType, responseModel, statuses)
			case OperationTypeCreate, OperationTypeUpdate, OperationTypeCreateUpdate:
				methodCode = templateCreateUpdateOperation(namespace, modelsNamespace, &operation, contentType, requestModel, responseModel, statuses)
			case OperationTypeDelete:
				methodCode = templateDeleteOperation(namespace, &operation, statuses)
			}

			// Build it
			filename := fmt.Sprintf("Pandora.Definitions.%[2]s%[1]s%[3]s%[1]s%[4]s%[1]s%[5]s%[1]sOperation-%[6]s.cs", string(os.PathSeparator), definitionsDirectory(resource.Version), resource.Service, cleanVersion(resource.Version), resource.Category, operation.Name)
			operations[filename] = methodCode
		}
	}

	// Then output them as separate source files
	operationFiles := sortedKeys(operations)
	for _, operationFile := range operationFiles {
		if err := p.files.addFile(operationFile, operations[operationFile]); err != nil {
			return err
		}
	}

	return nil
}

func templateListOperation(namespace, modelsNamespace string, operation *Operation, responseModel string) string {
	modelsImportCode := ""
	if modelsNamespace != "" {
		modelsImportCode = fmt.Sprintf("using %s;", modelsNamespace)
	}

	resourceIdCode := "null"
	if operation.ResourceId != nil {
		resourceIdCode = fmt.Sprintf(`new %sId()`, operation.ResourceId.Name)
	}

	uriSuffixCode := "null"
	if operation.UriSuffix != nil {
		uriSuffixCode = fmt.Sprintf(`"%s"`, *operation.UriSuffix)
	}

	return fmt.Sprintf(`using Pandora.Definitions.Interfaces;
%[2]s
using System;

// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

namespace %[1]s;

internal class %[3]sOperation : Operations.ListOperation
{
   public override string? FieldContainingPaginationDetails() => "nextLink";
   public override ResourceID? ResourceId() => %[4]s;
   public override Type NestedItemType() => typeof(%[5]sModel);
   public override string? UriSuffix() => %[6]s;
}
`, namespace, modelsImportCode, operation.Name, resourceIdCode, responseModel, uriSuffixCode)

}

func templateReadOperation(namespace, modelsNamespace string, operation *Operation, contentType, responseModel string, statuses []string) string {
	modelsImportCode := ""
	if modelsNamespace != "" {
		modelsImportCode = fmt.Sprintf("using %s;", modelsNamespace)
	}

	statusEnums := make([]string, len(statuses))
	for i, status := range statuses {
		code, _ := strconv.Atoi(status)
		statusEnums[i] = csHttpStatusCode(code)
	}

	expectedStatusesCode := indentSpace(strings.Join(statusEnums, ",\n"), 16)

	contentTypeCode := ""
	if !strings.HasPrefix(contentType, "application/json") {
		contentTypeCode = indentSpace(fmt.Sprintf(`public override string? ContentType() => "%s";`, contentType), 4)
	}

	resourceIdCode := "null"
	if operation.ResourceId != nil {
		resourceIdCode = fmt.Sprintf(`new %sId()`, operation.ResourceId.Name)
	}

	uriSuffixCode := "null"
	if operation.UriSuffix != nil {
		uriSuffixCode = fmt.Sprintf(`"%s"`, *operation.UriSuffix)
	}

	responseObjectCode := "null"
	if responseModel != "" {
		responseObjectCode = fmt.Sprintf("typeof(%sModel)", responseModel)
	}

	return fmt.Sprintf(`using Pandora.Definitions.Interfaces;
%[2]s
using System.Collections.Generic;
using System.Net;
using System;

// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

namespace %[1]s;

internal class %[3]sOperation : Operations.%[4]sOperation
{
%[9]s
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
%[5]s,
        };
    public override ResourceID? ResourceId() => %[6]s;
    public override Type? ResponseObject() => %[10]s;
    public override string? UriSuffix() => %[8]s;
}
`, namespace, modelsImportCode, operation.Name, strings.Title(strings.ToLower(operation.Method)), expectedStatusesCode, resourceIdCode, responseModel, uriSuffixCode, contentTypeCode, responseObjectCode)
}

func templateCreateUpdateOperation(namespace, modelsNamespace string, operation *Operation, contentType, requestModel, responseModel string, statuses []string) string {
	modelsImportCode := ""
	if modelsNamespace != "" {
		modelsImportCode = fmt.Sprintf("using %s;", modelsNamespace)
	}

	statusEnums := make([]string, len(statuses))
	for i, status := range statuses {
		code, _ := strconv.Atoi(status)
		statusEnums[i] = csHttpStatusCode(code)
	}

	expectedStatusesCode := indentSpace(strings.Join(statusEnums, ",\n"), 16)

	contentTypeCode := ""
	if !strings.HasPrefix(contentType, "application/json") {
		contentTypeCode = indentSpace(fmt.Sprintf(`public override string? ContentType() => "%s";`, contentType), 4)
	}

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
%[2]s
using System.Collections.Generic;
using System.Net;
using System;

// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

namespace %[1]s;

internal class %[3]sOperation : Operations.%[4]sOperation
{
%[10]s
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
%[5]s,
        };
    public override Type? RequestObject() => %[6]s;
    public override ResourceID? ResourceId() => %[7]s;
    public override Type? ResponseObject() => %[8]s;
    public override string? UriSuffix() => %[9]s;
}
`, namespace, modelsImportCode, operation.Name, strings.Title(strings.ToLower(operation.Method)), expectedStatusesCode, requestObjectCode, resourceIdCode, responseObjectCode, uriSuffixCode, contentTypeCode)
}

func templateDeleteOperation(namespace string, operation *Operation, statuses []string) string {
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

namespace %[1]s;

internal class %[2]sOperation : Operations.%[3]sOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
%[4]s,
        };
    public override ResourceID? ResourceId() => %[5]s;
    public override string? UriSuffix() => %[6]s;
}
`, namespace, operation.Name, strings.Title(strings.ToLower(operation.Method)), expectedStatusesCode, resourceIdCode, uriSuffixCode)
}
