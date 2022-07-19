package main

import (
	"fmt"
	"path/filepath"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/config/definitions"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/parser"
	"github.com/hashicorp/pandora/tools/sdk/config/services"
)

type RunInput struct {
	RootNamespace              string
	ServiceName                string
	ApiVersion                 string
	OutputDirectory            string
	ResourceProvider           *string
	SwaggerDirectory           string
	SwaggerFiles               []string
	TerraformServiceDefinition *definitions.ServiceDefinition
}

type ResourceManagerInput struct {
	ServiceName                string
	ApiVersion                 string
	ResourceProvider           string
	SwaggerDirectory           string
	SwaggerFiles               []string
	TerraformServiceDefinition *definitions.ServiceDefinition
}

func (rmi ResourceManagerInput) ToRunInput() RunInput {
	return RunInput{
		RootNamespace:              "Pandora.Definitions.ResourceManager",
		ServiceName:                rmi.ServiceName,
		ApiVersion:                 rmi.ApiVersion,
		ResourceProvider:           &rmi.ResourceProvider,
		OutputDirectory:            outputDirectory,
		SwaggerDirectory:           rmi.SwaggerDirectory,
		SwaggerFiles:               rmi.SwaggerFiles,
		TerraformServiceDefinition: rmi.TerraformServiceDefinition,
	}
}

func GenerationData(configFilePath, swaggerDirectory string, terraformConfig definitions.Config, debug bool) (*[]RunInput, error) {
	parsed, err := services.LoadFromFile(configFilePath)
	if err != nil {
		return nil, fmt.Errorf("loading config: %+v", err)
	}

	specificationsDirectory := filepath.Join(swaggerDirectory, "specification")
	resourceManagerServices, err := parser.FindResourceManagerServices(specificationsDirectory, debug)
	if err != nil {
		return nil, fmt.Errorf("retrieving Resource Manager Service details from %q: %+v", specificationsDirectory, err)
	}

	output := make([]RunInput, 0)
	for _, service := range parsed.Services {
		// find the versions for each directory within this Service
		serviceDetails, ok := (*resourceManagerServices)[service.Directory]
		if !ok {
			return nil, fmt.Errorf("details for the Service %q were not found - does it exist on disk?", service.Directory)
		}

		for _, version := range service.Available {
			versionDetails, ok := serviceDetails.ApiVersionPaths[version]
			if !ok {
				return nil, fmt.Errorf("details for the Version %q of Service %q were not found - does it exist on disk?", version, service.Directory)
			}
			versionDirectory := filepath.Join(swaggerDirectory + "/specification/" + versionDetails)
			filesForVersion := make([]string, 0)
			filesInDirectory, err := parser.SwaggerFilesInDirectory(versionDirectory)
			if err != nil {
				return nil, fmt.Errorf("finding the swagger files within %q: %+v", versionDirectory, err)
			}
			for _, file := range *filesInDirectory {
				fileWithoutPrefix := strings.TrimPrefix(file, versionDirectory)
				filesForVersion = append(filesForVersion, fileWithoutPrefix)
			}

			resourceManagerService := ResourceManagerInput{
				ServiceName:      service.Name,
				ApiVersion:       version,
				ResourceProvider: serviceDetails.ResourceProvider,
				SwaggerDirectory: versionDirectory,
				SwaggerFiles:     filesForVersion,
			}

			definition, ok := terraformConfig.Services[service.Name]
			if ok {
				resourceManagerService.TerraformServiceDefinition = &definition
			}

			output = append(output, resourceManagerService.ToRunInput())
		}
	}
	return &output, nil
}
