package definitions

import (
	"fmt"
	"io/fs"
	"path/filepath"
	"strings"

	"github.com/hashicorp/hcl/v2/hclsimple"
)

// LoadFromDirectory discovers all the configurations within the specified `path`
// and then loads them into a `Definition` for convenience purposes.
func LoadFromDirectory(path string) (*Config, error) {
	// first find all the files
	files, err := findConfigFilesWithin(path)
	if err != nil {
		return nil, fmt.Errorf("finding files within %q: %+v", path, err)
	}

	// then load all the configs
	configs, err := parseConfigsWithinFiles(*files)
	if err != nil {
		return nil, fmt.Errorf("parsing configs within files: %+v", err)
	}

	// then consolidate them into one thing for output
	result, err := consolidateIntoASingleDefinition(*configs)
	if err != nil {
		return nil, fmt.Errorf("consolidating data from configs: %+v", err)
	}
	return result, nil
}

func findConfigFilesWithin(directory string) (*[]string, error) {
	configFiles := make([]string, 0)
	if err := filepath.WalkDir(directory, func(path string, d fs.DirEntry, err error) error {
		if err != nil {
			return err
		}
		name := filepath.Base(path)
		extension := filepath.Ext(name)
		if strings.EqualFold(extension, ".hcl") {
			configFiles = append(configFiles, path)
		}
		return nil
	}); err != nil {
		return nil, err
	}
	return &configFiles, nil
}

func parseConfigsWithinFiles(files []string) (*[]definition, error) {
	output := make([]definition, 0)

	for _, filePath := range files {
		var config definition
		err := hclsimple.DecodeFile(filePath, nil, &config)
		if err != nil {
			return nil, fmt.Errorf("parsing config in %q: %+v", filePath, err)
		}

		output = append(output, config)
	}

	return &output, nil
}

func consolidateIntoASingleDefinition(input []definition) (*Config, error) {
	services := make(map[string]ServiceDefinition, 0)

	for _, v := range input {
		for _, service := range v.Services {
			// we intentionally want each service/api version/resource to be defined one-time to keep things consistent
			// as such we'll sanity check as parsing these out that this is the only occurrence
			// since the names have to exact-match the names in the Data API this is case-sensitive.
			if _, ok := services[service.Name]; ok {
				return nil, fmt.Errorf("service %q is defined multiple times", service.Name)
			}

			apis := make(map[string]ApiVersionDefinition)
			for _, api := range service.ApiVersions {
				if _, ok := apis[api.Version]; ok {
					return nil, fmt.Errorf("api version %q within service %q is defined multiple times", api.Version, service.Name)
				}

				packages := make(map[string]PackageDefinition)
				for _, pkg := range api.Packages {
					if _, ok := packages[pkg.Name]; ok {
						return nil, fmt.Errorf("package %q within api version %q within service %q is defined multiple times", pkg.Name, api.Version, service.Name)
					}

					definitions := make(map[string]ResourceDefinition)
					for _, def := range pkg.Definitions {
						if _, ok := definitions[def.ResourceType]; ok {
							return nil, fmt.Errorf("definition %q within package %q within api version %q within service %q is defined multiple times", def.ResourceType, pkg.Name, api.Version, service.Name)
						}

						definitions[def.ResourceType] = ResourceDefinition{
							ID:                 def.Id,
							Name:               def.DisplayName,
							WebsiteSubcategory: def.WebsiteSubcategory,
							Description:        def.Description,
						}
					}

					packages[pkg.Name] = PackageDefinition{
						Definitions: definitions,
					}
				}

				apis[api.Version] = ApiVersionDefinition{
					Packages: packages,
				}
			}
			services[service.Name] = ServiceDefinition{
				ApiVersions:          apis,
				TerraformPackageName: service.TerraformPackageName,
			}
		}
	}

	return &Config{
		Services: services,
	}, nil
}
