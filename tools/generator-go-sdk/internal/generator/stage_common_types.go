// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package generator

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func (s *Generator) commonTypes(data VersionGeneratorData) error {
	if len(data.commonTypes.Constants) == 0 && len(data.commonTypes.Models) == 0 {
		return nil
	}

	data.packageName = data.versionPackageName

	// output constants into individual files
	for constantName, constant := range data.commonTypes.Constants {
		t := constantsTemplater{
			constantTemplateFunc: templateForConstant,
		}
		constantData := data.GeneratorData
		constantData.constants = map[string]models.SDKConstant{
			constantName: constant,
		}
		fileName := fmt.Sprintf("constant_%s.go", strings.ToLower(constantName))
		if err := s.writeToPathForResource(data.commonTypesOutputPath, fileName, t, constantData); err != nil {
			return fmt.Errorf("templating constants: %+v", err)
		}
	}

	for modelName, model := range data.commonTypes.Models {
		fileName := fmt.Sprintf("model_%s.go", strings.ToLower(modelName))
		gen := modelsTemplater{
			name:  modelName,
			model: model,
		}

		if err := s.writeToPathForResource(data.commonTypesOutputPath, fileName, gen, data.GeneratorData); err != nil {
			return fmt.Errorf("templating model for %q: %+v", modelName, err)
		}
	}

	for idName, resourceData := range data.commonTypes.ResourceIDs {
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
		if err := s.writeToPathForResource(data.commonTypesOutputPath, fmt.Sprintf("id_%s.go", fileNamePrefix), &pt, data.GeneratorData); err != nil {
			return fmt.Errorf("templating ids: %+v", err)
		}

		tpt := resourceIdTestsTemplater{
			resourceName:    idName,
			resourceData:    resourceData,
			constantDetails: data.constants,
		}
		if err := s.writeToPathForResource(data.commonTypesOutputPath, fmt.Sprintf("id_%s_test.go", fileNamePrefix), &tpt, data.GeneratorData); err != nil {
			return fmt.Errorf("templating tests for id: %+v", err)
		}
	}
	return nil
}
