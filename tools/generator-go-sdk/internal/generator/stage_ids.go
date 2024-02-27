// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package generator

import (
	"fmt"
	"github.com/hashicorp/go-hclog"
	"strings"
)

func (s *ServiceGenerator) ids(data ServiceGeneratorData, logger hclog.Logger) error {
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
		if err := s.writeToPathForResource(outputDirectory, fmt.Sprintf("id_%s.go", fileNamePrefix), pt, data, logger); err != nil {
			return fmt.Errorf("templating ids: %+v", err)
		}

		tpt := resourceIdTestsTemplater{
			resourceName:    idName,
			resourceData:    resourceData,
			constantDetails: data.constants,
		}
		if err := s.writeToPathForResource(outputDirectory, fmt.Sprintf("id_%s_test.go", fileNamePrefix), tpt, data, logger); err != nil {
			return fmt.Errorf("templating tests for id: %+v", err)
		}
	}

	return nil
}
