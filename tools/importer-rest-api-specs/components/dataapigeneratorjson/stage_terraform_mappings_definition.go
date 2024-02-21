package dataapigeneratorjson

import (
	"fmt"
	"path/filepath"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigeneratorjson/transforms"
	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ generatorStage = generateTerraformMappingsDefinitionStage{}

type generateTerraformMappingsDefinitionStage struct {
	serviceName     string
	resourceLabel   string
	resourceDetails resourcemanager.TerraformResourceDetails
}

func (g generateTerraformMappingsDefinitionStage) generate(input *fileSystem, logger hclog.Logger) error {
	mapped, err := transforms.MapTerraformSchemaMappingsToRepository(g.resourceDetails.Mappings)
	if err != nil {
		return fmt.Errorf("building Mappings for the Terraform Resource %q: %+v", g.resourceLabel, err)
	}

	path := filepath.Join(g.serviceName, "Terraform", fmt.Sprintf("%s-Resource-Mappings.json", g.resourceDetails.ResourceName))
	logger.Trace(fmt.Sprintf("Staging Terraform Mappings to %q", path))
	if err := input.stage(path, *mapped); err != nil {
		return fmt.Errorf("staging Terraform Mappings to %q: %+v", path, err)
	}

	return nil
}

func (g generateTerraformMappingsDefinitionStage) name() string {
	return "Terraform Mappings Definition"
}
