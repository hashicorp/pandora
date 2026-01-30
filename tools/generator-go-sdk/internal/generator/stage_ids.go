// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package generator

import (
	"fmt"
	"strings"
)

func (s *Generator) ids(data GeneratorData) error {
	outputDirectory := data.resourceOutputPath

	for idName, resourceData := range data.resourceIds {
		if resourceData.CommonIDAlias != nil || len(resourceData.Segments) == 0 {
			continue
		}

		nameWithoutSuffix := strings.TrimSuffix(idName, "Id") // we suffix 'Id' and 'ID' in places
		fileNamePrefix := strings.ToLower(nameWithoutSuffix)
		pt := resourceIdTemplater{
			name:            idName,
			resource:        resourceData,
			constantDetails: data.constants,
		}
		if err := s.writeToPathForResource(outputDirectory, fmt.Sprintf("id_%s.go", fileNamePrefix), &pt, data); err != nil {
			return fmt.Errorf("templating ids: %+v", err)
		}

		tpt := resourceIdTestsTemplater{
			resourceName:    pt.name,
			resourceData:    pt.resource,
			constantDetails: pt.constantDetails,
		}
		if err := s.writeToPathForResource(outputDirectory, fmt.Sprintf("id_%s_test.go", fileNamePrefix), &tpt, data); err != nil {
			return fmt.Errorf("templating tests for id: %+v", err)
		}
	}

	return nil
}
