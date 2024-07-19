// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package combine

import (
	"fmt"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func Models(first map[string]sdkModels.SDKModel, second map[string]sdkModels.SDKModel) (map[string]sdkModels.SDKModel, error) {
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

	return output, nil
}
