// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package generator

import (
	"fmt"
)

func (s *Generator) version(data GeneratorData) error {
	if err := s.writeToPathForResource(data.resourceOutputPath, "version.go", versionTemplater{}, data); err != nil {
		return fmt.Errorf("templating version: %+v", err)
	}

	return nil
}
