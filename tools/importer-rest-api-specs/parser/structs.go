package parser

import (
	"fmt"
	"reflect"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

type parseResult struct {
	constants map[string]models.ConstantDetails
	models    map[string]models.ModelDetails
}

func (r *parseResult) append(other parseResult) error {
	if r.constants == nil {
		r.constants = make(map[string]models.ConstantDetails)
	}
	if err := r.appendConstants(other.constants); err != nil {
		return fmt.Errorf("appending constants: %+v", err)
	}

	if r.models == nil {
		r.models = make(map[string]models.ModelDetails)
	}
	if err := r.appendModels(other.models); err != nil {
		return fmt.Errorf("appending models: %+v", err)
	}

	return nil
}

func (r *parseResult) appendConstants(other map[string]models.ConstantDetails) error {
	for k, v := range other {
		existing, hasExisting := r.constants[k]
		if !hasExisting {
			r.constants[k] = v
			continue
		}

		if v.FieldType != existing.FieldType {
			return fmt.Errorf("conflicting constant %q with different types - first type %q - second type %q", k, string(existing.FieldType), string(v.FieldType))
		}

		if !reflect.DeepEqual(existing.Values, v.Values) {
			return fmt.Errorf("conflicting constant %q with different values. First: %+v. Second: %+v", k, existing.Values, v.Values)
		}
	}

	return nil
}

func (r *parseResult) appendModels(other map[string]models.ModelDetails) error {
	for k, v := range other {
		existing, hasExisting := r.models[k]
		if !hasExisting {
			r.models[k] = v
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
		if existing.Description != v.Description {
			return fmt.Errorf("descriptions don't match - first %q - second %q", existing.Description, v.Description)
		}
		if !reflect.DeepEqual(existing.Fields, v.Fields) {
			return fmt.Errorf("different model objects. First fields: %+v. Second fields: %+v", existing.Fields, v.Fields)
		}
	}

	return nil
}

func compareNilableString(first *string, second *string) error {
	if first != nil {
		if second == nil {
			return fmt.Errorf("first value was %q but second value was nil", *first)
		}

		if *first != *second {
			return fmt.Errorf("first value was %q but second value was %q", *first, *second)
		}
	}

	if second != nil {
		return fmt.Errorf("first value was nil but second value was %q", *second)
	}

	return nil
}
