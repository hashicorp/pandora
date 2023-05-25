package pipeline

import (
	"fmt"
	"sort"
	"strings"
)

func templateModels(apiVersion string, files *Tree, models Models) error {
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

namespace Pandora.Definitions.MicrosoftGraph.Models.%[1]s;

internal class %[2]sModel
{
%[3]s
}
`, cleanVersion(apiVersion), name, indentSpace(strings.Join(fieldsCode, "\n\n"), 4))

		filename := fmt.Sprintf("Models/%s/Model-%s.cs", cleanVersion(apiVersion), name)

		if err := files.addFile(filename, code); err != nil {
			return err
		}
	}

	return nil
}
