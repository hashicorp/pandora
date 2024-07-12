// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package internal

import (
	"fmt"
	"reflect"
	"strings"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

type ParseResult struct {
	Constants map[string]sdkModels.SDKConstant
	Models    map[string]sdkModels.SDKModel
}

func (r *ParseResult) Append(other ParseResult) error {
	if r.Constants == nil {
		r.Constants = make(map[string]sdkModels.SDKConstant)
	}
	if err := r.AppendConstants(other.Constants); err != nil {
		return fmt.Errorf("appending constants: %+v", err)
	}

	if r.Models == nil {
		r.Models = make(map[string]sdkModels.SDKModel)
	}
	if err := r.AppendModels(other.Models); err != nil {
		return fmt.Errorf("appending models: %+v", err)
	}

	return nil
}

func (r *ParseResult) AppendConstants(other map[string]sdkModels.SDKConstant) error {
	for k, v := range other {
		existing, hasExisting := r.Constants[k]
		if !hasExisting {
			r.Constants[k] = v
			continue
		}

		if v.Type != existing.Type {
			return fmt.Errorf("conflicting constant %q with different types - first type %q - second type %q", k, string(existing.Type), string(v.Type))
		}

		if !reflect.DeepEqual(existing.Values, v.Values) {
			return fmt.Errorf("conflicting constant %q with different values. First: %+v. Second: %+v", k, existing.Values, v.Values)
		}
	}

	return nil
}

func (r *ParseResult) AppendModels(other map[string]sdkModels.SDKModel) error {
	for k, v := range other {
		existing, hasExisting := r.Models[k]
		if !hasExisting {
			r.Models[k] = v
			continue
		}

		if err := compareNilableString(existing.DiscriminatedValue, v.DiscriminatedValue); err != nil {
			return fmt.Errorf("comparing DiscriminatedValue: %+v", err)
		}
		if err := compareNilableString(existing.FieldNameContainingDiscriminatedValue, v.FieldNameContainingDiscriminatedValue); err != nil {
			return fmt.Errorf("comparing FieldNameContainingDiscriminatedValue: %+v", err)
		}
		if err := compareNilableString(existing.ParentTypeName, v.ParentTypeName); err != nil {
			return fmt.Errorf("comparing ParentTypeName: %+v", err)
		}

		if err := compareFields(existing.Fields, v.Fields); err != nil {
			return fmt.Errorf("different model objects for Model %q: %+v.\n\nFirst fields: %+v.\n\nSecond fields: %+v", k, err, existing.Fields, v.Fields)
		}
	}

	return nil
}

func compareFields(first map[string]sdkModels.SDKField, second map[string]sdkModels.SDKField) error {
	if len(first) != len(second) {
		return fmt.Errorf("first had %d fields but second had %d fields", len(first), len(second))
	}

	for k := range first {
		firstVal := first[k]
		secondVal, ok := second[k]
		if !ok {
			return fmt.Errorf("second didn't contain the key %q", k)
		}

		// TODO this can be uncommented when #3325 has been fixed
		//if firstVal.Description != secondVal.Description {
		//	return fmt.Errorf("first.Description was %q but second.Description was %q", firstVal.Description, secondVal.Description)
		//}
		if firstVal.JsonName != secondVal.JsonName {
			return fmt.Errorf("first.JsonName was %q but second.JsonName was %q", firstVal.JsonName, secondVal.JsonName)
		}
		if firstVal.Required != secondVal.Required {
			return fmt.Errorf("first.Required was %t but second.Required was %t", firstVal.Required, secondVal.Required)
		}
		if firstVal.Sensitive != secondVal.Sensitive {
			return fmt.Errorf("first.Sensitive was %t but second.Sensitive was %t", firstVal.Sensitive, secondVal.Sensitive)
		}
		if err := objectDefinitionsMatch(firstVal.ObjectDefinition, secondVal.ObjectDefinition); err != nil {
			return fmt.Errorf("object definitions differ: %+v.\n\nFirst %+v\n\nSecond %+v", err, firstVal.ObjectDefinition, secondVal.ObjectDefinition)
		}
	}

	return nil
}

func objectDefinitionsMatch(first, second sdkModels.SDKObjectDefinition) error {
	if first.NestedItem != nil && second.NestedItem == nil {
		return fmt.Errorf("`first` had a nested item but `second` didn't. First: %+v. Second: %+v", first, second)
	}
	if first.NestedItem == nil && second.NestedItem != nil {
		return fmt.Errorf("`second` had a nested item but `first` didn't. First: %+v. Second: %+v", first, second)
	}
	if first.NestedItem != nil && second.NestedItem != nil {
		if err := objectDefinitionsMatch(*first.NestedItem, *second.NestedItem); err != nil {
			return fmt.Errorf("nested items differ: %+v", err)
		}
	}
	if first.Type != second.Type {
		return fmt.Errorf("first.Type was %q but second.Type was %q", string(first.Type), string(second.Type))
	}
	if err := compareNilableString(first.ReferenceName, second.ReferenceName); err != nil {
		return fmt.Errorf("value for ReferenceName differs: %+v\n\nFirst was %q but second was %q", err, pointer.From(first.ReferenceName), pointer.From(second.ReferenceName))
	}

	// TODO: re-enable minimum/maximum/unique on Object Definition
	//if err := compareNilableInteger(first.Maximum, second.Maximum); err != nil {
	//	return fmt.Errorf("value for Maximum differs: %+v\n\nFirst was %d but second was %d", err, pointer.From(first.Maximum), pointer.From(second.Maximum))
	//}
	//if err := compareNilableInteger(first.Minimum, second.Minimum); err != nil {
	//	return fmt.Errorf("value for Minimum differs: %+v\n\nFirst was %d but second was %d", err, pointer.From(first.Minimum), pointer.From(second.Minimum))
	//}
	//if err := compareNilableBoolean(first.UniqueItems, second.UniqueItems); err != nil {
	//	return fmt.Errorf("value for Unique Items differs: %+v\n\nFirst was %t but second was %t", err, pointer.From(first.UniqueItems), pointer.From(second.UniqueItems))
	//}

	return nil
}

func compareNilableString(first *string, second *string) error {
	if first != nil {
		if second == nil {
			return fmt.Errorf("first value was %q but second value was nil", *first)
		}

		// @tombuildsstuff: the Azure API Definitions are wholy inconsistent here, so we'll case-insensitively
		// compare the references as they're normalized at the final stage
		//  * first value was "daprMetadata" but second value was "DaprMetadata"
		//  * first value was "status" but second value was "Status"
		//  * first value was "status" but second value was "Status"
		//  * first value was "DataProviderMetadata" but second value was "dataProviderMetadata"
		if !strings.EqualFold(*first, *second) {
			return fmt.Errorf("first value was %q but second value was %q", *first, *second)
		}

		return nil
	}

	if second != nil {
		return fmt.Errorf("first value was nil but second value was %q", *second)
	}

	return nil
}
