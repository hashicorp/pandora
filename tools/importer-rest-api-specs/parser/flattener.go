package parser

import (
	"fmt"
	"path/filepath"
	"strings"

	"github.com/go-openapi/analysis"
	"github.com/go-openapi/loads"
)

// Load loads the swagger document and flattens it to ensure this contains
// all of the properties within a single file, which makes this easier to parse-out
// This can then be used with the Parser
func Load(directory string, fileName string, debugLogging bool) (*SwaggerDefinition, error) {
	filePath := filepath.Join(directory, fileName)

	// parsing this twice looks silly, so why are we doing this?
	// we want the name and the properties of the objects, and the "expanded" version
	// removes the names - it could be we can patch this to also include this, but
	// for the moment there's essentially no harm to doing both
	swaggerDocWithReferences, err := loads.Spec(filePath)
	if err != nil {
		return nil, fmt.Errorf("loading swagger file %q: %+v", filePath, err)
	}
	flattenedWithReferencesOpts := &analysis.FlattenOpts{
		Minimal:      true,
		Verbose:      true,
		Expand:       true,
		RemoveUnused: false,
		//ContinueOnError: true,

		BasePath: swaggerDocWithReferences.SpecFilePath(),
		Spec:     analysis.New(swaggerDocWithReferences.Spec()),
	}
	if err := analysis.Flatten(*flattenedWithReferencesOpts); err != nil {
		return nil, fmt.Errorf("flattening swagger file with references %q: %+v", filePath, err)
	}

	expandedSwaggerDoc, err := loads.Spec(filePath)
	if err != nil {
		return nil, fmt.Errorf("loading swagger file %q: %+v", filePath, err)
	}
	flattenedExpandedOpts := &analysis.FlattenOpts{
		Minimal:      true,
		Verbose:      true,
		Expand:       false,
		RemoveUnused: false,
		//ContinueOnError: true,

		BasePath: expandedSwaggerDoc.SpecFilePath(),
		Spec:     analysis.New(expandedSwaggerDoc.Spec()),
	}
	if err := analysis.Flatten(*flattenedExpandedOpts); err != nil {
		return nil, fmt.Errorf("flattening expanded swagger file %q: %+v", filePath, err)
	}

	serviceName := strings.Title(strings.TrimSuffix(fileName, ".json"))
	swaggerSpecExpanded := expandedSwaggerDoc.Analyzer
	swaggerSpecWithReferences := swaggerDocWithReferences.Analyzer

	swaggerSpecRaw := expandedSwaggerDoc.Spec()

	return &SwaggerDefinition{
		Name:                      serviceName,
		debugLog:                  debugLogging,
		swaggerSpecExpanded:       swaggerSpecExpanded,
		swaggerSpecWithReferences: swaggerSpecWithReferences,
		swaggerSpecRaw:            swaggerSpecRaw,
	}, nil
}
