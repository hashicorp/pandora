package processors

import (
	"fmt"
	"regexp"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

type FieldNameProcessor interface {
	ProcessField(fieldName string, metadata FieldMetadata) (*string, error)
}

type FieldMetadata struct {
	TerraformDetails resourcemanager.TerraformResourceDetails
	Model            resourcemanager.ModelDetails
}

var NamingRules = []FieldNameProcessor{
	// Exists should be first rule in the list since that checks whether the field even exists in the model
	fieldNameExists{},
	//fieldNameFlattenListReferenceIds{},
	fieldNameIs{},
	fieldNamePluralToSingular{},
	fieldNameRemoveResourcePrefix{},
	fieldNameRenameBoolean{},
}

type fieldNameExists struct{}

func (fieldNameExists) ProcessField(fieldName string, metadata FieldMetadata) (*string, error) {
	_, ok := metadata.Model.Fields[fieldName]
	if !ok {
		return nil, fmt.Errorf("%s was not found in %+v", fieldName, metadata.Model.Fields)
	}
	return nil, nil
}

type fieldNameIs struct{}

func (fieldNameIs) ProcessField(fieldName string, metadata FieldMetadata) (*string, error) {
	re := regexp.MustCompile("^Is[A-Z][a-z]*")
	if re.MatchString(fieldName) {
		updatedName := fieldName[2:]
		return &updatedName, nil
	}
	return nil, nil
}

type fieldNamePluralToSingular struct{}

func (fieldNamePluralToSingular) ProcessField(fieldName string, metadata FieldMetadata) (*string, error) {
	if metadata.Model.Fields[fieldName].ObjectDefinition.Type == resourcemanager.ListApiObjectDefinitionType {
		if strings.HasSuffix(fieldName, "s") && !strings.HasSuffix(fieldName, "ss") {
			updatedName := strings.TrimSuffix(fieldName, "s")
			return &updatedName, nil
		}
	}
	return nil, nil
}

type fieldNameRenameBoolean struct{}

func (fieldNameRenameBoolean) ProcessField(fieldName string, metadata FieldMetadata) (*string, error) {
	if metadata.Model.Fields[fieldName].ObjectDefinition.Type == resourcemanager.BooleanApiObjectDefinitionType {
		var updatedFieldName *string
		// flip `enable_X` / `disable_X` prefix
		if strings.HasPrefix(strings.ToLower(fieldName), "enable") {
			updated := fmt.Sprintf("%sEnabled", fieldName[6:])
			updatedFieldName = &updated
		}
		if strings.HasPrefix(strings.ToLower(fieldName), "disable") {
			updated := fmt.Sprintf("%sDisabled", fieldName[7:])
			updatedFieldName = &updated
		}
		// change `allow_X` prefix -> `X_enabled`
		if strings.HasPrefix(strings.ToLower(fieldName), "allow") {
			updated := fmt.Sprintf("%sEnabled", fieldName[5:])
			updatedFieldName = &updated
		}
		// change `allowed_X` prefix -> `X_enabled`
		if strings.HasPrefix(strings.ToLower(fieldName), "allowed") {
			updated := fmt.Sprintf("%sEnabled", fieldName[7:])
			updatedFieldName = &updated
		}
		return updatedFieldName, nil
	}
	return nil, nil
}

type fieldNameRemoveResourcePrefix struct{}

func (fieldNameRemoveResourcePrefix) ProcessField(fieldName string, metadata FieldMetadata) (*string, error) {
	if strings.HasPrefix(fieldName, metadata.TerraformDetails.ResourceName) {
		updatedName := strings.Replace(fieldName, metadata.TerraformDetails.ResourceName, "", 1)
		return &updatedName, nil
	}
	return nil, nil
}

//
//type fieldNameFlattenListReferenceIds struct{}
//
//func (fieldNameFlattenListReferenceIds) ProcessField(fieldName string, metadata FieldMetadata) (*string, error) {
//	if model.Fields[fieldName].ObjectDefinition.Type == resourcemanager.ListApiObjectDefinitionType {
//		modelName := ""
//		if model.Fields[fieldName].ObjectDefinition.ReferenceName != nil {
//			modelName = *model.Fields[fieldName].ObjectDefinition.ReferenceName
//		} else if model.Fields[fieldName].ObjectDefinition.NestedItem.ReferenceName != nil {
//			modelName = *model.Fields[fieldName].ObjectDefinition.NestedItem.ReferenceName
//		} else {
//			return nil, nil
//		}
//		model, ok := input.Models[modelName]
//		if ok {
//			if len(model.Fields) == 1 {
//				// TODO Do we really need to check whether the Id is a reference?
//				if _, ok := schema.GetField(model, "Ids"); ok {
//					updatedFieldName := fmt.Sprintf("%sIds", fieldName)
//					return &updatedFieldName, nil
//				}
//			}
//		}
//	}
//	return nil, nil
//}

//type fieldNameRenameBlockId struct{}
//
//func (fieldNameRenameBlockId) ProcessField(fieldName string, input *Builder, model *resourcemanager.ModelDetails, _ *resourcemanager.TerraformResourceDetails) (*string, error) {
//	if model.Fields[fieldName].ObjectDefinition.Type == resourcemanager.ReferenceApiObjectDefinitionType {
//		model, ok := input.Models[*model.Fields[fieldName].ObjectDefinition.ReferenceName]
//		if ok {
//			if len(model.Fields) != 1 {
//				for k, _ := range model.Fields {
//					if strings.EqualFold(k, "Id") {
//
//					}
//				}
//			}
//		}
//
//	}
//	return nil, nil
//}

//TODO: if it's a List[Reference] and the model contains a single field `Id` then flatten this into `_ids`.
//TODO: handling booleans `SomeBool` -> `SomeBoolEnabled` etc.
//TODO: Singularizing plural names when it's a List (e.g. `planets` -> `planet`)
//TODO: handle `is_XXX` -> `XXX`
//TODO: if the field contains the same prefix as the resource, remove the prefix (e.g. `/msixPackages/` and `package_family_name`)

//TODO: if the field is named `id` within a block rename it to `{block}_id`

//TODO: fields containing discriminators - for now we should skip the resource/raise an error if there's a discriminator involved
//TODO: when the field `properties` is a reference to a model, move fields from the 'properties' model up into the parent model
//TODO: handling the top level field `sku`
//TODO: if there's multiple fields with the same prefix, should we put these into a block?
//TODO: maybe done? if the model contains a single model, eliminate the wrapper model
