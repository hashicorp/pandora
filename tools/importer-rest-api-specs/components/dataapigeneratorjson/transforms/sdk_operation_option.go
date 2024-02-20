package transforms

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/sdk/dataapimodels"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var sdkOperationOptionsToRepository = map[resourcemanager.ApiObjectDefinitionType]dataapimodels.OptionObjectDefinitionType{
	resourcemanager.BooleanApiObjectDefinitionType:   dataapimodels.BooleanOptionObjectDefinitionType,
	resourcemanager.CsvApiObjectDefinitionType:       dataapimodels.CsvOptionObjectDefinitionType,
	resourcemanager.IntegerApiObjectDefinitionType:   dataapimodels.IntegerOptionObjectDefinitionType,
	resourcemanager.FloatApiObjectDefinitionType:     dataapimodels.FloatOptionObjectDefinitionType,
	resourcemanager.ListApiObjectDefinitionType:      dataapimodels.ListOptionObjectDefinitionType,
	resourcemanager.ReferenceApiObjectDefinitionType: dataapimodels.ReferenceOptionObjectDefinitionType,
	resourcemanager.StringApiObjectDefinitionType:    dataapimodels.StringOptionObjectDefinitionType,
}

func mapSDKOperationOptionToRepository(definition resourcemanager.ApiObjectDefinition, constants map[string]resourcemanager.ConstantDetails, models map[string]resourcemanager.ModelDetails) (*dataapimodels.OptionObjectDefinition, error) {
	typeVal, ok := sdkOperationOptionsToRepository[definition.Type]
	if !ok {
		return nil, fmt.Errorf("internal-error: no OptionObjectDefinition mapping is defined for the OptionObjectDefinition Type %q", string(definition.Type))
	}

	output := dataapimodels.OptionObjectDefinition{
		Type:          typeVal,
		ReferenceName: nil,
		NestedItem:    nil,
	}

	if definition.ReferenceName != nil {
		output.ReferenceName = definition.ReferenceName
	}

	if definition.NestedItem != nil {
		nestedItem, err := mapSDKOperationOptionToRepository(*definition.NestedItem, constants, models)
		if err != nil {
			return nil, fmt.Errorf("mapping nested option object definition: %+v", err)
		}
		output.NestedItem = nestedItem
	}

	// finally let's do some sanity-checking to ensure the data being output looks legit
	if err := validateSDKOperationOptionObjectDefinition(output, constants, models); err != nil {
		return nil, fmt.Errorf("validating mapped OptionObjectDefinition: %+v", err)
	}

	return &output, nil
}

func validateSDKOperationOptionObjectDefinition(input dataapimodels.OptionObjectDefinition, constants map[string]resourcemanager.ConstantDetails, models map[string]resourcemanager.ModelDetails) error {
	requiresNestedItem := input.Type == dataapimodels.CsvOptionObjectDefinitionType || input.Type == dataapimodels.ListOptionObjectDefinitionType
	requiresReference := input.Type == dataapimodels.ReferenceOptionObjectDefinitionType
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
