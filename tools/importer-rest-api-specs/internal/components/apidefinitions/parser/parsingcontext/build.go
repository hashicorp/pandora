package parsingcontext

import (
	"fmt"
	"path/filepath"
	"strings"

	"github.com/go-openapi/analysis"
	"github.com/go-openapi/loads"
	"github.com/go-openapi/spec"
	parserModels "github.com/hashicorp/pandora/tools/importer-rest-api-specs/internal/components/apidefinitions/parser/models"
)

func BuildFromFile(filePath string, supplementaryData parserModels.SupplementaryData) (*Context, error) {
	directory := filepath.Dir(filePath)

	// parsing this twice looks silly, so why are we doing this?
	// we want the name and the properties of the objects, and the "expanded" version
	// removes the names - it could be we can patch this to also include this, but
	// for the moment there's essentially no harm to doing both
	swaggerDocWithReferences, err := loads.Spec(filePath)
	if err != nil {
		return nil, fmt.Errorf("loading swagger file %q: %+v", filePath, err)
	}
	swaggerDocWithReferences, err = findAndMergeLocalMixins(swaggerDocWithReferences, directory, filePath)
	if err != nil {
		return nil, fmt.Errorf("could not mixin remote swagger files referenced by %q: %+v", filePath, err)
	}
	flattenedWithReferencesOpts := &analysis.FlattenOpts{
		Minimal:      true,
		Verbose:      true,
		Expand:       false,
		RemoveUnused: false,
		//ContinueOnError: true,

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
	expandedSwaggerDoc, err = findAndMergeLocalMixins(expandedSwaggerDoc, directory, filePath)
	if err != nil {
		return nil, fmt.Errorf("could not mixin remote swagger files referenced by %q: %+v", filePath, err)
	}

	flattenedExpandedOpts := &analysis.FlattenOpts{
		Minimal:      false,
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

	swaggerSpecExpanded := expandedSwaggerDoc.Analyzer
	swaggerSpecExpandedRaw := expandedSwaggerDoc.Spec()
	return &Context{
		FilePath:                  filePath,
		SupplementaryData:         supplementaryData,
		SwaggerSpecExpanded:       swaggerSpecExpanded,
		SwaggerSpecWithReferences: swaggerSpecWithReferences,
		SwaggerSpecRaw:            swaggerSpecWithReferencesRaw,
		SwaggerSpecExtendedRaw:    swaggerSpecExpandedRaw,
	}, nil
}

func findAndMergeLocalMixins(input *loads.Document, basePath string, baseFile string) (*loads.Document, error) {
	if len(strings.Split(baseFile, fmt.Sprintf("%c", filepath.Separator))) != 2 { // We only care about local files, not sub-folders
		return input, nil
	}
	pathsToMixin := make([]string, 0)
	if input.Analyzer != nil {
		allRefs := input.Analyzer.AllRefs()
		for _, v := range allRefs {
			if path := v.Ref.GetURL(); path != nil && path.Path != "" && len(strings.Split(path.Path, "/")) == 2 { // Check if we have a reference in the CWD.
				pathsToMixin = append(pathsToMixin, path.Path)
			}
		}
	}

	if len(pathsToMixin) > 0 {
		uniqueFilter := make(map[string]bool)
		uniquePaths := make([]string, 0)
		for _, path := range pathsToMixin {
			if _, ok := uniqueFilter[path]; !ok {
				uniqueFilter[path] = true
				uniquePaths = append(uniquePaths, path)
			}
		}
		mixins := make([]*spec.Swagger, 0)
		for _, v := range uniquePaths {
			doc, err := loads.Spec(fmt.Sprintf("%s/%s", basePath, v))
			if err != nil {
				return nil, fmt.Errorf("could not load remote ref %q for mixin in %q: %+v", v, baseFile, err)
			}
			mixins = append(mixins, doc.Spec())
		}
		_ = analysis.Mixin(input.Spec(), mixins...)
	}
	return input, nil
}
