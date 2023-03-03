package pipeline

import (
	"fmt"
	"sort"
	"strings"
)

const CustomTypes string = `
type UUID string
`

func templateModels(files *Tree, models Models) error {
	tmpl := make([]string, 0)
	seenEnums := make(map[string]uint8, 0)
	for name, model := range models {
		fields := make([]string, 0)
		for n, f := range model.Fields {
			//if n[:1] == "@" {
			//	continue
			//}
			fields = append(fields, fmt.Sprintf(`	%s %s %s`, cleanName(n), f.GoType(), f.GoTag()))
			if _, seen := seenEnums[f.Title]; (f.Type == FieldTypeString || f.ItemType == FieldTypeString) && f.Enum != nil && !seen {
				seenEnums[f.Title] = 1
				vals := make([]string, 0)
				for _, e := range f.Enum {
					vals = append(vals, fmt.Sprintf("%[1]s%[2]s %[1]s = %[3]q", f.Title, strings.Title(fmt.Sprintf("%s", e)), e))
				}
				tmpl = append(tmpl, fmt.Sprintf(`type %s string

const (
	%s
)`, f.Title, strings.Join(vals, "\n\t")))
			}
		}
		if len(fields) == 0 {
			continue
		}
		sort.Strings(fields)
		tmpl = append(tmpl, fmt.Sprintf(`type %s struct {
%s
}`, name, strings.Join(fields, "\n")))
	}
	tmpl = append(tmpl, CustomTypes)
	sort.Strings(tmpl)
	return files.addFile("models/models.go", templateFile("models", tmpl))
}
