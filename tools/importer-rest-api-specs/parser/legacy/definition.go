package legacy

import (
	"github.com/go-openapi/analysis"
	"github.com/go-openapi/spec"
)

type SwaggerDefinition struct {
	// Name is the name of this Swagger file
	Name string

	// should the debug logs be output to stdout
	DebugLog bool

	// SwaggerSpecExpanded is a flattened version of the Swagger spec into a single file
	SwaggerSpecExpanded *analysis.Spec

	// SwaggerSpecWithReferences is the same as Swagger Spec Expanded but contains the 'ref' details
	SwaggerSpecWithReferences *analysis.Spec

	SwaggerSpecRaw *spec.Swagger

	SwaggerSpecExtendedRaw *spec.Swagger
}
