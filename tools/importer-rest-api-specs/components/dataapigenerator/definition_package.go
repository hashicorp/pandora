package dataapigenerator

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/cleanup"
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
		lines = append(lines, fmt.Sprintf("\t\tnew %sOperation(),", operationName))
	}

	return fmt.Sprintf(`using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

%[4]s

namespace %[1]s;

internal class Definition : ResourceDefinition
{
	public string Name => "%[2]s";
	public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
	{
%[3]s
	};
}
`, namespace, normalizedResourceName, strings.Join(lines, "\n"), restApiSpecsLicence)
}
