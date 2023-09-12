package dataapigeneratoryaml

import (
	"gopkg.in/yaml.v3"
	"sort"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

type VersionDefinition struct {
	ApiVersion string   `yaml:"ApiVersion"`
	Preview    bool     `yaml:"Preview"`
	Source     string   `yaml:"Source"`
	Resources  []string `yaml:"Resources"`
}

func codeForApiVersionDefinition(apiVersion string, isPreview bool, resources map[string]models.AzureApiResource) ([]byte, error) {
	versionDefinition := VersionDefinition{
		ApiVersion: apiVersion,
		Preview:    isPreview,
		Source:     "ResourceManagerRestApiSpecs",
	}

	names := make([]string, 0)
	for name, value := range resources {
		// skip ones which are filtered out
		if len(value.Operations) == 0 {
			continue
		}
		names = append(names, name)
	}
	sort.Strings(names)

	versionDefinition.Resources = names

	data, err := yaml.Marshal(&versionDefinition)
	if err != nil {
		return nil, err
	}

	return data, nil
}

func codeForApiVersionDefinitionSetting() ([]byte, error) {
	generate := map[string]bool{
		"Generate": true,
	}

	data, err := yaml.Marshal(&generate)
	if err != nil {
		return nil, err
	}

	return data, nil
}
