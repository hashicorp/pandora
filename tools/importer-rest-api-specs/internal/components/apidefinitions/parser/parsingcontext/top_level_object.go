package parsingcontext

import (
	"fmt"
	"strings"

	"github.com/go-openapi/spec"
)

func (c *Context) findTopLevelObject(name string) (*spec.Schema, error) {
	for modelName, model := range c.SwaggerSpecWithReferencesRaw.Definitions {
		if strings.EqualFold(modelName, name) {
			return &model, nil
		}
	}

	for modelName, model := range c.SwaggerSpecWithReferencesRaw.Definitions {
		if strings.EqualFold(modelName, name) {
			return &model, nil
		}
	}

	return nil, fmt.Errorf("the top level object %q was not found", name)
}
