package generator

import (
	"fmt"
	"log"
	"os"
	"path"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/cleanup"
)

func (g PandoraDefinitionGenerator) GenerateServiceDefinition() error {
	serviceDefinitionFilePath := path.Join(g.data.WorkingDirectoryForService, "ServiceDefinition.cs")
	if g.debugLog {
		log.Printf("[DEBUG] Generating Service Definition into %q..", serviceDefinitionFilePath)
	}
	normalizedServiceName := cleanup.NormalizeName(g.data.ServiceName)
	code := codeForServiceDefinition(g.data.NamespaceForService, normalizedServiceName, g.data.ResourceProvider)
	if err := writeToFile(serviceDefinitionFilePath, code); err != nil {
		return fmt.Errorf("generating Service Definition into %q: %+v", serviceDefinitionFilePath, err)
	}

	generationSettingsFilePath := path.Join(g.data.WorkingDirectoryForService, "ServiceDefinition-GenerationSettings.cs")
	file, err := os.Stat(generationSettingsFilePath)
	if err != nil && !os.IsNotExist(err) {
		return fmt.Errorf("checking for an existing Service Definition Generation Settings file at %q: %+v", generationSettingsFilePath, err)
	}

	if file != nil && file.Size() > 0 {
		if g.debugLog {
			log.Printf("[DEBUG] Service Definition Generation Settings exist at %q - skipping", generationSettingsFilePath)
		}
		return nil
	}

	if g.debugLog {
		log.Printf("[DEBUG] Creating Service Definition Generation Settings at %q", generationSettingsFilePath)
	}
	code = codeForServiceDefinitionGenerationSettings(g.data.NamespaceForService, g.data.ServiceName)
	if err := writeToFile(generationSettingsFilePath, code); err != nil {
		return fmt.Errorf("generating Service Definition Generation Settings into %q: %+v", generationSettingsFilePath, err)
	}

	return nil
}

func codeForServiceDefinition(namespace, serviceName string, resourceProvider *string) string {
	rp := "null"
	if resourceProvider != nil {
		rp = fmt.Sprintf("%q", *resourceProvider)
	}

	return fmt.Sprintf(`using Pandora.Definitions.Interfaces;

namespace %[1]s
{
    public partial class Service : ServiceDefinition
    {
        public string Name => %[2]q;
        public string? ResourceProvider => %[3]s;
    }
}
`, namespace, serviceName, rp)
}

func codeForServiceDefinitionGenerationSettings(namespace string, serviceName string) string {
	return fmt.Sprintf(`namespace %[1]s
{
    public partial class Service
    {
        public bool Generate => true;
    }
}
`, namespace, serviceName)
}
