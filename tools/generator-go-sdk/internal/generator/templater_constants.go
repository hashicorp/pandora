package generator

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ templaterForResource = constantsTemplater{}

type constantsTemplater struct {
	constantTemplateFunc func(name string, details models.SDKConstant, generateNormalizationFunction, usedInAResourceId bool) (*string, error)
}

func (c constantsTemplater) template(data GeneratorData) (*string, error) {
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

		// the rollout of the Constant Normalization functions can be done at the same time as the
		// rollout of the new base layer, to allow us to go gradually
		generateNormalizationFunction := data.useNewBaseLayer

		// used to reduce the TLOC being output
		usedInAResourceId := false
		for _, id := range data.resourceIds {
			for _, segment := range id.Segments {
				if segment.Type == models.ConstantResourceIDSegmentType && segment.ConstantReference != nil && *segment.ConstantReference == constantName {
					usedInAResourceId = true
					break
				}
			}
		}

		constantLines, err := c.constantTemplateFunc(constantName, values, generateNormalizationFunction, usedInAResourceId)
		if err != nil {
			return nil, fmt.Errorf("generating template for constant %q: %+v", constantName, err)
		}
		lines = append(lines, *constantLines)
	}

	template := fmt.Sprintf(`package %[1]s

import (
	"encoding/json"
	"fmt"
	"strings"
)

%[3]s

%[2]s`, data.packageName, strings.Join(lines, "\n"), *copyrightLines)
	return &template, nil
}
