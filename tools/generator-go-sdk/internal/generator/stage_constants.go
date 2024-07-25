// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package generator

import (
	"fmt"
)

func (s *ServiceGenerator) constants(data GeneratorData) error {
	if len(data.constants) == 0 {
		return nil
	}

	t := constantsTemplater{
		constantTemplateFunc: templateForConstant,
	}
	if err := s.writeToPathForResource(data.resourceOutputPath, "constants.go", t, data); err != nil {
		return fmt.Errorf("templating constants: %+v", err)
	}

	return nil
}
