package generator

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func (g PandoraDefinitionGenerator) codeForOperation(namespace string, operationName string, operation models.OperationDetails) string {
	code := make([]string, 0)

	if g.usesNonDefaultStatusCodes(operation) {
		statusCodes := make([]string, 0)
		for _, sc := range operation.ExpectedStatusCodes {
			statusCodes = append(statusCodes, fmt.Sprintf("\t\t\t\t%s,", g.dotnetNameForStatusCode(sc)))
		}
		code = append(code, fmt.Sprintf(`		public override IEnumerable<HttpStatusCode> ExpectedStatusCodes()
		{
			return new List<HttpStatusCode>
			{
%s
			};
		}`, strings.Join(statusCodes, "\n")))
	}

	if operation.FieldContainingPaginationDetails != nil {
		code = append(code, fmt.Sprintf(`		public override string? FieldContainingPaginationDetails()
		{
			return %[1]q;
		}`, *operation.FieldContainingPaginationDetails))
	}

	// TODO: other fields, status codes if they're non-default
	if operation.LongRunning {
		code = append(code, `		public override bool LongRunning()
		{
			return true;
		}`)
	}

	if operation.RequestObjectName != nil {
		code = append(code, fmt.Sprintf(`		public override object? RequestObject()
		{
			return new %[1]s();
		}`, *operation.RequestObjectName))
	} else if strings.EqualFold(operation.Method, "POST") || strings.EqualFold(operation.Method, "PUT") {
		// Post and Put operations should have one but it's possible they don't
		code = append(code, fmt.Sprintf(`		public override object? RequestObject()
		{
			return null;
		}`))
	}

	if operation.ResourceIdName != nil {
		code = append(code, fmt.Sprintf(`		public override ResourceID? ResourceId()
		{
			return new %[1]s();
		}`, *operation.ResourceIdName))
	}

	if operation.ResponseObjectName != nil {
		if operation.FieldContainingPaginationDetails == nil {
			code = append(code, fmt.Sprintf(`		public override object? ResponseObject()
		{
			return new %[1]s();
		}`, *operation.ResponseObjectName))
		} else {
			code = append(code, fmt.Sprintf(`		public override object NestedItemType()
		{
			return new %[1]s();
		}`, *operation.ResponseObjectName))
		}
	} else if operation.ResponseObjectType != nil { // We should only process this if the ref is missing
		switch responseObjectType := *operation.ResponseObjectType; responseObjectType {
		case "string":
			code = append(code, fmt.Sprintf(`		public override %[1]s? ResponseObject()
		{
			return null;
		}`, *operation.ResponseObjectType))
		case "object", "file": // TODO - Be more specific here? Add type definition for `file`?
			code = append(code, fmt.Sprintf(`		public override object? ResponseObject()
		{
			return null;
		}`))
		case "array":
			if operation.FieldContainingPaginationDetails != nil {
				code = append(code, fmt.Sprintf(`		public override List<%[1]s>? ResponseObject()
		{
			return null;
		}`, *operation.FieldContainingPaginationDetails))

			}
		}
	}

	optionsCode := make([]string, 0)
	if len(operation.Options) > 0 {
		code = append(code, fmt.Sprintf(`		public override object? OptionsObject()
		{
			return new %[1]sOptions();
		}`, operationName))

		optionsCode = append(optionsCode, fmt.Sprintf("\n\tinternal class %sOptions", operationName))
		optionsCode = append(optionsCode, "\t{")
		for optionName, optionDetails := range operation.Options {
			if optionDetails.QueryStringName != "" {
				optionsCode = append(optionsCode, fmt.Sprintf("\t\t[QueryStringName(%q)]", optionDetails.QueryStringName))
			}
			if !optionDetails.Required {
				optionsCode = append(optionsCode, "\t\t[Optional]")
			}
			optionsCode = append(optionsCode, fmt.Sprintf("\t\tpublic %s %s { get; set; }", normaliseTypeForDotNet(optionDetails.FieldType), optionName))
		}
		optionsCode = append(optionsCode, "\t}")
	}

	if operation.UriSuffix != nil {
		code = append(code, fmt.Sprintf(`		public override string? UriSuffix()
		{
			return %[1]q;
		}`, *operation.UriSuffix))
	}

	operationType := strings.Title(strings.ToLower(operation.Method))
	if operation.FieldContainingPaginationDetails != nil {
		operationType = "List"
	}
	return fmt.Sprintf(`using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace %[1]s
{
	internal class %[2]s : %[3]sOperation
	{
%[4]s
	}%[5]s
}
`, namespace, operationName, operationType, strings.Join(code, "\n\n"), strings.Join(optionsCode, "\n"))
}

func (g PandoraDefinitionGenerator) usesNonDefaultStatusCodes(operation models.OperationDetails) bool {
	defaultStatusCodes := map[string][]int{
		"get":    {200},
		"post":   {200, 201},
		"put":    {200, 201},
		"delete": {200, 201},
		"patch":  {200, 201},
	}
	expected, ok := defaultStatusCodes[strings.ToLower(operation.Method)]
	if !ok {
		// potentially an unsupported use-case but fine for now
		return true
	}

	if len(expected) != len(operation.ExpectedStatusCodes) {
		return true
	}

	sort.Ints(expected)
	sort.Ints(operation.ExpectedStatusCodes)
	for i, ev := range expected {
		av := operation.ExpectedStatusCodes[i]
		if ev != av {
			return true
		}
	}

	return false
}

func (g PandoraDefinitionGenerator) dotnetNameForStatusCode(input int) string {
	switch input {
	case 200:
		return "HttpStatusCode.OK"
	case 201:
		return "HttpStatusCode.Created"
	case 202:
		return "HttpStatusCode.Accepted"
	case 204:
		return "HttpStatusCode.NoContent"
	case 301:
		return "HttpStatusCode.Moved"
	case 302:
		return "HttpStatusCode.Found"

	default:
		return fmt.Sprintf("TODO: support %d", input)
	}
}
