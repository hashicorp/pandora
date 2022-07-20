package dataapigenerator

import (
	"fmt"
	"log"
	"path"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func (g PandoraDefinitionGenerator) generateVersionDefinition(resources map[string]models.AzureApiResource, workingDirectory string) error {
	if g.debugLog {
		log.Printf("[DEBUG] Checking for an existing Generation Settings file..")
	}

	// recreate the directory
	excludeList := []string{
		"ApiVersionDefinition-GenerationSetting.cs",
	}
	if err := recreateDirectoryExcludingFiles(workingDirectory, excludeList, g.debugLog); err != nil {
		return fmt.Errorf("recreating directory %q: %+v", g.data.WorkingDirectoryForApiVersion, err)
	}

	// then generate the files
	if g.debugLog {
		log.Printf("[DEBUG] Generating Api Version Definition..")
	}
	isPreview := strings.Contains(strings.ToLower(g.data.ApiVersion), "preview")
	definitionFilePath := path.Join(workingDirectory, "ApiVersionDefinition.cs")
	if err := writeToFile(definitionFilePath, codeForApiVersionDefinition(g.data.NamespaceForApiVersion, g.data.ApiVersion, isPreview, resources)); err != nil {
		return fmt.Errorf("writing Api Version Definition to %q: %+v", definitionFilePath, err)
	}

	generationSettingFilePath := path.Join(workingDirectory, "ApiVersionDefinition-GenerationSetting.cs")
	exists, err := fileExistsAtPath(generationSettingFilePath)
	if err != nil {
		return err
	}
	if *exists {
		if g.debugLog {
			log.Printf("[DEBUG] Api Version Definition Generation Settings exists at %q - skipping", generationSettingFilePath)
		}
		return nil
	}

	if g.debugLog {
		log.Printf("[DEBUG] Generating Api Version Definition Generation Setting..")
	}
	if err := writeToFile(generationSettingFilePath, codeForApiVersionDefinitionSetting(g.data.NamespaceForApiVersion)); err != nil {
		return fmt.Errorf("writing Api Version Definition Generation Setting to %q: %+v", definitionFilePath, err)
	}

	return nil
}
