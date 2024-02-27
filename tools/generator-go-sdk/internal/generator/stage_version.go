// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package generator

import (
	"fmt"

	"github.com/hashicorp/go-hclog"
)

func (s *ServiceGenerator) version(data ServiceGeneratorData, logger hclog.Logger) error {
	if err := s.writeToPathForResource(data.resourceOutputPath, "version.go", versionTemplater{}, data, logger); err != nil {
		return fmt.Errorf("templating version: %+v", err)
	}

	return nil
}
