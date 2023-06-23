package pipeline

import (
	"fmt"
	"os"
	"sort"
	"strings"
)

func (p pipelineTask) templateModelsForService(resources Resources, models Models) error {
	modelFiles := make(map[string]string)

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

		for modelName, model := range serviceModels {
			namespace := fmt.Sprintf("Pandora.Definitions.%[1]s.%[2]s.%[3]s.%[4]s", definitionsDirectory(p.apiVersion), cleanName(p.service), cleanVersion(p.apiVersion), category)
			filename := fmt.Sprintf("Pandora.Definitions.%[2]s%[1]s%[3]s%[1]s%[4]s%[1]s%[5]s%[1]sModel-%[6]s.cs", string(os.PathSeparator), definitionsDirectory(p.apiVersion), cleanName(p.service), cleanVersion(p.apiVersion), category, modelName)
			modelFiles[filename] = templateModel(namespace, modelName, model)
		}

	}

	modelFileNames := sortedKeys(modelFiles)
	for _, modelFileName := range modelFileNames {
		if err := p.files.addFile(modelFileName, modelFiles[modelFileName]); err != nil {
			return err
		}
	}

	return nil
}

func templateModels(files *Tree, apiVersion string, models Models) error {
	modelFiles := make(map[string]string)

	for modelName, model := range models {
		fieldNames := make([]string, 0, len(model.Fields))
		for fieldName := range model.Fields {
			fieldNames = append(fieldNames, fieldName)
		}

		sort.Strings(fieldNames)

		namespace := fmt.Sprintf("Pandora.Definitions.%[1]s.Models", definitionsDirectory(apiVersion))
		filename := fmt.Sprintf("Pandora.Definitions.%[2]s%[1]sModels%[1]sModel-%[3]s.cs", string(os.PathSeparator), definitionsDirectory(apiVersion), modelName)
		modelFiles[filename] = templateModel(namespace, modelName, model)
	}

	modelFileNames := sortedKeys(modelFiles)
	for _, modelFileName := range modelFileNames {
		if err := files.addFile(modelFileName, modelFiles[modelFileName]); err != nil {
			return err
		}
	}

	return nil
}

func templateModel(namespace, modelName string, model *Model) string {
	fieldNames := make([]string, 0, len(model.Fields))
	for fieldName := range model.Fields {
		fieldNames = append(fieldNames, fieldName)
	}

	sort.Strings(fieldNames)

	fieldsCode := make([]string, 0, len(fieldNames)*2)
	for _, fieldName := range fieldNames {
		field := []string{
			fmt.Sprintf(`[JsonPropertyName("%s")]`, fieldName),
			fmt.Sprintf("public %s? %s { get; set; }", model.Fields[fieldName].CSType(), fieldName),
		}
		fieldsCode = append(fieldsCode, strings.Join(field, "\n"))
	}

	return fmt.Sprintf(`using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

namespace %[1]s;

internal class %[2]sModel
{
%[3]s
}
`, namespace, modelName, indentSpace(strings.Join(fieldsCode, "\n\n"), 4))
}
