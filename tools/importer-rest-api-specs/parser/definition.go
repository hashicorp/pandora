package parser

import (
	"github.com/go-openapi/analysis"
	"github.com/go-openapi/spec"
)

type SwaggerDefinition struct {
	// Name is the name of this Swagger file
	Name string

	// should the debug logs be output to stdout
	debugLog bool

	// swaggerSpecExpanded is a flattened version of the Swagger spec into a single file
	swaggerSpecExpanded *analysis.Spec

	// swaggerSpecWithReferences is the same as Swagger Spec Expanded but contains the 'ref' details
	swaggerSpecWithReferences *analysis.Spec

	swaggerSpecRaw *spec.Swagger
}
