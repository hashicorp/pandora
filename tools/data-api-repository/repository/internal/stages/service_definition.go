// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package stages

import (
	"fmt"
	"path/filepath"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api-repository/repository/internal/helpers"
	"github.com/hashicorp/pandora/tools/data-api-repository/repository/internal/transforms"
	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ Stage = &ServiceDefinitionStage{}

type ServiceDefinitionStage struct {
	// Service specifies the Service Definition
	Service sdkModels.Service
}

func (g *ServiceDefinitionStage) Generate(input *helpers.FileSystem, logger hclog.Logger) error {
	serviceDefinition, err := transforms.MapServiceDefinitionToRepository(g.Service)
	if err != nil {
		return fmt.Errorf("mapping Service Definition for %q: %+v", g.Service.Name, err)
	}

	path := filepath.Join("ServiceDefinition.json")
	if err := input.Stage(path, *serviceDefinition); err != nil {
		return fmt.Errorf("staging ServiceDefinition to %q: %+v", path, err)
	}

	return nil
}

func (g *ServiceDefinitionStage) Name() string {
	return "Service Definition"
}
