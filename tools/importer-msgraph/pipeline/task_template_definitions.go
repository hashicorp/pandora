package pipeline

import (
	"fmt"
	"os"
	"sort"
	"strings"

	"github.com/hashicorp/go-hclog"
)

func (pipelineTask) templateDefinitionsForService(files *Tree, serviceName, apiVersion string, resources Resources, models Models, logger hclog.Logger) error {
	definitions := make(map[string]string)

	categories := make(map[string]bool)
	for _, resource := range resources {
		categories[resource.Category] = true
	}

	for category, _ := range categories {
		operationNames := make([]string, 0)
		modelNamesMap := make(map[string]bool, 0)
		constantNamesMap := make(map[string]bool)

		for _, resource := range resources {
			if strings.EqualFold(resource.Category, category) {
				for _, operation := range resource.Operations {
					operationNames = append(operationNames, operation.Name)
					if m := operation.RequestModel; m != nil {
						modelNamesMap[*m] = true

						if model, ok := models[*m]; ok {
							for _, field := range model.Fields {
								if field.Enum != nil && (field.Type == FieldTypeString || field.ItemType == FieldTypeString) {
									constantNamesMap[field.Title] = true
								}
							}
						}
					}
					for _, response := range operation.Responses {
						if m := response.ModelName; m != nil {
							modelNamesMap[*m] = true

							if model, ok := models[*m]; ok {
								for _, field := range model.Fields {
									if field.Enum != nil && (field.Type == FieldTypeString || field.ItemType == FieldTypeString) {
										constantNamesMap[field.Title] = true
									}
								}
							}
						}
					}
				}
			}
		}

		constantNames := make([]string, 0, len(constantNamesMap))
		for m, _ := range constantNamesMap {
			constantNames = append(constantNames, m)
		}

		modelNames := make([]string, 0, len(modelNamesMap))
		for m, _ := range modelNamesMap {
			modelNames = append(modelNames, m)
		}

		filename := fmt.Sprintf("Pandora.Definitions.%[2]s%[1]s%[3]s%[1]s%[4]s%[1]s%[5]s%[1]sDefinition.cs", string(os.PathSeparator), definitionsDirectory(apiVersion), serviceName, cleanVersion(apiVersion), category)
		definitions[filename] = templateDefinition(serviceName, apiVersion, category, operationNames, constantNames, modelNames)
	}

	definitionFiles := sortedKeys(definitions)
	for _, definitionFile := range definitionFiles {
		if err := files.addFile(definitionFile, definitions[definitionFile]); err != nil {
			return err
		}
	}

	return nil
}

func templateDefinition(serviceName, apiVersion, category string, operationNames, constantNames, modelNames []string) string {
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

	models := make([]string, 0, len(modelNames))
	for _, model := range modelNames {
		models = append(models, fmt.Sprintf(`typeof(%sModel)`, model))
	}
	sort.Strings(models)
	modelsCode := indentSpace(strings.Join(models, ",\n"), 8)

	return fmt.Sprintf(`using Pandora.Definitions.Interfaces;
using Pandora.Definitions.%[2]s.Models;
using System;

// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

namespace Pandora.Definitions.%[2]s.%[1]s.%[3]s.%[4]s;

internal class Definition : ResourceDefinition
{
    public string Name => "%[1]s";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
%[5]s
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
%[6]s
    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
%[7]s
    };
}
`, cleanName(serviceName), definitionsDirectory(apiVersion), cleanVersion(apiVersion), category, operationsCode, constantsCode, modelsCode)

}
