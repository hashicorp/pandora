package pipeline

import (
	"fmt"
	"os"
	"strings"
)

func (p pipelineTask) templateConstantsForService(resources Resources, models Models) error {
	constantFiles := make(map[string]string)

	categories := make(map[string]bool)
	for _, resource := range resources {
		if resource.Category == "" {
			continue
		}

		categories[resource.Category] = true
	}

	for category, _ := range categories {
		serviceModels := make(Models)

		for _, resource := range resources {
			if strings.EqualFold(resource.Category, category) {
				for _, operation := range resource.Operations {
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
				}
			}
		}

		for _, model := range serviceModels {
			for _, field := range model.Fields {
				namespace := fmt.Sprintf("Pandora.Definitions.%[1]s.%[2]s.%[3]s.%[4]s", cleanName(p.service), definitionsDirectory(p.apiVersion), cleanVersion(p.apiVersion), category)
				filename := fmt.Sprintf("Pandora.Definitions.%[2]s%[1]s%[3]s%[1]s%[4]s%[1]s%[5]s%[1]sConstant-%[6]s.cs", string(os.PathSeparator), definitionsDirectory(p.apiVersion), cleanName(p.service), cleanVersion(p.apiVersion), category, field.Title)
				if _, seen := constantFiles[filename]; (field.Type == FieldTypeString || field.ItemType == FieldTypeString) && field.Enum != nil && !seen {
					constantFiles[filename] = templateConstant(namespace, field)
				}
			}
		}
	}

	constantFileNames := sortedKeys(constantFiles)
	for _, constantFileName := range constantFileNames {
		if err := p.files.addFile(constantFileName, constantFiles[constantFileName]); err != nil {
			return err
		}
	}

	return nil
}

func templateConstants(files *Tree, apiVersion string, models Models) error {
	constantFiles := make(map[string]string)

	for _, model := range models {
		for _, field := range model.Fields {
			namespace := fmt.Sprintf("Pandora.Definitions.%[1]s.Models", definitionsDirectory(apiVersion))
			filename := fmt.Sprintf("Pandora.Definitions.%[2]s%[1]sModels%[1]sConstant-%[3]s.cs", string(os.PathSeparator), definitionsDirectory(apiVersion), field.Title)
			if _, seen := constantFiles[filename]; (field.Type == FieldTypeString || field.ItemType == FieldTypeString) && field.Enum != nil && !seen {
				constantFiles[filename] = templateConstant(namespace, field)
			}
		}
	}

	constantFileNames := sortedKeys(constantFiles)
	for _, constantFileName := range constantFileNames {
		if err := files.addFile(constantFileName, constantFiles[constantFileName]); err != nil {
			return err
		}
	}

	return nil
}

func templateConstant(namespace string, field *ModelField) string {
	valuesCode := make([]string, 0, len(field.Enum))
	for _, enumValue := range field.Enum {
		val := []string{
			fmt.Sprintf(`[Description("%s")]`, cleanName(fmt.Sprintf("%s", enumValue))),
			fmt.Sprintf(`@%s,`, enumValue),
		}
		valuesCode = append(valuesCode, strings.Join(val, "\n"))
	}

	return fmt.Sprintf(`using Pandora.Definitions.Attributes;
using System.ComponentModel;

// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

namespace %[1]s;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum %[2]sConstant
{
%[3]s
}
`, namespace, field.Title, indentSpace(strings.Join(valuesCode, "\n\n"), 4))
}
