// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package generator

import (
	"fmt"
	"github.com/hashicorp/go-hclog"
)

func (s *ServiceGenerator) constants(data ServiceGeneratorData, logger hclog.Logger) error {
	if len(data.constants) == 0 {
		return nil
	}

	t := constantsTemplater{
		constantTemplateFunc: templateForConstant,
	}
	if err := s.writeToPathForResource(data.resourceOutputPath, "constants.go", t, data, logger); err != nil {
		return fmt.Errorf("templating constants: %+v", err)
	}

	return nil
}
