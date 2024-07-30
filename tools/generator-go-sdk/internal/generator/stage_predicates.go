// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package generator

import (
	"fmt"
	"sort"
)

func (s *ServiceGenerator) predicates(data GeneratorData) error {
	modelNames := make(map[string]string)
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

		modelNameWithPackage := *operation.ResponseObject.ReferenceName
		if operation.ResponseObject.ReferenceNameIsCommonType != nil && *operation.ResponseObject.ReferenceNameIsCommonType {
			if data.commonTypesPackageName == nil {
				return fmt.Errorf("building predicate models: encountered a common model %q but `commonTypesPackageName` was nil", *operation.ResponseObject.ReferenceName)
			}
			modelNameWithPackage = fmt.Sprintf("%s.%s", *data.commonTypesPackageName, modelNameWithPackage)
		}

		modelNames[*operation.ResponseObject.ReferenceName] = modelNameWithPackage
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
		modelNames:       modelNames,
		sortedModelNames: sortedModelNames,
		models:           data.models,
	}
	if err := s.writeToPathForResource(data.resourceOutputPath, "predicates.go", templater, data); err != nil {
		return fmt.Errorf("templating predicate models: %+v", err)
	}

	return nil
}
