// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package pipeline

import (
	"fmt"
	"path"
	"strconv"
	"strings"
)

func (p pipelineTask) templateOperationsForService(commonTypesDirectoryName string, resources Resources) error {
	operations := make(map[string]string)

	// First build all the methods
	for _, resource := range resources {
		if resource.Category == "" {
			continue
		}

		for _, operation := range resource.Operations {
			// Determine response model and return values
			var responseModel, responseType *string
			if operation.Type != OperationTypeDelete {
				responseModel = operation.Responses.FindModelName()

				for _, r := range operation.Responses {
					if r.Type != nil {
						responseType = r.Type.CSType()
						break
					}
				}
			}

			var contentType *string
			statuses := make([]string, 0)
			for _, response := range operation.Responses {
				if response.ContentType != nil && *response.ContentType != "" {
					contentType = pointerTo(strings.ToLower(*response.ContentType))
				}
				statuses = append(statuses, strconv.Itoa(response.Status))
			}

			namespace := fmt.Sprintf("Pandora.Definitions.%[1]s.%[2]s.%[3]s.%[4]s", definitionsDirectory(resource.Version), resource.Service, cleanVersion(resource.Version), resource.Category)
			modelsNamespace := fmt.Sprintf("Pandora.Definitions.%[1]s.%[2]s", definitionsDirectory(resource.Version), commonTypesDirectoryName)

			// Template the operationFile code
			var methodCode string
			switch operation.Type {
			case OperationTypeList:
				if responseModel == nil && responseType == nil {
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
				methodCode = templateListOperation(namespace, modelsNamespace, &operation, responseModel, responseType)
			case OperationTypeRead:
				methodCode = templateReadOperation(namespace, modelsNamespace, &operation, contentType, responseModel, responseType, statuses)
			case OperationTypeCreate, OperationTypeUpdate, OperationTypeCreateUpdate:
				methodCode = templateCreateUpdateOperation(namespace, modelsNamespace, &operation, contentType, responseModel, statuses)
			case OperationTypeDelete:
				methodCode = templateDeleteOperation(namespace, &operation, statuses)
			}

			// Build it
			filename := path.Join(fmt.Sprintf("Pandora.Definitions.%s", definitionsDirectory(resource.Version)), resource.Service, cleanVersion(resource.Version), resource.Category, fmt.Sprintf("Operation-%s.cs", operation.Name))
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

func templateListOperation(namespace, modelsNamespace string, operation *Operation, responseModel, responseType *string) string {
	modelsImportCode := ""
	if modelsNamespace != "" {
		modelsImportCode = fmt.Sprintf("using %s;", modelsNamespace)
	}

	resourceIdCode := "null"
	if operation.ResourceId != nil {
		resourceIdCode = fmt.Sprintf(`new %s()`, operation.ResourceId.Name)
	}

	uriSuffixCode := "null"
	if operation.UriSuffix != nil {
		uriSuffixCode = fmt.Sprintf(`"%s"`, *operation.UriSuffix)
	}

	nestedItemTypeCode := "null"
	if responseModel != nil {
		nestedItemTypeCode = fmt.Sprintf("typeof(%sModel)", *responseModel)
	} else if responseType != nil {
		nestedItemTypeCode = fmt.Sprintf("typeof(%s)", *responseType)
	}

	return fmt.Sprintf(`// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
%[2]s
using System;

namespace %[1]s;

internal class %[3]sOperation : Operations.ListOperation
{
   public override string? FieldContainingPaginationDetails() => "nextLink";
   public override ResourceID? ResourceId() => %[4]s;
   public override Type NestedItemType() => %[5]s;
   public override string? URISuffix() => %[6]s;
}
`, namespace, modelsImportCode, operation.Name, resourceIdCode, nestedItemTypeCode, uriSuffixCode)

}

func templateReadOperation(namespace, modelsNamespace string, operation *Operation, contentType, responseModel, responseType *string, statuses []string) string {
	modelsImportCode := ""
	if modelsNamespace != "" {
		modelsImportCode = fmt.Sprintf("using %s;", modelsNamespace)
	}

	statusEnums := make([]string, len(statuses))
	for i, status := range statuses {
		code, _ := strconv.Atoi(status)
		statusEnums[i] = csHttpStatusCode(code)
	}

	expectedStatusesCode := indentSpace(strings.Join(statusEnums, ",\n"), 12)

	contentTypeCode := ""
	if contentType != nil && !strings.HasPrefix(*contentType, "application/json") {
		contentTypeCode = indentSpace(fmt.Sprintf(`public override string? ContentType() => "%s";`, *contentType), 4)
	}

	resourceIdCode := "null"
	if operation.ResourceId != nil {
		resourceIdCode = fmt.Sprintf(`new %s()`, operation.ResourceId.Name)
	}

	uriSuffixCode := "null"
	if operation.UriSuffix != nil {
		uriSuffixCode = fmt.Sprintf(`"%s"`, *operation.UriSuffix)
	}

	responseObjectCode := "null"
	if responseModel != nil {
		responseObjectCode = fmt.Sprintf("typeof(%sModel)", *responseModel)
	} else if responseType != nil {
		responseObjectCode = fmt.Sprintf("typeof(%s)", *responseType)
	}

	return fmt.Sprintf(`// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
%[2]s
using System.Collections.Generic;
using System.Net;
using System;

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
    public override string? URISuffix() => %[8]s;
}
`, namespace, modelsImportCode, operation.Name, strings.Title(strings.ToLower(operation.Method)), expectedStatusesCode, resourceIdCode, responseModel, uriSuffixCode, contentTypeCode, responseObjectCode)
}

func templateCreateUpdateOperation(namespace, modelsNamespace string, operation *Operation, contentType, responseModel *string, statuses []string) string {
	modelsImportCode := ""
	if modelsNamespace != "" {
		modelsImportCode = fmt.Sprintf("using %s;", modelsNamespace)
	}

	statusEnums := make([]string, len(statuses))
	for i, status := range statuses {
		code, _ := strconv.Atoi(status)
		statusEnums[i] = csHttpStatusCode(code)
	}

	expectedStatusesCode := indentSpace(strings.Join(statusEnums, ",\n"), 12)

	contentTypeCode := ""
	if contentType != nil && !strings.HasPrefix(*contentType, "application/json") {
		contentTypeCode = indentSpace(fmt.Sprintf(`public override string? ContentType() => "%s";`, *contentType), 4)
	}

	resourceIdCode := "null"
	if operation.ResourceId != nil {
		resourceIdCode = fmt.Sprintf(`new %s()`, operation.ResourceId.Name)
	}

	uriSuffixCode := "null"
	if operation.UriSuffix != nil {
		uriSuffixCode = fmt.Sprintf(`"%s"`, *operation.UriSuffix)
	}

	requestObjectCode := "null"
	if operation.RequestModel != nil {
		requestObjectCode = fmt.Sprintf("typeof(%sModel)", *operation.RequestModel)
	} else if operation.RequestType != nil {
		requestObjectCode = fmt.Sprintf("typeof(%s)", *operation.RequestType.CSType())
	}

	responseObjectCode := "null"
	if responseModel != nil {
		responseObjectCode = fmt.Sprintf("typeof(%sModel)", *responseModel)
	}

	return fmt.Sprintf(`// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
%[2]s
using System.Collections.Generic;
using System.Net;
using System;

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
    public override string? URISuffix() => %[9]s;
}
`, namespace, modelsImportCode, operation.Name, strings.Title(strings.ToLower(operation.Method)), expectedStatusesCode, requestObjectCode, resourceIdCode, responseObjectCode, uriSuffixCode, contentTypeCode)
}

func templateDeleteOperation(namespace string, operation *Operation, statuses []string) string {
	statusEnums := make([]string, len(statuses))
	for i, status := range statuses {
		code, _ := strconv.Atoi(status)
		statusEnums[i] = csHttpStatusCode(code)
	}

	expectedStatusesCode := indentSpace(strings.Join(statusEnums, ",\n"), 12)

	resourceIdCode := "null"
	if operation.ResourceId != nil {
		resourceIdCode = fmt.Sprintf(`new %s()`, operation.ResourceId.Name)
	}

	uriSuffixCode := "null"
	if operation.UriSuffix != nil {
		uriSuffixCode = fmt.Sprintf(`"%s"`, *operation.UriSuffix)
	}

	return fmt.Sprintf(`// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System.Collections.Generic;
using System.Net;

namespace %[1]s;

internal class %[2]sOperation : Operations.%[3]sOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
%[4]s,
        };
    public override ResourceID? ResourceId() => %[5]s;
    public override string? URISuffix() => %[6]s;
}
`, namespace, operation.Name, strings.Title(strings.ToLower(operation.Method)), expectedStatusesCode, resourceIdCode, uriSuffixCode)
}
