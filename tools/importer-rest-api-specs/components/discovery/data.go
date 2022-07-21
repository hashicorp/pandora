package discovery

import (
	"fmt"
	"path/filepath"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/pipeline"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/components/parser"

	"github.com/hashicorp/pandora/tools/sdk/config/definitions"
	"github.com/hashicorp/pandora/tools/sdk/config/services"
)

func FindServices(input pipeline.RunInput, terraformConfig definitions.Config) (*[]ServiceInput, error) {
	parsed, err := services.LoadFromFile(input.ConfigFilePath)
	if err != nil {
		return nil, fmt.Errorf("loading config: %+v", err)
	}

	specificationsDirectory := filepath.Join(input.SwaggerDirectory, "specification")
	resourceManagerServices, err := parser.FindResourceManagerServices(specificationsDirectory, input.Logger)
	if err != nil {
		return nil, fmt.Errorf("retrieving Resource Manager Service details from %q: %+v", specificationsDirectory, err)
	}

	output := make([]ServiceInput, 0)
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
			versionDirectory := filepath.Join(input.SwaggerDirectory + "/specification/" + versionDetails)
			filesForVersion := make([]string, 0)
			filesInDirectory, err := parser.SwaggerFilesInDirectory(versionDirectory)
			if err != nil {
				return nil, fmt.Errorf("finding the swagger files within %q: %+v", versionDirectory, err)
			}
			for _, file := range *filesInDirectory {
				fileWithoutPrefix := strings.TrimPrefix(file, versionDirectory)
				filesForVersion = append(filesForVersion, fileWithoutPrefix)
			}

			resourceManagerService := ResourceManagerServiceInput{
				ServiceName:      service.Name,
				ApiVersion:       version,
				ResourceProvider: serviceDetails.ResourceProvider,
				OutputDirectory:  input.OutputDirectory,
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
