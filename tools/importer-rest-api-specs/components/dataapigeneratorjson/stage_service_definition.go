package dataapigeneratorjson

import (
	"fmt"
	"path/filepath"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/dataapigeneratorjson/transforms"
)

var _ generatorStage = generateServiceDefinitionStage{}

type generateServiceDefinitionStage struct {
	serviceName             string
	resourceProvider        *string
	shouldGenerate          bool
	terraformServicePackage *string
	terraformResourceNames  []string
}

func (g generateServiceDefinitionStage) generate(input *fileSystem, logger hclog.Logger) error {
	serviceDefinition, err := transforms.MapServiceDefinitionToRepository(g.serviceName, g.resourceProvider, g.terraformServicePackage, g.terraformResourceNames)
	if err != nil {
		return fmt.Errorf("mapping Service Definition for %q: %+v", g.serviceName, err)
	}

	path := filepath.Join(g.serviceName, "ServiceDefinition.json")
	if err := input.stage(path, *serviceDefinition); err != nil {
		return fmt.Errorf("staging ServiceDefinition to %q: %+v", path, err)
	}

	return nil
}

func (g generateServiceDefinitionStage) name() string {
	return "Service Definition"
}
