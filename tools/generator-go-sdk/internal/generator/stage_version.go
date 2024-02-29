// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package generator

import (
	"fmt"
)

func (s *ServiceGenerator) version(data ServiceGeneratorData) error {
	if err := s.writeToPathForResource(data.resourceOutputPath, "version.go", versionTemplater{}, data); err != nil {
		return fmt.Errorf("templating version: %+v", err)
	}

	return nil
}
