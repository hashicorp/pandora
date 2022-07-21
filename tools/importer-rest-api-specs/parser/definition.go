package parser

import (
	"github.com/go-openapi/analysis"
	"github.com/go-openapi/spec"
	"github.com/hashicorp/go-hclog"
)

type SwaggerDefinition struct {
	// Name is the name of this Swagger file
	Name string

	logger hclog.Logger

	// swaggerSpecExpanded is a flattened version of the Swagger spec into a single file
	swaggerSpecExpanded *analysis.Spec

	// swaggerSpecWithReferences is the same as Swagger Spec Expanded but contains the 'ref' details
	swaggerSpecWithReferences *analysis.Spec

	swaggerSpecRaw *spec.Swagger

	swaggerSpecExtendedRaw *spec.Swagger
}
