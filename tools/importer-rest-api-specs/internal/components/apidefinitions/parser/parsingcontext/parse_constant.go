// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package parsingcontext

import (
	"fmt"

	"github.com/go-openapi/spec"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/constants"
)

func (c *Context) ParseConstant(constantName string, spec spec.Schema) (*constants.ParsedConstant, error) {
	constant, err := constants.Parse(spec.Type, constantName, nil, spec.Enum, spec.Extensions)
	if err != nil {
		return nil, fmt.Errorf("parsing constant: %+v", err)
	}

	return constant, nil
}
