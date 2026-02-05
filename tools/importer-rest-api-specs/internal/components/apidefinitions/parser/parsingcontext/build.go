// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package parsingcontext

import (
	"fmt"
	"net/url"
	"path/filepath"
	"strings"

	"github.com/go-openapi/analysis"
	"github.com/go-openapi/loads"
	"github.com/go-openapi/spec"
)

// BuildFromFile loads swagger specs from the filesystem and parses them, returning a `Context` struct that contains
// the parsed specs for consumption in the Resource Manager parser.
//
// We are intentionally parsing each swagger file twice and flattening it with different options.
// On the first pass, the file is flattened with the `Minimal: true` option, which  leaves `allOf` refs in place
// and does not inline properties from inherited models. This is the `SwaggerSpecWithReferences` version, and
// allows us to inspect the inheritance tree and properly derive discriminated models.
//
// Note that we also export the `spec.Swagger` struct containing the raw spec. This is currently used in a few
// cases where we want to manually parse the definitions, notably for traversing model inheritance for
// discriminated models.
//
// On the second pass, we flatten with `Minimal: false`, inlines all refs including `allOf`. This is the
// `SwaggerSpecExpanded` version, and is useful because models that inherit from parents will/ have all their
// fields collapsed into that model, making it easier for us to iterate them.
//
// Additionally, on each pass of parsing a swagger file, we iterate the definitions found within it, and manually
// resolve all remote references. This works around buggy behavior in the go-openapi modules where relative paths
// are mangled and thus fail to be ingested. To prevent accidental clobbering of models/constants in external swagger
// files that have the same name, we specifically only compile the models/constants that are being remotely referenced,
// as well as any references they may have to ensure no reference remains unresolved. To trick the `analysis.Flatten`
// function, we strip out the paths in remote references after resolving them, to make it appear like everything was
// loaded from the original swagger file.
func BuildFromFile(filePath string) (*Context, error) {

	// 1. Parse the file, then resolve all remote refs, and flatten without inlining `allOf` references

	// load and parse the spec
	swaggerDocWithReferences, err := loads.Spec(filePath)
	if err != nil {
		return nil, fmt.Errorf("loading swagger file %q: %+v", filePath, err)
	}

	// walk the refs in the loaded spec and resolve any external references
	specWithRemotelyReferencedSchemas, err := resolveExternalSwaggerReferences(swaggerDocWithReferences, filePath)
	if err != nil {
		return nil, fmt.Errorf("could not resolve remote swagger references for %q: %+v", filePath, err)
	}

	// mix-in the remotely referenced schemas from any external swagger documents,
	analysis.Mixin(swaggerDocWithReferences.Spec(), specWithRemotelyReferencedSchemas)

	// flatten the spec, whilst retaining refs instead of inlining them
	basePath := swaggerDocWithReferences.SpecFilePath()
	flattenedWithReferencesOpts := &analysis.FlattenOpts{
		Minimal:      true,
		Verbose:      true,
		Expand:       false,
		RemoveUnused: false,

		BasePath: basePath,
		Spec:     analysis.New(swaggerDocWithReferences.Spec()),
	}
	if err = analysis.Flatten(*flattenedWithReferencesOpts); err != nil {
		return nil, fmt.Errorf("flattening swagger file with references %q: %+v", filePath, err)
	}

	// 2. Now parse the file again, resolve all remote refs and flatten completely, inlining complex refs such as `allOf`

	// load and parse the spec
	expandedSwaggerDoc, err := loads.Spec(filePath)
	if err != nil {
		return nil, fmt.Errorf("loading swagger file %q: %+v", filePath, err)
	}

	// populate the `consumes` on the operations with the explicit global value if nil
	globalConsumes := expandedSwaggerDoc.Spec().Consumes

	if paths := expandedSwaggerDoc.Spec().Paths; paths != nil {
		for path, item := range expandedSwaggerDoc.Spec().Paths.Paths {
			// Operations to check: Get, Post, Put, Delete, etc.
			ops := []*spec.Operation{item.Get, item.Post, item.Put, item.Delete, item.Patch}

			for _, op := range ops {
				if op == nil {
					continue
				}

				// Logical Check: if operation 'consumes' is empty, inherit from global
				effectiveConsumes := op.Consumes
				if len(effectiveConsumes) == 0 {
					effectiveConsumes = globalConsumes
				}

				ops := []*spec.Operation{
					item.Post, item.Put,
					item.Delete, item.Patch, item.Options,
				}

				for _, op := range ops {
					if op != nil {
						// Only overwrite if the operation doesn't have its own specific values
						// or if you want to force the global values everywhere.
						if len(op.Consumes) == 0 {
							op.Consumes = globalConsumes
						}
					}
				}

				swaggerDocWithReferences.Spec().Paths.Paths[path] = item

				// Proceed with effectiveConsumes...
			}
		}
	}

	// walk the refs in the loaded spec and resolve any external references
	specWithRemotelyReferencedSchemas, err = resolveExternalSwaggerReferences(expandedSwaggerDoc, filePath)
	if err != nil {
		return nil, fmt.Errorf("could not resolve remote swagger references for %q: %+v", filePath, err)
	}

	// mix-in the refs from any external swagger documents,
	analysis.Mixin(expandedSwaggerDoc.Spec(), specWithRemotelyReferencedSchemas)

	// flatten the spec, inlining any refs
	basePath = expandedSwaggerDoc.SpecFilePath()
	flattenedExpandedOpts := &analysis.FlattenOpts{
		Minimal:      false,
		Verbose:      true,
		Expand:       false,
		RemoveUnused: false,

		BasePath: basePath,
		Spec:     analysis.New(expandedSwaggerDoc.Spec()),
	}
	if err = analysis.Flatten(*flattenedExpandedOpts); err != nil {
		return nil, fmt.Errorf("flattening expanded swagger file %q: %+v", filePath, err)
	}

	return &Context{
		FilePath: filePath,

		SwaggerSpecWithReferences:    swaggerDocWithReferences.Analyzer,
		SwaggerSpecWithReferencesRaw: swaggerDocWithReferences.Spec(),

		SwaggerSpecExpanded: expandedSwaggerDoc.Analyzer,
	}, nil
}

// resolveExternalSwaggerReferences attempts to resolve all external refs in the current document. each external ref
// will be parsed and resolved recursively, until all possible references have been collated and returned in a *spec.Swagger
// containing all these definitions.
// We are doing this because the go-openapi parser has very buggy relative path resolution logic, and is unable to
// resolve relative paths in external referenced swagger files that are not located in the current directory.
func resolveExternalSwaggerReferences(input *loads.Document, filePath string) (*spec.Swagger, error) {
	externalReferences := make(map[string]spec.Schema)

	dir, _ := filepath.Split(filePath)

	if input.Analyzer != nil {
		refs := input.Analyzer.AllRefs()
		for _, ref := range refs {
			path := ref.GetURL().Path
			if path == "" {
				// don't resolve refs in the same document
				continue
			}

			if err := resolveRefsForModel(ref, filePath, dir, input, externalReferences); err != nil {
				return nil, fmt.Errorf("resolving external ref %q in %q: %+v", ref.String(), filePath, err)
			}
		}
	}

	return &spec.Swagger{
		SwaggerProps: spec.SwaggerProps{
			Definitions: externalReferences,
		},
	}, nil
}

// resolveRefsForModel accepts a reference to a model, and attempts to resolve it by loading an external swagger file,
// or finding it in the current swagger document. Once loaded, it is added to the `refs` map and recursively
// inspected for any refs so that they may also be resolved.
func resolveRefsForModel(ref spec.Ref, filePath, topLevelDir string, doc *loads.Document, refs map[string]spec.Schema) error {
	// ignore parameters as we don't use these. we might need to include these at some point, if the go-openapi parser
	// is unable to resolve them internally (which has not happened yet)
	if strings.HasPrefix(ref.GetURL().Fragment, "/parameters/") {
		return nil
	}

	// determine the model name, and a swagger doc where it should be defined
	modelName, modelFilePath := modelNamePathFromRef(ref, filePath, topLevelDir)

	// the path in the ref will no longer be needed, as we are going to resolve it ourselves
	// we can do this because `ReferenceURL` is a *url.URL, so this will thankfully propagate upstream
	ref.Ref.ReferenceURL.Path = ""

	if _, ok := refs[modelName]; ok {
		// skip if this has already been resolved
		return nil
	}

	if modelFilePath == "" {
		// no valid swagger doc was found for this model
		return fmt.Errorf("swagger document not found for ref: %s", ref.String())
	}

	// decide whether to look for the model definition in the current file, or another referenced file
	refDoc := doc
	if modelFilePath != filePath {
		newDoc, err := loads.Spec(modelFilePath)
		if err != nil {
			return fmt.Errorf("load swagger %s: %+v", modelFilePath, err)
		}

		refDoc = newDoc
	}

	// retrieve the resolved model
	resolvedModel, ok := refDoc.Spec().Definitions[modelName]
	if !ok {
		return fmt.Errorf("resolve ref %s from %s: model not found", ref.String(), filePath)
	}
	refs[modelName] = resolvedModel

	// look for any refs in the properties (fields) of the resolved model
	if err := resolveRefsForProperties(resolvedModel.Properties, modelFilePath, topLevelDir, refDoc, refs); err != nil {
		return err
	}

	// some models use `additionalProperties`, these may contain refs
	if resolvedModel.AdditionalProperties != nil && resolvedModel.AdditionalProperties.Schema != nil {
		if resolvedModel.AdditionalProperties.Schema.Ref.String() != "" {
			if err := resolveRefsForModel(resolvedModel.AdditionalProperties.Schema.Ref, modelFilePath, topLevelDir, refDoc, refs); err != nil {
				return err
			}
		}
	}

	// some models use a top-level `items`, i.e. in the case of a type array(object)
	if items := resolvedModel.Items; items != nil && items.Schema != nil && items.Schema.Ref.String() != "" {
		if err := resolveRefsForModel(items.Schema.Ref, modelFilePath, topLevelDir, refDoc, refs); err != nil {
			return err
		}
	}

	// look for parent models - this could be a plain child model, or a discriminated implementation
	for _, allOf := range resolvedModel.AllOf {
		if allOf.Ref.String() != "" {
			if err := resolveRefsForModel(allOf.Ref, modelFilePath, topLevelDir, refDoc, refs); err != nil {
				return err
			}
		}
	}

	// if this is a parent model, look for implementations. this will currently only work for children defined in
	// the same swagger file.
	if resolvedModel.Discriminator != "" {
		for defName, def := range refDoc.Spec().Definitions {
			if defName == modelName {
				// skip over self, cannot be own parent
				continue
			}

			// look at parent types for each model and see if this model is the parent
			for _, allOf := range def.AllOf {
				if allOf.Ref.String() != "" {
					allOfRefModelName, _ := modelNamePathFromRef(allOf.Ref, modelFilePath, topLevelDir)
					if modelName == allOfRefModelName {

						// this is an implementation of our parent, so construct a Ref for it and attempt to resolve it
						childRef, err := spec.NewRef("#/definitions/" + defName)
						if err != nil {
							return fmt.Errorf("constructing a Ref for %q: %v", defName, err)
						}

						if err = resolveRefsForModel(childRef, modelFilePath, topLevelDir, refDoc, refs); err != nil {
							return err
						}
						break
					}
				}
			}
		}
	}

	return nil
}

// resolveRefsForProperties attempts to resolve any references contained within the properties for a model
func resolveRefsForProperties(properties spec.SchemaProperties, modelFilePath, topLevelDir string, refDoc *loads.Document, refs map[string]spec.Schema) error {
	for _, prop := range properties {
		// some property types inherit from another model
		for _, allOf := range prop.AllOf {
			if allOf.Ref.String() != "" {
				if err := resolveRefsForModel(allOf.Ref, modelFilePath, topLevelDir, refDoc, refs); err != nil {
					return err
				}
			}
		}

		// some properties use `additionalProperties`
		if prop.AdditionalProperties != nil && prop.AdditionalProperties.Schema != nil {
			if prop.AdditionalProperties.Schema.Ref.String() != "" {
				if err := resolveRefsForModel(prop.AdditionalProperties.Schema.Ref, modelFilePath, topLevelDir, refDoc, refs); err != nil {
					return err
				}
			}

			if items := prop.AdditionalProperties.Schema.Items; items != nil && items.Schema != nil && items.Schema.Ref.String() != "" {
				if err := resolveRefsForModel(items.Schema.Ref, modelFilePath, topLevelDir, refDoc, refs); err != nil {
					return err
				}
			}
		}

		// look for a model referenced directly by the property
		if prop.Ref.String() != "" {
			if err := resolveRefsForModel(prop.Ref, modelFilePath, topLevelDir, refDoc, refs); err != nil {
				return err
			}
		}

		// look for a model referenced directly by the items of a property (i.e. for array elements)
		if items := prop.Items; items != nil && items.Schema != nil && items.Schema.Ref.String() != "" {
			if err := resolveRefsForModel(items.Schema.Ref, modelFilePath, topLevelDir, refDoc, refs); err != nil {
				return err
			}
		}

		// recursively resolve any refs for properties which have inlined models
		if err := resolveRefsForProperties(prop.Properties, modelFilePath, topLevelDir, refDoc, refs); err != nil {
			return err
		}
	}

	return nil
}

// modelNamePathFromRef determines the model name, and the path to the swagger doc that defines it, from a supplied ref
func modelNamePathFromRef(ref spec.Ref, sourcePath, topLevelDir string) (modelName string, modelFilePath string) {
	refUrl := ref.GetURL()
	if refUrl == nil {
		return "", ""
	}

	modelFilePath = refUrl.Path
	if modelFilePath == "" {
		// not an external reference, so use the sourcePath
		modelFilePath = sourcePath
	} else {
		// external reference, so prepend the directory from the sourcePath
		// note: there is a known swagger issue where refs have invalid paths like `.../../cosmos-db.json`, fortunately
		// `filepath.Join` does a good job of cleaning these up and _so far_ these continue to resolve to the actual
		// correct path. if this problem gets worse, this is a good place to add any manual workarounds.
		sourceDir, _ := filepath.Split(sourcePath)
		modelFilePath = filepath.Join(sourceDir, modelFilePath)
	}

	// get the modelName from the last slug in the URL fragment
	fragments := strings.Split(refUrl.Fragment, "/")
	modelName = fragments[len(fragments)-1]

	// url-decode the model name, as it comes from the fragment which might contain urlencoded characters like `[` or `]`
	// ignoring any errors here, since this function will err if invalid escape sequences are present
	modelName, _ = url.QueryUnescape(modelName)

	return
}
