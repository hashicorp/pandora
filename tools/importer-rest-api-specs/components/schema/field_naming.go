package schema

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

type fieldNameMatcher interface {
	updatedNameForField(input string, model *resourcemanager.ModelDetails, resource *resourcemanager.TerraformResourceDetails) *string
}

var namingRules = []fieldNameMatcher{
	fieldNameFlattenReferenceId{},
	fieldNameIs{},
	fieldNamePluralToSingular{},
	fieldNameRemoveResourcePrefix{},
	fieldNameRenameBoolean{},
}

type fieldNameIs struct{}

func (fieldNameIs) updatedNameForField(input string, model *resourcemanager.ModelDetails, _ *resourcemanager.TerraformResourceDetails) *string {
	if strings.HasPrefix(strings.ToLower(input), "is_") {
		updatedName := input[3:]
		return &updatedName
	}
	return nil
}

type fieldNamePluralToSingular struct{}

func (fieldNamePluralToSingular) updatedNameForField(input string, model *resourcemanager.ModelDetails, _ *resourcemanager.TerraformResourceDetails) *string {
	if model.Fields[input].ObjectDefinition.Type == resourcemanager.ListApiObjectDefinitionType {
		if strings.HasSuffix(input, "s") && !strings.HasSuffix(input, "ss") {
			updatedName := strings.TrimSuffix(input, "s")
			return &updatedName
		}
	}
	return nil
}

type fieldNameRenameBoolean struct{}

func (fieldNameRenameBoolean) updatedNameForField(input string, model *resourcemanager.ModelDetails, _ *resourcemanager.TerraformResourceDetails) *string {
	if model.Fields[input].ObjectDefinition.Type == resourcemanager.BooleanApiObjectDefinitionType {
		var updatedFieldName *string
		// flip `enable_X` / `disable_X` prefix
		if strings.HasPrefix(strings.ToLower(input), "enable") {
			updated := fmt.Sprintf("%sEnabled", input[6:])
			updatedFieldName = &updated
		}
		if strings.HasPrefix(strings.ToLower(input), "disable") {
			updated := fmt.Sprintf("%sDisabled", input[7:])
			updatedFieldName = &updated
		}
		// change `allow_X` prefix -> `X_enabled`
		if strings.HasPrefix(strings.ToLower(input), "allow") {
			updated := fmt.Sprintf("%sEnabled", input[5:])
			updatedFieldName = &updated
		}
		// change `allowed_X` prefix -> `X_enabled`
		if strings.HasPrefix(strings.ToLower(input), "allowed") {
			updated := fmt.Sprintf("%sEnabled", input[7:])
			updatedFieldName = &updated
		}
		return updatedFieldName
	}
	return nil
}

type fieldNameRemoveResourcePrefix struct{}

func (fieldNameRemoveResourcePrefix) updatedNameForField(input string, _ *resourcemanager.ModelDetails, resource *resourcemanager.TerraformResourceDetails) *string {
	if strings.HasPrefix(input, resource.ResourceName) {
		updatedName := strings.Replace(input, resource.ResourceName, "", 1)
		return &updatedName
	}
	return nil
}

type fieldNameFlattenReferenceId struct{}

func (fieldNameFlattenReferenceId) updatedNameForField(input string, model *resourcemanager.ModelDetails, _ *resourcemanager.TerraformResourceDetails) *string {
	if model.Fields[input].ObjectDefinition.Type == resourcemanager.ReferenceApiObjectDefinitionType {
		model.Fields[input].ObjectDefinition.ReferenceName
		if ok {
			if len(model.Fields) == 1 {
				if _, ok := getField(model, "Id"); ok {
					return fmt.Sprintf("%sId", fieldName)
				}
			}
		}
	}
	return nil
}

func checkIfFieldExists(fieldName string, model *resourcemanager.ModelDetails) error {
	_, ok := getField(*model, fieldName)
	if !ok {
		return fmt.Errorf("%s was not found in %+v", fieldName, model.Fields)
	}
	return nil
}

// determineNameForSchemaField takes the name of the field in the model, with the model as context, to be able
// to determine which name should be used for this model, following conventions, before snake_casing it.
//
// this also accounts for flattening particular objects, for example when a field references a model with
// a single field named `Id`, we'll flatten the parent field to `name_id`.
func (b Builder) determineNameForSchemaField(input resourcemanager.ModelDetails, fieldName string) string {
	field, ok := getField(input, fieldName)
	if !ok {
		// TODO: tbh we should probably error but I guess we can safe-check this for now..
		return fieldName
	}

	// remove the `is_` prefix (e.g. `is_active` -> `active`)
	if strings.HasPrefix(strings.ToLower(fieldName), "is") {
		trimmed := fieldName[2:]
		return trimmed
	}

	// flip `enable_X` / `disable_X` prefix
	if strings.HasPrefix(strings.ToLower(fieldName), "enable") {
		trimmed := fieldName[6:]
		return fmt.Sprintf("%sEnabled", trimmed)
	}
	if strings.HasPrefix(strings.ToLower(fieldName), "disable") {
		trimmed := fieldName[7:]
		return fmt.Sprintf("%sDisabled", trimmed)
	}

	// change `allowed_X` prefix -> `X_enabled`
	if strings.HasPrefix(strings.ToLower(fieldName), "allowed") {
		trimmed := fieldName[7:]
		return fmt.Sprintf("%sEnabled", trimmed)
	}
	// change `allow_X` prefix -> `X_enabled`
	if strings.HasPrefix(strings.ToLower(fieldName), "allow") {
		trimmed := fieldName[5:]
		return fmt.Sprintf("%sEnabled", trimmed)
	}

	// if it's a Reference and the model contains a single field `Id` then flatten this into an `_id` field.
	if field.ObjectDefinition.Type == resourcemanager.ReferenceApiObjectDefinitionType {
		model, ok := b.models[*field.ObjectDefinition.ReferenceName]
		if ok {
			if len(model.Fields) == 1 {
				if _, ok := getField(model, "Id"); ok {
					return fmt.Sprintf("%sId", fieldName)
				}
			}
		}
	}

	// TODO: if it's a List[Reference] and the model contains a single field `Id` then flatten this into `_ids`.
	// TODO: handling booleans `SomeBool` -> `SomeBoolEnabled` etc.
	// TODO: Singularizing plural names when it's a List (e.g. `planets` -> `planet`)
	// TODO: handle `is_XXX` -> `XXX`
	// TODO: if the field contains the same prefix as the resource, remove the prefix (e.g. `/msixPackages/` and `package_family_name`)
	// TODO: if there's multiple fields with the same prefix, should we put these into a block?
	// TODO: fields containing discriminators
	// TODO: if the model contains a single model, eliminate the wrapper model
	// TODO: if the field is named `id` within a block rename it to `{block}_id`

	return fieldName
}
