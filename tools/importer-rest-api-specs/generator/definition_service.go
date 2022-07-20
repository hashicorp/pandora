package generator

import (
	"fmt"
	"log"
	"os"
	"path"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/parser"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/cleanup"
)

func (g PandoraDefinitionGenerator) GenerateServiceDefinition(input parser.ParsedData) error {
	serviceDefinitionFilePath := path.Join(g.data.WorkingDirectoryForService, "ServiceDefinition.cs")
	if g.debugLog {
		log.Printf("[DEBUG] Generating Service Definition into %q..", serviceDefinitionFilePath)
	}

	normalizedServiceName := cleanup.NormalizeName(g.data.ServiceName)
	terraformResourceTypes := g.getTerraformResourceTypes(input)
	code := codeForServiceDefinition(g.data.NamespaceForService, normalizedServiceName, g.data.ResourceProvider, g.data.TerraformPackageName, terraformResourceTypes)
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

func codeForServiceDefinition(namespace, serviceName string, resourceProvider, terraformPackage *string, terraformResourceTypes []string) string {
	rp := "null"
	if resourceProvider != nil {
		rp = fmt.Sprintf("%q", *resourceProvider)
	}

	terraformPackageName := "null"
	if terraformPackage != nil {
		terraformPackageName = fmt.Sprintf("%q", *terraformPackage)
	}

	terraformResources := make([]string, 0)
	for _, v := range terraformResourceTypes {
		terraformResources = append(terraformResources, fmt.Sprintf("new %[1]s(),", v))
	}
	sort.Strings(terraformResources)

	return fmt.Sprintf(`using Pandora.Definitions.Interfaces;
using System.Collections.Generic;

%[1]s

namespace %[2]s;

public partial class Service : ServiceDefinition
{
	public string Name => %[3]q;
	public string? ResourceProvider => %[4]s;
	public string? TerraformPackageName => %[5]s;

	public IEnumerable<TerraformResourceDefinition> TerraformResources => new List<TerraformResourceDefinition>
	{
		%[6]s
	};
}
`, restApiSpecsLicence, namespace, serviceName, rp, terraformPackageName, strings.Join(terraformResources, "\n"))
}

func codeForServiceDefinitionGenerationSettings(namespace string, serviceName string) string {
	return fmt.Sprintf(`namespace %[1]s;

public partial class Service
{
	public bool Generate => true;
}
`, namespace, serviceName)
}
