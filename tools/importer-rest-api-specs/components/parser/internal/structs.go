// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package internal

import (
	"fmt"
	"reflect"
	"strings"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	importerModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

type ParseResult struct {
	Constants map[string]models.SDKConstant
	Models    map[string]importerModels.ModelDetails
}

func (r *ParseResult) Append(other ParseResult) error {
	if r.Constants == nil {
		r.Constants = make(map[string]models.SDKConstant)
	}
	if err := r.AppendConstants(other.Constants); err != nil {
		return fmt.Errorf("appending constants: %+v", err)
	}

	if r.Models == nil {
		r.Models = make(map[string]importerModels.ModelDetails)
	}
	if err := r.AppendModels(other.Models); err != nil {
		return fmt.Errorf("appending models: %+v", err)
	}

	return nil
}

func (r *ParseResult) AppendConstants(other map[string]models.SDKConstant) error {
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

func (r *ParseResult) AppendModels(other map[string]importerModels.ModelDetails) error {
	for k, v := range other {
		existing, hasExisting := r.Models[k]
		if !hasExisting {
			r.Models[k] = v
			continue
		}

		if err := compareNilableString(existing.ParentTypeName, v.ParentTypeName); err != nil {
			return fmt.Errorf("comparing ParentTypeName: %+v", err)
		}
		if err := compareNilableString(existing.TypeHintIn, v.TypeHintIn); err != nil {
			return fmt.Errorf("comparing TypeHintIn: %+v", err)
		}
		if err := compareNilableString(existing.TypeHintValue, v.TypeHintValue); err != nil {
			return fmt.Errorf("comparing TypeHintValue: %+v", err)
		}

		if err := compareFields(existing.Fields, v.Fields); err != nil {
			return fmt.Errorf("different model objects for Model %q: %+v.\n\nFirst fields: %+v.\n\nSecond fields: %+v", k, err, existing.Fields, v.Fields)
		}
	}

	return nil
}

func compareFields(first map[string]importerModels.FieldDetails, second map[string]importerModels.FieldDetails) error {
	if len(first) != len(second) {
		return fmt.Errorf("first had %d fields but second had %d fields", len(first), len(second))
	}

	for k := range first {
		firstVal := first[k]
		secondVal, ok := second[k]
		if !ok {
			return fmt.Errorf("second didn't contain the key %q", k)
		}

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
			return fmt.Errorf("object definitions differ: %+v.\n\nFirst %q\n\nSecond %q", err, firstVal.ObjectDefinition, secondVal.ObjectDefinition)
		}
		if err := customFieldTypesMatch(firstVal.CustomFieldType, secondVal.CustomFieldType); err != nil {
			return fmt.Errorf("custom field types differ: %+v\n\nFirst %q\n\nSecond %q", err, firstVal.ObjectDefinition, secondVal.ObjectDefinition)
		}
		// NOTE: we're intentionally not checking Description at this time
	}

	return nil
}

func objectDefinitionsMatch(first *importerModels.ObjectDefinition, second *importerModels.ObjectDefinition) error {
	if first == nil && second == nil {
		return nil
	}
	if first != nil && second == nil {
		return fmt.Errorf("first was %q but second was nil", first.String())
	}
	if first == nil && second != nil {
		return fmt.Errorf("first was nil but second was %q", second.String())
	}
	if err := objectDefinitionsMatch(first.NestedItem, second.NestedItem); err != nil {
		return fmt.Errorf("nested items differ: %+v", err)
	}
	if first.Type != second.Type {
		return fmt.Errorf("first.Type was %q but second.Type was %q", string(first.Type), string(second.Type))
	}
	if err := compareNilableString(first.ReferenceName, second.ReferenceName); err != nil {
		return fmt.Errorf("value for ReferenceName differs: %+v\n\nFirst was %q but second was %q", err, pointer.From(first.ReferenceName), pointer.From(second.ReferenceName))
	}
	if err := compareNilableInteger(first.Maximum, second.Maximum); err != nil {
		return fmt.Errorf("value for Maximum differs: %+v\n\nFirst was %d but second was %d", err, pointer.From(first.Maximum), pointer.From(second.Maximum))
	}
	if err := compareNilableInteger(first.Minimum, second.Minimum); err != nil {
		return fmt.Errorf("value for Minimum differs: %+v\n\nFirst was %d but second was %d", err, pointer.From(first.Minimum), pointer.From(second.Minimum))
	}
	if err := compareNilableBoolean(first.UniqueItems, second.UniqueItems); err != nil {
		return fmt.Errorf("value for Unique Items differs: %+v\n\nFirst was %t but second was %t", err, pointer.From(first.UniqueItems), pointer.From(second.UniqueItems))
	}

	return nil
}

func customFieldTypesMatch(first *importerModels.CustomFieldType, second *importerModels.CustomFieldType) error {
	if first == nil && second == nil {
		return nil
	}
	if first != nil && second == nil {
		return fmt.Errorf("first was %q but second was nil", string(*first))
	}
	if first == nil && second != nil {
		return fmt.Errorf("first was nil but second was %q", string(*second))
	}

	if *first != *second {
		return fmt.Errorf("values differ - first was %q but second was %q", string(*first), string(*second))
	}

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

func compareNilableInteger(first *int, second *int) error {
	if first != nil {
		if second == nil {
			return fmt.Errorf("first value was %d but second value was nil", *first)
		}

		if *first != *second {
			return fmt.Errorf("first value was %d but second value was %d", *first, *second)
		}

		return nil
	}

	if second != nil {
		return fmt.Errorf("first value was nil but second value was %d", *second)
	}

	return nil
}

func compareNilableBoolean(first *bool, second *bool) error {
	if first != nil {
		if second == nil {
			return fmt.Errorf("first value was %t but second value was nil", *first)
		}

		if *first != *second {
			return fmt.Errorf("first value was %t but second value was %t", *first, *second)
		}

		return nil
	}

	if second != nil {
		return fmt.Errorf("first value was nil but second value was %t", *second)
	}

	return nil
}
