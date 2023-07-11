package pipeline

import (
	"fmt"
	"path"
	"sort"
	"strings"
)

func (p pipelineTask) templateDefinitionsForService(commonTypesDirectoryName string, resources Resources, models Models) error {
	definitions := make(map[string]string)

	categories := make(map[string]bool)
	for _, resource := range resources {
		if resource.Category == "" {
			continue
		}

		categories[resource.Category] = true
	}

	for category, _ := range categories {
		operationNamesMap := make(map[string]bool)
		constantNamesMap := make(map[string]bool)
		serviceModels := make(Models)
		serviceLocalModels := make(Models)

		for _, resource := range resources {
			if strings.EqualFold(resource.Category, category) {
				for _, operation := range resource.Operations {
					// Determine whether to skip List operation with missing response model
					if operation.Type == OperationTypeList {
						if responseModel := operation.Responses.FindModelName(); responseModel == nil {
							continue
						}
					}

					operationNamesMap[operation.Name] = true

					if m := operation.RequestModel; m != nil {
						if err := serviceModels.MergeDependants(models, *m); err != nil {
							return err
						}
					}

					for _, response := range operation.Responses {
						if m := response.ModelName; m != nil {
							if err := serviceModels.MergeDependants(models, *m); err != nil {
								return err
							}
						}
					}

					for modelName, model := range serviceModels {
						if model.Common {
							continue
						}
						serviceLocalModels[modelName] = model
					}

					for _, model := range serviceLocalModels {
						for _, field := range model.Fields {
							if len(field.Enum) > 0 && ((field.Type != nil && *field.Type == DataTypeString) || (field.ItemType != nil && *field.ItemType == DataTypeString)) {
								constantNamesMap[field.Title] = true
							}
						}
					}
				}
			}
		}

		operationNames := make([]string, 0, len(operationNamesMap))
		for m, _ := range operationNamesMap {
			operationNames = append(operationNames, m)
		}

		constantNames := make([]string, 0, len(constantNamesMap))
		for m, _ := range constantNamesMap {
			constantNames = append(constantNames, m)
		}

		namespace := fmt.Sprintf("Pandora.Definitions.%[1]s.%[2]s.%[3]s.%[4]s", definitionsDirectory(p.apiVersion), cleanName(p.service), cleanVersion(p.apiVersion), category)
		modelsNamespace := fmt.Sprintf("Pandora.Definitions.%[1]s.%[2]s", definitionsDirectory(p.apiVersion), commonTypesDirectoryName)

		filename := path.Join(fmt.Sprintf("Pandora.Definitions.%s", definitionsDirectory(p.apiVersion)), cleanName(p.service), cleanVersion(p.apiVersion), category, "Definition.cs")
		definitions[filename] = templateDefinition(namespace, modelsNamespace, category, operationNames, constantNames, serviceLocalModels)
	}

	definitionFiles := sortedKeys(definitions)
	for _, definitionFile := range definitionFiles {
		if err := p.files.addFile(definitionFile, definitions[definitionFile]); err != nil {
			return err
		}
	}

	return nil
}

func templateDefinition(namespace, modelsNamespace, category string, operationNames, constantNames []string, models Models) string {
	modelsImportCode := ""
	if modelsNamespace != "" {
		modelsImportCode = fmt.Sprintf("using %s;", modelsNamespace)
	}

	operations := make([]string, 0, len(operationNames))
	for _, operation := range operationNames {
		operations = append(operations, fmt.Sprintf(`new %sOperation()`, operation))
	}
	sort.Strings(operations)
	operationsCode := indentSpace(strings.Join(operations, ",\n"), 8)

	constants := make([]string, 0, len(constantNames))
	for _, constant := range constantNames {
		constants = append(constants, fmt.Sprintf(`typeof(%sConstant)`, constant))
	}
	sort.Strings(constants)
	constantsCode := indentSpace(strings.Join(constants, ",\n"), 8)

	modelsLines := make([]string, 0, len(models))
	for modelName := range models {
		modelsLines = append(modelsLines, fmt.Sprintf(`typeof(%sModel)`, modelName))
	}
	sort.Strings(modelsLines)
	modelsCode := indentSpace(strings.Join(modelsLines, ",\n"), 8)

	return fmt.Sprintf(`using Pandora.Definitions.Interfaces;
%[2]s
using System;

// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

namespace %[1]s;

internal class Definition : ResourceDefinition
{
    public string Name => "%[3]s";

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
`, namespace, modelsImportCode, category, operationsCode, constantsCode, modelsCode)

}
