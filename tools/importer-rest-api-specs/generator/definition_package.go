package generator

import (
	"fmt"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/cleanup"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func (g PandoraDefinitionGenerator) codeForPackageDefinition(namespace, resourceName string, operations map[string]models.OperationDetails) string {
	operationNames := make([]string, 0)
	for operation := range operations {
		operationNames = append(operationNames, operation)
	}
	sort.Strings(operationNames)

	normalizedResourceName := cleanup.NormalizeName(resourceName)

	lines := make([]string, 0)
	for _, operationName := range operationNames {
		lines = append(lines, fmt.Sprintf("\t\t\tnew %sOperation(),", operationName))
	}

	return fmt.Sprintf(`using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace %[1]s
{
	internal class Definition : ApiDefinition
	{
		public string ApiVersion => "%[3]s";
		public string Name => "%[2]s";
		public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
		{
%[4]s
		};
	}
}
`, namespace, normalizedResourceName, g.data.ApiVersion, strings.Join(lines, "\n"))
}
