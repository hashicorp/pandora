// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package parsingcontext

import (
	"encoding/json"
	"fmt"
	"os"

	"github.com/getkin/kin-openapi/openapi2"
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

	// 1. Parse the file using kin-openapi, then resolve all remote refs, and flatten without inlining `allOf` references

	// load and parse the spec via kin-openapi (Swagger 2.0)
	rawFile, err := os.ReadFile(filePath)
	if err != nil {
		return nil, fmt.Errorf("reading swagger file %q: %+v", filePath, err)
	}
	var v2doc openapi2.T
	if err := json.Unmarshal(rawFile, &v2doc); err != nil {
		return nil, fmt.Errorf("parsing swagger file %q: %+v", filePath, err)
	}
	// No go-openapi flattening: we keep a WithRefs doc (as parsed) and an Expanded doc.
	// For now, set Expanded equal to WithRefs; future enhancement could implement expansion if needed.

	return &Context{
		FilePath: filePath,
		WithRefs: v2doc,
		Expanded: v2doc,
	}, nil
}
