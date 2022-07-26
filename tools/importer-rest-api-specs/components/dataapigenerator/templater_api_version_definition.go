package dataapigenerator

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

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
