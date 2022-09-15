package internal

import (
	"fmt"
	"reflect"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

type ParseResult struct {
	Constants map[string]resourcemanager.ConstantDetails
	Models    map[string]models.ModelDetails
}

func (r *ParseResult) Append(other ParseResult) error {
	if r.Constants == nil {
		r.Constants = make(map[string]resourcemanager.ConstantDetails)
	}
	if err := r.AppendConstants(other.Constants); err != nil {
		return fmt.Errorf("appending constants: %+v", err)
	}

	if r.Models == nil {
		r.Models = make(map[string]models.ModelDetails)
	}
	if err := r.AppendModels(other.Models); err != nil {
		return fmt.Errorf("appending models: %+v", err)
	}

	return nil
}

func (r *ParseResult) AppendConstants(other map[string]resourcemanager.ConstantDetails) error {
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

func (r *ParseResult) AppendModels(other map[string]models.ModelDetails) error {
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
