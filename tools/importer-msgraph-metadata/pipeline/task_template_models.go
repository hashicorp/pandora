package pipeline

import (
	"fmt"
	"os"
	"sort"
	"strings"
)

func (p pipelineTask) templateModels(apiVersion string, models Models) error {
	for name, model := range models {
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

		code := fmt.Sprintf(`using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;

// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

namespace Pandora.Definitions.%[1]s.Models;

internal class %[2]sModel
{
%[3]s
}
`, definitionsDirectory(apiVersion), name, indentSpace(strings.Join(fieldsCode, "\n\n"), 4))

		filename := fmt.Sprintf("Pandora.Definitions.%[2]s%[1]sModels%[1]sModel-%[3]s.cs", string(os.PathSeparator), definitionsDirectory(apiVersion), name)

		if err := p.files.addFile(filename, code); err != nil {
			return err
		}
	}

	return nil
}
