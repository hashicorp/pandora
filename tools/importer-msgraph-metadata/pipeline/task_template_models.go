package pipeline

import (
	"fmt"
	"path"
	"sort"
	"strings"
)

func (p pipelineTask) templateModelsForService(commonTypesDirectoryName string, resources Resources, models Models) error {
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
			if model.Common {
				continue
			}

			namespace := fmt.Sprintf("Pandora.Definitions.%[1]s.%[2]s.%[3]s.%[4]s", definitionsDirectory(p.apiVersion), cleanName(p.service), cleanVersion(p.apiVersion), category)
			filename := path.Join(fmt.Sprintf("Pandora.Definitions.%s", definitionsDirectory(p.apiVersion)), cleanName(p.service), cleanVersion(p.apiVersion), category, fmt.Sprintf("Model-%s.cs", modelName))
			modelsNamespace := fmt.Sprintf("Pandora.Definitions.%[1]s.%[2]s", definitionsDirectory(p.apiVersion), commonTypesDirectoryName)
			modelFiles[filename] = templateModel(namespace, modelsNamespace, modelName, model)
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

func templateCommonModels(files *Tree, commonTypesDirectoryName, apiVersion string, models Models) error {
	modelFiles := make(map[string]string)

	for modelName, model := range models {
		if !model.Common {
			continue
		}

		fieldNames := make([]string, 0, len(model.Fields))
		for fieldName := range model.Fields {
			fieldNames = append(fieldNames, fieldName)
		}

		sort.Strings(fieldNames)

		namespace := fmt.Sprintf("Pandora.Definitions.%[1]s.%[2]s", definitionsDirectory(apiVersion), commonTypesDirectoryName)
		filename := path.Join(fmt.Sprintf("Pandora.Definitions.%s", definitionsDirectory(apiVersion)), commonTypesDirectoryName, fmt.Sprintf("Model-%s.cs", modelName))
		modelFiles[filename] = templateModel(namespace, "", modelName, model)
	}

	modelFileNames := sortedKeys(modelFiles)
	for _, modelFileName := range modelFileNames {
		if err := files.addFile(modelFileName, modelFiles[modelFileName]); err != nil {
			return err
		}
	}

	return nil
}

func templateModel(namespace, modelsNamespace, modelName string, model *Model) string {
	modelsImportCode := ""
	if modelsNamespace != "" {
		modelsImportCode = fmt.Sprintf("using %s;", modelsNamespace)
	}

	fieldNames := make([]string, 0, len(model.Fields))
	for fieldName := range model.Fields {
		fieldNames = append(fieldNames, fieldName)
	}

	sort.Strings(fieldNames)

	fieldsCode := make([]string, 0, len(fieldNames)*2)
	for _, fieldName := range fieldNames {
		if fType := model.Fields[fieldName].CSType(); fType != nil {
			field := []string{
				fmt.Sprintf(`[JsonPropertyName("%s")]`, model.Fields[fieldName].JsonField),
				fmt.Sprintf("public %s? %s { get; set; }", *fType, fieldName),
			}
			fieldsCode = append(fieldsCode, strings.Join(field, "\n"))
		}
	}

	return fmt.Sprintf(`// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;
%[4]s

namespace %[1]s;

internal class %[2]sModel
{
%[3]s
}
`, namespace, modelName, indentSpace(strings.Join(fieldsCode, "\n\n"), 4), modelsImportCode)
}
