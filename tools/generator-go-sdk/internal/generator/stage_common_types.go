// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package generator

import (
	"fmt"
	"strings"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

func (s *ServiceGenerator) commonTypes(data VersionGeneratorData) error {
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

	return nil
}
