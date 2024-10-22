// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package generator

import (
	"fmt"
	"sort"
)

func (s *ServiceGenerator) predicates(data GeneratorData) error {
	modelNames := make(map[string]struct{}, 0)
	for _, operation := range data.operations {
		if operation.FieldContainingPaginationDetails == nil {
			continue
		}

		if operation.ResponseObject == nil {
			continue
		}

		if operation.ResponseObject.ReferenceName == nil {
			continue
		}

		modelNames[*operation.ResponseObject.ReferenceName] = struct{}{}
	}

	sortedModelNames := make([]string, 0)
	for k := range modelNames {
		sortedModelNames = append(sortedModelNames, k)
	}
	sort.Strings(sortedModelNames)

	if len(sortedModelNames) == 0 {
		return nil
	}

	templater := predicateTemplater{
		sortedModelNames: sortedModelNames,
		models:           data.models,
	}
	if err := s.writeToPathForResource(data.resourceOutputPath, "predicates.go", templater, data); err != nil {
		return fmt.Errorf("templating predicate models: %+v", err)
	}

	return nil
}
