package dataapigenerator

import (
	"fmt"
	"path"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func (s Generator) generateVersionDefinition(apiVersion models.AzureApiDefinition) error {
	s.logger.Debug("Checking for an existing Generation Settings file..")

	// recreate the directory
	excludeList := []string{
		"ApiVersionDefinition-GenerationSetting.cs",
	}
	if err := recreateDirectoryExcludingFiles(s.workingDirectoryForApiVersion, excludeList, s.logger); err != nil {
		return fmt.Errorf("recreating directory %q: %+v", s.workingDirectoryForApiVersion, err)
	}

	// then generate the files
	s.logger.Debug("Generating Api Version Definition..")
	isPreview := strings.Contains(strings.ToLower(apiVersion.ApiVersion), "preview")
	definitionFilePath := path.Join(s.workingDirectoryForApiVersion, "ApiVersionDefinition.cs")
	if err := writeToFile(definitionFilePath, codeForApiVersionDefinition(s.namespaceForApiVersion, apiVersion.ApiVersion, isPreview, apiVersion.Resources)); err != nil {
		return fmt.Errorf("writing Api Version Definition to %q: %+v", definitionFilePath, err)
	}

	generationSettingFilePath := path.Join(s.workingDirectoryForApiVersion, "ApiVersionDefinition-GenerationSetting.cs")
	exists, err := fileExistsAtPath(generationSettingFilePath)
	if err != nil {
		return err
	}
	if *exists {
		s.logger.Debug(fmt.Sprintf("Api Version Definition Generation Settings exists at %q - skipping", generationSettingFilePath))
		return nil
	}

	s.logger.Debug("Generating Api Version Definition Generation Setting..")
	if err := writeToFile(generationSettingFilePath, codeForApiVersionDefinitionSetting(s.namespaceForApiVersion)); err != nil {
		return fmt.Errorf("writing Api Version Definition Generation Setting to %q: %+v", definitionFilePath, err)
	}

	return nil
}
