// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package parser

import (
	"fmt"
	"path/filepath"
	"strings"

	"github.com/go-openapi/analysis"
	"github.com/go-openapi/loads"
	"github.com/go-openapi/spec"
)

// load loads the swagger document and flattens it to ensure this contains
// all of the properties within a single file, which makes this easier to parse-out
// This can then be used with the Parser
func load(directory string, fileName string) (*SwaggerDefinition, error) {
	filePath := filepath.Join(directory, fileName)

	// parsing this twice looks silly, so why are we doing this?
	// we want the name and the properties of the objects, and the "expanded" version
	// removes the names - it could be we can patch this to also include this, but
	// for the moment there's essentially no harm to doing both
	swaggerDocWithReferences, err := loads.Spec(filePath)
	if err != nil {
		return nil, fmt.Errorf("loading swagger file %q: %+v", filePath, err)
	}

	localMixins, err := findLocalMixins(swaggerDocWithReferences, filePath)
	if err != nil {
		return nil, fmt.Errorf("could not mixin remote swagger files referenced by %q: %+v", filePath, err)
	}

	flattenedWithReferencesOpts := &analysis.FlattenOpts{
		Minimal:      true,
		Verbose:      true,
		Expand:       false,
		RemoveUnused: false,
		// ContinueOnError: true,

		BasePath: swaggerDocWithReferences.SpecFilePath(),
		Spec:     analysis.New(swaggerDocWithReferences.Spec()),
	}
	if err := analysis.Flatten(*flattenedWithReferencesOpts); err != nil {
		return nil, fmt.Errorf("flattening swagger file with references %q: %+v", filePath, err)
	}

	swaggerSpecWithReferences := swaggerDocWithReferences.Analyzer
	swaggerSpecWithReferencesRaw := swaggerDocWithReferences.Spec()

	expandedSwaggerDoc, err := loads.Spec(filePath)
	if err != nil {
		return nil, fmt.Errorf("loading swagger file %q: %+v", filePath, err)
	}

	_ = analysis.Mixin(expandedSwaggerDoc.Spec(), localMixins)

	flattenedExpandedOpts := &analysis.FlattenOpts{
		Minimal:      false,
		Verbose:      true,
		Expand:       false,
		RemoveUnused: false,
		// ContinueOnError: true,

		BasePath: expandedSwaggerDoc.SpecFilePath(),
		Spec:     analysis.New(expandedSwaggerDoc.Spec()),
	}
	if err := analysis.Flatten(*flattenedExpandedOpts); err != nil {
		return nil, fmt.Errorf("flattening expanded swagger file %q: %+v", filePath, err)
	}

	serviceName := strings.Title(strings.TrimSuffix(fileName, ".json"))

	swaggerSpecExpanded := expandedSwaggerDoc.Analyzer
	swaggerSpecExpandedRaw := expandedSwaggerDoc.Spec()

	return &SwaggerDefinition{
		Name:                      serviceName,
		swaggerSpecExpanded:       swaggerSpecExpanded,
		swaggerSpecWithReferences: swaggerSpecWithReferences,
		swaggerSpecRaw:            swaggerSpecWithReferencesRaw,
		swaggerSpecExtendedRaw:    swaggerSpecExpandedRaw,
	}, nil
}

func findLocalMixins(input *loads.Document, filePath string) (*spec.Swagger, error) {
	mixins := &spec.Swagger{
		SwaggerProps: spec.SwaggerProps{
			Definitions: make(map[string]spec.Schema),
		},
	}

	if input.Analyzer != nil {
		for _, ref := range input.Analyzer.AllRefs() {
			if err := findMixinForRef(ref, filePath, input, mixins); err != nil {
				return nil, fmt.Errorf("find mixin for ref %q in %q: %+v", ref.String(), filePath, err)
			}
		}
	}

	return mixins, nil
}

func findMixinForRef(ref spec.Ref, filePath string, doc *loads.Document, mixins *spec.Swagger) error {
	if path := ref.GetURL(); path == nil || (path.Path != "" && len(strings.Split(path.Path, "/")) != 2) {
		// Check if we have a reference in the CWD. if path.Path is empty string, it refers to the same file
		return nil
	}

	modelName, refFilePath := modelNamePathFromRef(ref, filePath)
	if _, ok := mixins.Definitions[modelName]; ok {
		return nil
	}

	if strings.HasPrefix(ref.GetURL().Fragment, "/parameters/") {
		return nil
	}

	refDoc := doc
	if refFilePath != filePath {
		newDoc, err := loads.Spec(refFilePath)
		if err != nil {
			return fmt.Errorf("load swagger %s: %+v", refFilePath, err)
		}

		refDoc = newDoc
	}
	resolvedModel, ok := refDoc.Spec().Definitions[modelName]
	if !ok {
		return fmt.Errorf("resolve ref %s from %s: model not found", ref.String(), filePath)
	}
	mixins.Definitions[modelName] = resolvedModel

	temp := &spec.Swagger{
		SwaggerProps: spec.SwaggerProps{
			Definitions: map[string]spec.Schema{
				modelName: resolvedModel,
			},
		},
	}

	_, isVariant := resolvedModel.Extensions.GetString("x-ms-discriminator-value")
	if resolvedModel.Discriminator != "" || isVariant {
		for defName, def := range refDoc.Spec().Definitions {
			if defName == modelName {
				continue
			}
			for _, allOf := range def.AllOf {
				if allOf.Ref.String() != "" {
					allOfRefModelName, _ := modelNamePathFromRef(allOf.Ref, refFilePath)
					if modelName == allOfRefModelName {
						mixins.Definitions[defName] = def
						temp.Definitions[defName] = def

						break
					}
				}
			}
		}
	}

	if len(temp.Definitions) > 0 {
		analyzer := analysis.New(temp)
		for _, r := range analyzer.AllRefs() {
			if err := findMixinForRef(r, refFilePath, refDoc, mixins); err != nil {
				return fmt.Errorf("find mixin for ref %q in %q: %+v", r.String(), refFilePath, err)
			}
		}
	}

	return nil
}

func modelNamePathFromRef(ref spec.Ref, filePath string) (modelName string, modelFilePath string) {
	refUrl := ref.GetURL()
	if refUrl == nil {
		return "", ""
	}

	modelFilePath = refUrl.Path
	if modelFilePath == "" {
		modelFilePath = filePath
	} else {
		filePath, _ := filepath.Split(filePath)
		modelFilePath = filepath.Join(filePath, modelFilePath)
	}

	fragments := strings.Split(refUrl.Fragment, "/")
	return fragments[len(fragments)-1], modelFilePath
}
