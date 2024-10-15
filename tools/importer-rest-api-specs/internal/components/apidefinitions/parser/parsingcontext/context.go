// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package parsingcontext

import (
	"github.com/go-openapi/analysis"
	"github.com/go-openapi/spec"
)

// Context contains a working set of information about the parsed API Definition.
// This includes the interpretations of the files themselves
type Context struct {
	FilePath string

	// SwaggerSpecWithReferences is the parsed spec with references intact
	SwaggerSpecWithReferences *analysis.Spec

	// SwaggerSpecWithReferencesRaw is the `spec.Swagger` root document, with references intact
	SwaggerSpecWithReferencesRaw *spec.Swagger

	// SwaggerSpecExpanded is the parsed spec with all references resolved, and their target properties inlined
	SwaggerSpecExpanded *analysis.Spec
}
