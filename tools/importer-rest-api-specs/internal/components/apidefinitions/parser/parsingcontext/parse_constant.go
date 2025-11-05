// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package parsingcontext

import (
	"fmt"

	"github.com/getkin/kin-openapi/openapi2"
	"github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/constants"
)

func (c *Context) ParseConstant(constantName string, spec openapi2.SchemaRef) (*constants.ParsedConstant, error) {
	constant, err := constants.Parse(*spec.Value.Type, constantName, nil, spec.Value.Enum, spec.Extensions)
	if err != nil {
		return nil, fmt.Errorf("parsing constant: %+v", err)
	}

	return constant, nil
}
