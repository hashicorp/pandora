package pipeline

import (
	"fmt"
	"strings"
)

func templateConstants(files *Tree, models Models) error {
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

namespace Pandora.Definitions.MicrosoftGraph.Models;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum %[1]sConstant
{
%[2]s
}
`, field.Title, indent(strings.Join(valuesCode, "\n\n"), "    "))

				filename := fmt.Sprintf("Models/Constant-%s.cs", field.Title)

				if err := files.addFile(filename, code); err != nil {
					return err
				}
			}
		}
	}

	return nil
}
