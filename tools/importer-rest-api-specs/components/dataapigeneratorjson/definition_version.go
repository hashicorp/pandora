package dataapigeneratorjson

import (
	"fmt"
	"os"
	"path"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func (s Generator) generateVersionDefinition(apiVersion models.AzureApiDefinition) error {
	// create the directory if not already exists
	if err := os.MkdirAll(s.workingDirectoryForApiVersion, os.FileMode(0755)); err != nil {
		return fmt.Errorf("creating directory %q: %+v", s.workingDirectoryForApiVersion, err)
	}

	// TODO: IsPreview should be calculated in the Parser and used here
	// this logic comes from the V1 API Definitions, but still needs correcting
	isPreview := strings.Contains(strings.ToLower(apiVersion.ApiVersion), "preview")

	// then generate the files
	s.logger.Debug("Generating Api Version Definition..")
	definitionFilePath := path.Join(s.workingDirectoryForApiVersion, "ApiVersionDefinition.json")
	versionDefinition, err := codeForApiVersionDefinition(apiVersion.ApiVersion, isPreview, apiVersion.Resources)
	if err != nil {
		return fmt.Errorf("marshaling Api Version Definition: %+v", err)
	}
	if err := writeJsonToFile(definitionFilePath, versionDefinition); err != nil {
		return fmt.Errorf("writing Api Version Definition to %q: %+v", definitionFilePath, err)
	}

	return nil
}
