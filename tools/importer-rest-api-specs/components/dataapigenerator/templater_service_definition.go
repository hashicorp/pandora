package dataapigenerator

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func codeForServiceDefinition(namespace, serviceName string, resourceProvider, terraformPackage *string, data models.AzureApiDefinition) string {
	rp := "null"
	if resourceProvider != nil {
		rp = fmt.Sprintf("%q", *resourceProvider)
	}

	terraformPackageName := "null"
	if terraformPackage != nil {
		terraformPackageName = fmt.Sprintf("%q", *terraformPackage)
	}

	terraformResources := make([]string, 0)
	for _, resource := range data.Resources {
		if resource.Terraform == nil {
			continue
		}

		for _, v := range resource.Terraform.Resources {
			terraformResources = append(terraformResources, fmt.Sprintf("new Terraform.%sResource(),", v.ResourceName))
		}
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
