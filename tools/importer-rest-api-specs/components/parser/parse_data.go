// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package parser

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/helpers"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser/resourceids"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func combineResourcesWith(first importerModels.AzureApiDefinition, other map[string]sdkModels.APIResource) (*map[string]sdkModels.APIResource, error) {
	resources := make(map[string]sdkModels.APIResource)
	for k, v := range first.Resources {
		resources[k] = v
	}

	for k, v := range other {
		existing, ok := resources[k]
		if !ok {
			resources[k] = v
			continue
		}

		constants, err := combineConstants(existing.Constants, v.Constants)
		if err != nil {
			return nil, fmt.Errorf("combining constants: %+v", err)
		}
		existing.Constants = *constants

		models, err := combineModels(existing.Models, v.Models)
		if err != nil {
			return nil, fmt.Errorf("combining models: %+v", err)
		}
		existing.Models = *models

		operations, err := combineOperations(existing.Operations, v.Operations)
		if err != nil {
			return nil, fmt.Errorf("combining operations: %+v", err)
		}
		existing.Operations = *operations

		resourceIds, err := combineResourceIds(existing.ResourceIDs, v.ResourceIDs)
		if err != nil {
			return nil, fmt.Errorf("combining resource ids: %+v", err)
		}
		existing.ResourceIDs = *resourceIds

		resources[k] = existing
	}

	return &resources, nil
}

func combineConstants(first, second map[string]sdkModels.SDKConstant) (*map[string]sdkModels.SDKConstant, error) {
	constants := make(map[string]sdkModels.SDKConstant)
	for k, v := range first {
		constants[k] = v
	}

	for k, v := range second {
		existingConst, ok := constants[k]
		if !ok {
			constants[k] = v
			continue
		}

		if existingConst.Type != v.Type {
			return nil, fmt.Errorf("combining constant %q - multiple field types defined as %q and %q", k, string(existingConst.Type), string(v.Type))
		}

		vals, err := combineMaps(existingConst.Values, v.Values)
		if err != nil {
			return nil, fmt.Errorf("combining maps: %+v", err)
		}
		existingConst.Values = *vals
		constants[k] = existingConst
	}

	return &constants, nil
}

func combineModels(first map[string]sdkModels.SDKModel, second map[string]sdkModels.SDKModel) (*map[string]sdkModels.SDKModel, error) {
	output := make(map[string]sdkModels.SDKModel)

	for k, v := range first {
		output[k] = v
	}

	for k, v := range second {
		existing, ok := output[k]
		if ok && len(existing.Fields) != len(v.Fields) {
			return nil, fmt.Errorf("duplicate models named %q with different fields - first %d - second %d", k, len(existing.Fields), len(v.Fields))
		}
		output[k] = v
	}

	// once we've combined the models for a resource and de-duplicated them, we will iterate over all of them to link any
	// orphaned discriminated models to their parent
	for k, v := range output {
		// this model is an implementation, so we need to find/update the parent
		if v.ParentTypeName != nil && v.FieldNameContainingDiscriminatedValue != nil && v.DiscriminatedValue != nil {
			parent, ok := output[*v.ParentTypeName]
			if !ok {
				return nil, fmt.Errorf("no parent definition %q found for implementation %q", *v.ParentTypeName, k)
			}
			// discriminated models that are defined in a separate file with no reference to a path/tag/resource ID
			// will not be found when we parse the parent, as a result the parent's TypeHintIn is set to nil,
			// here we set the information back into the parent after we've found the implementation
			if parent.FieldNameContainingDiscriminatedValue == nil {
				parent.FieldNameContainingDiscriminatedValue = v.FieldNameContainingDiscriminatedValue
			}
			output[*v.ParentTypeName] = parent
		}
	}

	return &output, nil
}

func combineOperations(first map[string]sdkModels.SDKOperation, second map[string]sdkModels.SDKOperation) (*map[string]sdkModels.SDKOperation, error) {
	output := make(map[string]sdkModels.SDKOperation, 0)

	for k, v := range first {
		output[k] = v
	}

	for k, v := range second {
		// if there's duplicate operations named the same thing in different Swaggers, this is likely a data issue
		_, ok := output[k]
		if ok {
			return nil, fmt.Errorf("duplicate operations named %q", k)
		}

		output[k] = v
	}

	return &output, nil
}

func combineResourceIds(first map[string]sdkModels.ResourceID, second map[string]sdkModels.ResourceID) (*map[string]sdkModels.ResourceID, error) {
	output := make(map[string]sdkModels.ResourceID)

	for k, v := range first {
		output[k] = v
	}

	for k, v := range second {
		// if there's duplicate Resource ID's named the same thing in different Swaggers, this is likely a data issue
		otherVal, ok := output[k]
		if ok && !resourceids.ResourceIdsMatch(v, otherVal) {
			return nil, fmt.Errorf("duplicate Resource ID named %q (First %q / Second %q)", k, helpers.DisplayValueForResourceID(v), helpers.DisplayValueForResourceID(otherVal))
		}

		output[k] = v
	}

	return &output, nil
}

func combineMaps(first map[string]string, second map[string]string) (*map[string]string, error) {
	vals := make(map[string]string, 0)
	for k, v := range first {
		vals[k] = v
	}
	for k, v := range second {
		existing, ok := vals[k]
		if !ok {
			vals[k] = v
			continue
		}

		if existing != v {
			return nil, fmt.Errorf("duplicate key %q with different value - first %q - second %q", k, existing, v)
		}
	}

	return &vals, nil
}
