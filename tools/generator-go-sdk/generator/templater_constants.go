package generator

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ templater = constantsTemplater{}

type constantsTemplater struct {
	constantTemplateFunc func(name string, details resourcemanager.ConstantDetails) (*string, error)
}

func (c constantsTemplater) template(data ServiceGeneratorData) (*string, error) {
	keys := make([]string, 0)
	for name := range data.constants {
		keys = append(keys, name)
	}
	sort.Strings(keys)

	lines := make([]string, 0)
	for _, constantName := range keys {
		values := data.constants[constantName]

		constantLines, err := c.constantTemplateFunc(constantName, values)
		if err != nil {
			return nil, fmt.Errorf("generating template for constant %q: %+v", constantName, err)
		}
		lines = append(lines, *constantLines)
	}

	template := fmt.Sprintf(`package %[1]s

import (
	"strings"
	"github.com/hashicorp/go-azure-helpers/lang/normalizers"
)

%s`, data.packageName, strings.Join(lines, "\n"))
	return &template, nil
}
