// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package generator

import (
	"fmt"
	"github.com/hashicorp/go-hclog"
)

func (s *ServiceGenerator) clients(data ServiceGeneratorData, logger hclog.Logger) error {
	if data.useNewBaseLayer {
		if err := s.writeToPathForResource(data.resourceOutputPath, "client.go", clientsTemplater{}, data, logger); err != nil {
			return fmt.Errorf("templating client (using hashicorp/go-azure-sdk): %+v", err)
		}
	} else {
		if err := s.writeToPathForResource(data.resourceOutputPath, "client.go", clientsAutoRestTemplater{}, data, logger); err != nil {
			return fmt.Errorf("templating client (using autorest): %+v", err)
		}
	}

	return nil
}
