package dataapigeneratorjson

import (
	"encoding/json"
	"sort"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

type VersionDefinition struct {
	ApiVersion string   `json:"ApiVersion"`
	Preview    bool     `json:"Preview"`
	Source     string   `json:"Source"`
	Resources  []string `json:"Resources"`
	Generate   bool     `json:"Generate"`
}

func codeForApiVersionDefinition(apiVersion string, isPreview bool, resources map[string]models.AzureApiResource) ([]byte, error) {
	versionDefinition := VersionDefinition{
		ApiVersion: apiVersion,
		Preview:    isPreview,
		Source:     "ResourceManagerRestApiSpecs",
		Generate:   true,
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

	data, err := json.MarshalIndent(&versionDefinition, "", " ")
	if err != nil {
		return nil, err
	}

	return data, nil
}
