package generator

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
)

var _ templaterForResource = constantsTemplater{}

type constantsTemplater struct {
	constantTemplateFunc func(name string, details resourcemanager.ConstantDetails) (*string, error)
}

func (c constantsTemplater) template(data ServiceGeneratorData) (*string, error) {
	copyrightLines, err := copyrightLinesForSource(data.source)
	if err != nil {
		return nil, fmt.Errorf("retrieving copyright lines: %+v", err)
	}

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

import "strings"

%[3]s

%[2]s`, data.packageName, strings.Join(lines, "\n"), *copyrightLines)
	return &template, nil
}
