package models

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

func (r *ParseResult) IsObjectKnown(name string) (bool, bool) {
	_, isConstant := r.Constants[name]
	_, isModel := r.Models[name]
	return isConstant, isModel
}

func compareFields(first map[string]sdkModels.SDKField, second map[string]sdkModels.SDKField) error {
	if len(first) != len(second) {
		return fmt.Errorf("first had %d fields but second had %d fields", len(first), len(second))
	}

	for k := range first {
		firstVal := first[k]
		// Keys aren't normalised until processing is completed, so we need to insensitively look for this
		secondVal, ok := itemForKeyInsensitively(second, k)
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

func itemForKeyInsensitively[T any](input map[string]T, key string) (*T, bool) {
	// if we've got it case-sensitively then save the effort of iterating over all the keys
	val, ok := input[key]
	if ok {
		return &val, true
	}

	for k, v := range input {
		if strings.EqualFold(k, key) {
			return &v, true
		}
	}

	return nil, false
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
	if !strings.EqualFold(pointer.From(first.ReferenceName), pointer.From(second.ReferenceName)) {
		return fmt.Errorf("value for ReferenceName differs.\n\nFirst was %q but second was %q", pointer.From(first.ReferenceName), pointer.From(second.ReferenceName))
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

func compareNilableString(first, second *string) error {
	firstVal := pointer.From(first)
	secondValue := pointer.From(second)
	if firstVal != secondValue {
		return fmt.Errorf("the first value %q didn't match the second value %q", firstVal, secondValue)
	}

	return nil
}
