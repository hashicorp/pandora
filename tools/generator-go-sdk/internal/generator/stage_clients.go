// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package generator

import (
	"fmt"
)

func (s *ServiceGenerator) clients(data GeneratorData) error {
	if data.useNewBaseLayer {
		if err := s.writeToPathForResource(data.resourceOutputPath, "client.go", clientsTemplater{}, data); err != nil {
			return fmt.Errorf("templating client (using hashicorp/go-azure-sdk): %+v", err)
		}
	} else {
		if err := s.writeToPathForResource(data.resourceOutputPath, "client.go", clientsAutoRestTemplater{}, data); err != nil {
			return fmt.Errorf("templating client (using autorest): %+v", err)
		}
	}

	return nil
}
