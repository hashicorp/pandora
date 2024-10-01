package parser

import (
	"fmt"
	"strings"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	parserModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/models"
)

func (p *apiDefinitionsParser) FindOrphanedDiscriminatedModels(serviceName string) (*parserModels.ParseResult, error) {
	result := parserModels.ParseResult{
		Constants: map[string]sdkModels.SDKConstant{},
		Models:    map[string]sdkModels.SDKModel{},
	}

	for modelName, definition := range p.context.SwaggerSpecWithReferencesRaw.Definitions {
		if _, ok := definition.Extensions.GetString("x-ms-discriminator-value"); ok {
			details, err := p.context.ParseModel(modelName, definition)
			if err != nil {
				return nil, fmt.Errorf("parsing model details for model %q: %+v", modelName, err)
			}
			if err := result.Append(*details); err != nil {
				return nil, fmt.Errorf("appending model %q: %+v", modelName, err)
			}
		}

		// intentionally scoped to `datafactory` given the peculiarities in the swagger definition
		// in particular question 4. in this issue https://github.com/Azure/azure-rest-api-specs/issues/28380
		// TODO: determine whether it is safe to remove this hardcoded restriction and apply this logic to all services
		if strings.EqualFold(serviceName, "datafactory") {
			// this catches orphaned discriminated models where the discriminator information is housed in the parent
			// and uses the name of the model as the discriminated value
			if _, ok := definition.Extensions.GetString("x-ms-discriminator-value"); !ok && len(definition.AllOf) > 0 {
				parentType, discriminator, err := p.context.FindAncestorType(definition)
				if err != nil {
					return nil, fmt.Errorf("determining ancestor type for model %q: %+v", modelName, err)
				}

				details, err := p.context.ParseModel(modelName, definition)
				if err != nil {
					return nil, fmt.Errorf("parsing model details for model %q: %+v", modelName, err)
				}
				if parentType != nil && discriminator != nil {
					model := details.Models[modelName]
					model.ParentTypeName = parentType
					model.FieldNameContainingDiscriminatedValue = discriminator
					model.DiscriminatedValue = pointer.To(modelName)
					details.Models[modelName] = model
				}
				if err := result.Append(*details); err != nil {
					return nil, fmt.Errorf("appending model %q: %+v", modelName, err)
				}
			}
		}
	}

	// this will also pull out the parent model in the file which will already have been parsed, but that's ok
	// since they will be de-duplicated when we call combineResourcesWith
	nestedResult, err := p.context.FindNestedItemsYetToBeParsed(map[string]sdkModels.SDKOperation{}, result)
	if err != nil {
		return nil, fmt.Errorf("finding nested items yet to be parsed: %+v", err)
	}
	if err := result.Append(*nestedResult); err != nil {
		return nil, fmt.Errorf("appending nestedResult from Models used by existing Items: %+v", err)
	}

	return &result, nil
}
