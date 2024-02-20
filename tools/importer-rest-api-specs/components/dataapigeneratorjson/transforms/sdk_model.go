package transforms

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/dataapimodels"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

func MapSDKModelToRepository(modelName string, model resourcemanager.ModelDetails, parentModel *resourcemanager.ModelDetails, knownConstants map[string]resourcemanager.ConstantDetails, knownModels map[string]resourcemanager.ModelDetails) (*dataapimodels.Model, error) {
	if len(model.Fields) == 0 {
		return nil, fmt.Errorf("the model %q has no fields", modelName)
	}

	fields, err := mapSDKFieldsForModel(model, parentModel, knownConstants, knownModels)
	if err != nil {
		return nil, fmt.Errorf("mapping fields for model %q: %+v", modelName, err)
	}

	dataApiModel := dataapimodels.Model{
		Name:   modelName,
		Fields: *fields,
	}

	// NOTE: `Parent` types don't get a `TypeHintIn` or `TypeHintValue`
	// meaning that only
	if model.ParentTypeName != nil {
		dataApiModel.DiscriminatedParentModelName = model.ParentTypeName
	}
	if model.TypeHintValue != nil {
		dataApiModel.DiscriminatedTypeValue = model.TypeHintValue
	}

	if model.TypeHintIn != nil {
		dataApiModel.TypeHintIn = model.TypeHintIn
	}

	return &dataApiModel, nil
}

func mapSDKFieldsForModel(model resourcemanager.ModelDetails, parentModel *resourcemanager.ModelDetails, knownConstants map[string]resourcemanager.ConstantDetails, knownModels map[string]resourcemanager.ModelDetails) (*[]dataapimodels.ModelField, error) {
	// ensure consistency in the output
	sortedFieldNames := make([]string, 0)
	for fieldName := range model.Fields {
		sortedFieldNames = append(sortedFieldNames, fieldName)
	}
	sort.Strings(sortedFieldNames)

	fields := make([]dataapimodels.ModelField, 0)

	for _, fieldName := range sortedFieldNames {
		// we should skip outputting this field if it's present on the parent
		fieldInParent := false
		if parentModel != nil {
			// the importer flattens fields from parents/AllOf, since we don't use inheritance for that within the
			// data layer - as such we only want to skip the fields when the parent type is output, e.g. when there's
			// a discriminator involved
			for name := range parentModel.Fields {
				if strings.EqualFold(name, fieldName) {
					fieldInParent = true
					break
				}
			}
		}
		if fieldInParent {
			continue
		}

		field := model.Fields[fieldName]
		isTypeHint := model.TypeHintIn != nil && strings.EqualFold(*model.TypeHintIn, fieldName)
		fieldCode, err := mapSDKFieldToRepository(fieldName, field, isTypeHint, knownConstants, knownModels)
		if err != nil {
			return nil, fmt.Errorf("generating code for field %q: %+v", fieldName, err)
		}

		fields = append(fields, *fieldCode)
	}

	return &fields, nil
}
