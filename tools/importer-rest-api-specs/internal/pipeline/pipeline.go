// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package pipeline

import (
	"github.com/hashicorp/pandora/tools/data-api-repository/repository"
	"github.com/hashicorp/pandora/tools/sdk/config/definitions"
	"github.com/hashicorp/pandora/tools/sdk/config/services"
)

type Pipeline struct {
	opts                           Options
	repository                     repository.Repository
	servicesFromConfigurationFiles []services.Service
	servicesToTerraformDetails     map[string]terraformDetailsForService
}

type terraformDetailsForService struct {
	resourceLabelToResourceDefinitions map[string]definitions.ResourceDefinition
	terraformPackageName               *string
}
