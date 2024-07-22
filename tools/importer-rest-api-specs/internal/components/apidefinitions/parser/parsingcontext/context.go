package parsingcontext

import (
	"github.com/go-openapi/analysis"
	"github.com/go-openapi/spec"
)

// Context contains a working set of information about the parsed API Definition.
// This includes the interpretations of the files themselves
type Context struct {
	FilePath string
	
	// SwaggerSpecExpanded contains a flattened version of the Swagger spec into a single file
	SwaggerSpecExpanded *analysis.Spec

	// SwaggerSpecWithReferences is the same as Swagger Spec Expanded but contains the 'ref' details
	SwaggerSpecWithReferences *analysis.Spec

	// TODO: confirm the the need for these two

	SwaggerSpecRaw         *spec.Swagger
	SwaggerSpecExtendedRaw *spec.Swagger
}
