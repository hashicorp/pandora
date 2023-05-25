package pipeline

import (
	"fmt"
	"strings"
)

func templateConstants(apiVersion string, files *Tree, models Models) error {
	seenEnums := make(map[string]uint8, 0)
	for _, model := range models {
		for _, field := range model.Fields {
			if _, seen := seenEnums[field.Title]; (field.Type == FieldTypeString || field.ItemType == FieldTypeString) && field.Enum != nil && !seen {
				seenEnums[field.Title] = 1

				valuesCode := make([]string, 0, len(field.Enum))
				for _, enumValue := range field.Enum {
					val := []string{
						fmt.Sprintf(`[Description("%s")]`, cleanName(fmt.Sprintf("%s", enumValue))),
						fmt.Sprintf(`@%s,`, enumValue),
					}
					valuesCode = append(valuesCode, strings.Join(val, "\n"))
				}

				code := fmt.Sprintf(`using Pandora.Definitions.Attributes;
using System.ComponentModel;

// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

namespace Pandora.Definitions.MicrosoftGraph.Models.%[1]s;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum %[2]sConstant
{
%[3]s
}
`, cleanVersion(apiVersion), field.Title, indentSpace(strings.Join(valuesCode, "\n\n"), 4))

				filename := fmt.Sprintf("Models/%s/Constant-%s.cs", cleanVersion(apiVersion), field.Title)

				if err := files.addFile(filename, code); err != nil {
					return err
				}
			}
		}
	}

	return nil
}
