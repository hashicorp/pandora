package dataapigeneratorjson

import (
	"encoding/json"
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	dataApiModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigeneratorjson/models"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func codeForOperation(operationName string, operation importerModels.OperationDetails, knownConstants map[string]resourcemanager.ConstantDetails, knownModels map[string]importerModels.ModelDetails) ([]byte, error) {
	contentType := ""
	if !strings.Contains(strings.ToLower(operation.ContentType), "application/json") {
		contentType = operation.ContentType
	}

	statusCodes := make([]int, 0)
	if usesNonDefaultStatusCodes(operation) {
		for _, sc := range operation.ExpectedStatusCodes {
			statusCodes = append(statusCodes, sc)
		}
		sort.Ints(statusCodes)
	}

	fieldContainingPaginationDetails := ""
	if operation.FieldContainingPaginationDetails != nil {
		fieldContainingPaginationDetails = *operation.FieldContainingPaginationDetails
	}

	longRunning := false
	if operation.LongRunning {
		// TODO: we can use the `LongRunning` operation base types too
		longRunning = true
	}

	resourceId := ""
	if operation.ResourceIdName != nil {
		resourceId = *operation.ResourceIdName
	}

	uriSuffix := ""
	if operation.UriSuffix != nil {
		uriSuffix = *operation.UriSuffix
	}

	HTTPMethod := strings.Title(strings.ToLower(operation.Method))
	if operation.FieldContainingPaginationDetails != nil {
		HTTPMethod = "List"
		// TODO is there a todo here?
		// since this is a List operation we need to additionally output the HttpMethod
		// since it's possible that these are non-standard (e.g. AppConfig 2020-06-01 ListKeys
		// is a POST not a GET for a List operation)
		//if !strings.EqualFold(operation.Method, "GET") {
		//	method := dotNetNameForHttpMethod(operation.Method)
		//	code = append(code, fmt.Sprintf(`		public override System.Net.Http.HttpMethod Method() => System.Net.Http.%s;`, method))
		//}
	}

	responseObject, err := mapObjectDefinition(operation.ResponseObject, knownConstants, knownModels)
	if err != nil {
		return nil, fmt.Errorf("mapping the object definition: %+v", err)
	}

	requestObject, err := mapObjectDefinition(operation.RequestObject, knownConstants, knownModels)
	if err != nil {
		return nil, fmt.Errorf("mapping the object definition: %+v", err)
	}

	op := dataApiModels.Operation{
		Name:                             operationName,
		ContentType:                      contentType,
		ExpectedStatusCodes:              statusCodes,
		FieldContainingPaginationDetails: pointer.To(fieldContainingPaginationDetails),
		LongRunning:                      longRunning,
		HTTPMethod:                       HTTPMethod,
		ResourceIdName:                   pointer.To(resourceId),
		RequestObject:                    responseObject,
		ResponseObject:                   requestObject,
		UriSuffix:                        pointer.To(uriSuffix),
	}

	if len(operation.Options) > 0 {
		options := make([]dataApiModels.Option, 0)
		sortedOptionsKeys := make([]string, 0)
		for k := range operation.Options {
			sortedOptionsKeys = append(sortedOptionsKeys, k)
		}
		sort.Strings(sortedOptionsKeys)

		for _, optionName := range sortedOptionsKeys {
			optionDetails := operation.Options[optionName]

			if optionDetails.ObjectDefinition == nil {
				return nil, fmt.Errorf("missing object definition")
			}

			optionObjectDefinition, err := mapOptionObjectDefinition(optionDetails.ObjectDefinition, knownConstants, knownModels)
			if err != nil {
				return nil, fmt.Errorf("mapping the object definition: %+v", err)
			}

			option := dataApiModels.Option{
				HeaderName:       optionDetails.HeaderName,
				QueryString:      optionDetails.QueryStringName,
				Field:            optionName,
				ObjectDefinition: optionObjectDefinition,
			}

			if !optionDetails.Required {
				option.Optional = true
			} else {
				option.Required = true
			}

			options = append(options, option)
		}
		op.Options = pointer.To(options)
	}

	data, err := json.MarshalIndent(op, "", " ")
	if err != nil {
		return nil, err
	}

	return data, nil
}

func usesNonDefaultStatusCodes(operation importerModels.OperationDetails) bool {
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

var internalObjectDefinitionsToOptionObjectDefinitionTypes = map[importerModels.ObjectDefinitionType]dataApiModels.OptionObjectDefinitionType{
	importerModels.ObjectDefinitionBoolean:   dataApiModels.BooleanOptionObjectDefinitionType,
	importerModels.ObjectDefinitionCsv:       dataApiModels.CsvOptionObjectDefinitionType,
	importerModels.ObjectDefinitionInteger:   dataApiModels.IntegerOptionObjectDefinitionType,
	importerModels.ObjectDefinitionFloat:     dataApiModels.FloatOptionObjectDefinitionType,
	importerModels.ObjectDefinitionList:      dataApiModels.ListOptionObjectDefinitionType,
	importerModels.ObjectDefinitionReference: dataApiModels.ReferenceOptionObjectDefinitionType,
	importerModels.ObjectDefinitionString:    dataApiModels.StringOptionObjectDefinitionType,
}

func mapOptionObjectDefinition(definition *importerModels.ObjectDefinition, constants map[string]resourcemanager.ConstantDetails, models map[string]importerModels.ModelDetails) (*dataApiModels.OptionObjectDefinition, error) {
	typeVal, ok := internalObjectDefinitionsToOptionObjectDefinitionTypes[definition.Type]
	if !ok {
		return nil, fmt.Errorf("internal-error: no OptionObjectDefinition mapping is defined for the OptionObjectDefinition Type %q", string(definition.Type))
	}

	output := dataApiModels.OptionObjectDefinition{
		Type:          typeVal,
		ReferenceName: nil,
		NestedItem:    nil,
	}

	if definition.ReferenceName != nil {
		output.ReferenceName = definition.ReferenceName
	}

	if definition.NestedItem != nil {
		nestedItem, err := mapOptionObjectDefinition(definition.NestedItem, constants, models)
		if err != nil {
			return nil, fmt.Errorf("mapping nested option object definition: %+v", err)
		}
		output.NestedItem = nestedItem
	}

	// finally let's do some sanity-checking to ensure the data being output looks legit
	if err := validateOptionObjectDefinition(output, constants, models); err != nil {
		return nil, fmt.Errorf("validating mapped OptionObjectDefinition: %+v", err)
	}

	return &output, nil
}

func validateOptionObjectDefinition(input dataApiModels.OptionObjectDefinition, constants map[string]resourcemanager.ConstantDetails, models map[string]importerModels.ModelDetails) error {
	requiresNestedItem := input.Type == dataApiModels.CsvOptionObjectDefinitionType || input.Type == dataApiModels.ListOptionObjectDefinitionType
	requiresReference := input.Type == dataApiModels.ReferenceOptionObjectDefinitionType
	if requiresNestedItem && input.NestedItem == nil {
		return fmt.Errorf("a Nested Object Definition must be specified for a %q type but didn't get one", string(input.Type))
	}
	if !requiresNestedItem && input.NestedItem != nil {
		return fmt.Errorf("a Nested Object Definition must not be specified for a %q type but got %q", string(input.Type), string(input.NestedItem.Type))
	}
	if requiresReference {
		if input.ReferenceName == nil {
			return fmt.Errorf("a Reference must be specified for a %q type but didn't get one", string(input.Type))
		}

		_, isConstant := constants[*input.ReferenceName]
		_, isModel := models[*input.ReferenceName]
		if !isConstant && !isModel {
			return fmt.Errorf("reference %q was not found as a constant or a model", *input.ReferenceName)
		}
		if isConstant && isModel {
			return fmt.Errorf("internal-error: %q was found as BOTH a Constant and a Model", *input.ReferenceName)
		}
	}
	if !requiresReference && input.ReferenceName != nil {
		return fmt.Errorf("a Reference must not be specified for a %q type but got %q", string(input.Type), *input.ReferenceName)
	}

	return nil
}
