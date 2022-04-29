package generator

import (
	"fmt"
	"log"
	"os"
	"path"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func (g PandoraDefinitionGenerator) GenerateVersionDefinitionAndRecreateDirectory(resources map[string]models.AzureApiResource, workingDirectory string, permissions os.FileMode) error {
	if g.debugLog {
		log.Printf("[DEBUG] Checking for an existing Generation Settings file..")
	}
	generationSettingFilePath := path.Join(workingDirectory, "ApiVersionDefinition-GenerationSetting.cs")
	settingsFile, err := readFromFile(generationSettingFilePath)
	if err != nil {
		return fmt.Errorf("reading the existing Generation Settings for %q: %+v", generationSettingFilePath, err)
	}
	if settingsFile != nil {
		if g.debugLog {
			log.Printf("[DEBUG] Using existing Generation Settings file at path %q..", generationSettingFilePath)
		}
	} else {
		code := codeForApiVersionDefinitionSetting(g.data.NamespaceForApiVersion)
		b := []byte(code)
		settingsFile = &b
	}

	// recreate the directory
	if g.debugLog {
		log.Printf("[DEBUG] Deleting any existing directory at %q..", g.data.WorkingDirectoryForApiVersion)
	}
	os.RemoveAll(g.data.WorkingDirectoryForApiVersion)
	if g.debugLog {
		log.Printf("[DEBUG] (Re)Creating the directory at %q..", g.data.WorkingDirectoryForApiVersion)
	}
	if err := os.MkdirAll(g.data.WorkingDirectoryForApiVersion, permissions); err != nil {
		return fmt.Errorf("creating directory %q: %+v", g.data.WorkingDirectoryForApiVersion, err)
	}
	if g.debugLog {
		log.Printf("[DEBUG] Created Directory at %q", g.data.WorkingDirectoryForApiVersion)
	}

	// then generate the files
	if g.debugLog {
		log.Printf("[DEBUG] Generating Api Version Definition..")
	}
	isPreview := strings.Contains(strings.ToLower(g.data.ApiVersion), "preview")
	code := codeForApiVersionDefinition(g.data.NamespaceForApiVersion, g.data.ApiVersion, isPreview, resources)
	definitionFilePath := path.Join(workingDirectory, "ApiVersionDefinition.cs")
	if err := writeToFile(definitionFilePath, code); err != nil {
		return fmt.Errorf("writing Api Version Definition to %q: %+v", definitionFilePath, err)
	}

	if g.debugLog {
		log.Printf("[DEBUG] Generating Api Version Definition Generation Setting..")
	}
	if err := writeToFile(generationSettingFilePath, string(*settingsFile)); err != nil {
		return fmt.Errorf("writing Api Version Definition Generation Setting to %q: %+v", definitionFilePath, err)
	}

	return nil
}

func codeForApiVersionDefinition(namespace, apiVersion string, isPreview bool, resources map[string]models.AzureApiResource) string {
	names := make([]string, 0)
	for name, value := range resources {
		// skip ones which are filtered out
		if len(value.Operations) == 0 {
			continue
		}

		names = append(names, name)
	}

	sort.Strings(names)

	lines := make([]string, 0)
	for _, name := range names {
		lines = append(lines, fmt.Sprintf("\t\tnew %s.Definition(),", name))
	}

	return fmt.Sprintf(`using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace %[1]s;
public partial class Definition : ApiVersionDefinition
{
	public string ApiVersion => %[2]q;
	public bool Preview => %[3]t;
    public Source Source => Source.ResourceManagerRestApiSpecs;
	
	public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
	{
%[4]s
	};
}
`, namespace, apiVersion, isPreview, strings.Join(lines, "\n"))
}

func codeForApiVersionDefinitionSetting(namespace string) string {
	return fmt.Sprintf(`namespace %[1]s;

public partial class Definition
{
	public bool Generate => true;
}
`, namespace)
}
