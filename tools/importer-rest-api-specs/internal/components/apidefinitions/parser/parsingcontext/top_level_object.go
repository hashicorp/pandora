// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package parsingcontext

import (
	"fmt"
	"strings"

	"github.com/getkin/kin-openapi/openapi2"
)

func (c *Context) findTopLevelObject(name string) (*openapi2.SchemaRef, error) {
	for modelName, model := range c.Expanded.Definitions {
		if strings.EqualFold(modelName, name) {
			return model, nil
		}
	}

	for modelName, model := range c.Expanded.Definitions {
		if strings.EqualFold(modelName, name) {
			return model, nil
		}
	}

	return nil, fmt.Errorf("the top level object %q was not found", name)
}
