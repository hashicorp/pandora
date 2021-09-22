package generator

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func (g PandoraDefinitionGenerator) codeForResourceID(namespace string, resourceIdName string, resourceIdValue models.ParsedResourceId) string {
	// TODO: update to output the different segments
	return fmt.Sprintf(`using Pandora.Definitions.Interfaces;

namespace %[1]s
{
	internal class %[2]s : ResourceID
	{
		public string ID() => "%[3]s";
	}
}
`, namespace, resourceIdName, resourceIdValue.String())
}
