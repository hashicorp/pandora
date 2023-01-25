package discovery

import (
	"fmt"
	"path/filepath"
	"strings"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/sdk/config/definitions"
	"github.com/hashicorp/pandora/tools/sdk/config/services"
)

type FindServiceInput struct {
	ConfigFilePath   string
	OutputDirectory  string
	SwaggerDirectory string
	Logger           hclog.Logger
}

func FindServices(input FindServiceInput, terraformConfig definitions.Config) (*[]ServiceInput, error) {
	parsed, err := services.LoadFromFile(input.ConfigFilePath)
	if err != nil {
		return nil, fmt.Errorf("loading config: %+v", err)
	}

	specificationsDirectory := filepath.Join(input.SwaggerDirectory, "specification")
	resourceManagerServices, err := FindResourceManagerServices(specificationsDirectory, input.Logger)
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
			versionDirectories, ok := serviceDetails.ApiVersionPaths[version]
			if !ok {
				return nil, fmt.Errorf("details for the Version %q of Service %q were not found - does it exist on disk?", version, service.Directory)
			}

			for _, versionDirectory := range versionDirectories {
				filesForVersion := make([]string, 0)
				filesInDirectory, err := SwaggerFilesInDirectory(versionDirectory)
				if err != nil {
					return nil, fmt.Errorf("finding the swagger files within %q: %+v", versionDirectory, err)
				}
				for _, file := range *filesInDirectory {
					fileWithoutPrefix := strings.TrimPrefix(file, versionDirectory)
					filesForVersion = append(filesForVersion, fileWithoutPrefix)
				}

				resourceManagerService := ResourceManagerServiceInput{
					ServiceName:                service.Name,
					ApiVersion:                 version,
					ResourceProvider:           &serviceDetails.ResourceProvider,
					ResourceProviderToFilterTo: service.ResourceProvider,
					OutputDirectory:            input.OutputDirectory,
					SwaggerDirectory:           versionDirectory,
					SwaggerFiles:               filesForVersion,
				}

				definition, ok := terraformConfig.Services[service.Name]
				if ok {
					resourceManagerService.TerraformServiceDefinition = &definition
				}

				output = append(output, resourceManagerService.ToRunInput())
			}
		}
	}
	return &output, nil
}

func FindServicesByName(input FindServiceInput, terraformConfig definitions.Config, servicesToFind []string) (*[]ServiceInput, error) {
	parsed, err := services.LoadFromFile(input.ConfigFilePath)
	if err != nil {
		return nil, fmt.Errorf("loading config: %+v", err)
	}

	specificationsDirectory := filepath.Join(input.SwaggerDirectory, "specification")
	resourceManagerServices, err := FindResourceManagerServices(specificationsDirectory, input.Logger)
	if err != nil {
		return nil, fmt.Errorf("retrieving Resource Manager Service details from %q: %+v", specificationsDirectory, err)
	}

	serviceNames := make(map[string]struct{})
	for _, serviceName := range servicesToFind {
		serviceNames[serviceName] = struct{}{}
	}

	output := make([]ServiceInput, 0)
	for _, service := range parsed.Services {
		if _, ok := serviceNames[service.Name]; !ok {
			continue
		}

		// find the versions for each directory within this Service
		serviceDetails, ok := (*resourceManagerServices)[service.Directory]
		if !ok {
			return nil, fmt.Errorf("details for the Service %q were not found - does it exist on disk?", service.Directory)
		}

		for _, version := range service.Available {
			versionDirectories, ok := serviceDetails.ApiVersionPaths[version]
			if !ok {
				return nil, fmt.Errorf("details for the Version %q of Service %q were not found - does it exist on disk?", version, service.Directory)
			}

			for _, versionDirectory := range versionDirectories {
				filesForVersion := make([]string, 0)
				filesInDirectory, err := SwaggerFilesInDirectory(versionDirectory)
				if err != nil {
					return nil, fmt.Errorf("finding the swagger files within %q: %+v", versionDirectory, err)
				}
				for _, file := range *filesInDirectory {
					fileWithoutPrefix := strings.TrimPrefix(file, versionDirectory)
					filesForVersion = append(filesForVersion, fileWithoutPrefix)
				}

				resourceManagerService := ResourceManagerServiceInput{
					ServiceName:                service.Name,
					ApiVersion:                 version,
					ResourceProvider:           &serviceDetails.ResourceProvider,
					ResourceProviderToFilterTo: service.ResourceProvider,
					OutputDirectory:            input.OutputDirectory,
					SwaggerDirectory:           versionDirectory,
					SwaggerFiles:               filesForVersion,
				}

				definition, ok := terraformConfig.Services[service.Name]
				if ok {
					resourceManagerService.TerraformServiceDefinition = &definition
				}

				output = append(output, resourceManagerService.ToRunInput())
			}
		}
	}
	return &output, nil
}
