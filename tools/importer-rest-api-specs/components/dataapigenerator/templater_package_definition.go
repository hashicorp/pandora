package dataapigenerator

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/models"
)

func codeForPackageDefinition(namespace, resourceName string, input models.AzureApiResource) string {
	operationNames := make([]string, 0)
	for operation := range input.Operations {
		operationNames = append(operationNames, operation)
	}
	sort.Strings(operationNames)

	operationLines := make([]string, 0)
	for _, operationName := range operationNames {
		operationLines = append(operationLines, fmt.Sprintf("\t\tnew %sOperation(),", operationName))
	}

	constantNames := make([]string, 0)
	for k := range input.Constants {
		constantNames = append(constantNames, k)
	}
	sort.Strings(constantNames)

	constantLines := make([]string, 0)
	for _, constantName := range constantNames {
		constantLines = append(constantLines, fmt.Sprintf("\t\ttypeof(%sConstant),", constantName))
	}

	modelNames := make([]string, 0)
	for k := range input.Models {
		modelNames = append(modelNames, k)
	}
	sort.Strings(modelNames)

	modelLines := make([]string, 0)
	for _, modelName := range modelNames {
		modelLines = append(modelLines, fmt.Sprintf("\t\ttypeof(%sModel),", modelName))
	}

	return fmt.Sprintf(`using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

%[1]s

namespace %[2]s;

internal class Definition : ResourceDefinition
{
	public string Name => %[3]q;
	public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
	{
%[4]s
	};
	public IEnumerable<System.Type> Constants => new List<System.Type>
	{
%[5]s
	};
	public IEnumerable<System.Type> Models => new List<System.Type>
	{
%[6]s
	};
}
`, restApiSpecsLicence, namespace, resourceName, strings.Join(operationLines, "\n"), strings.Join(constantLines, "\n"), strings.Join(modelLines, "\n"))
}
