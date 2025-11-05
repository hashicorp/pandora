// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package parsingcontext

import (
	"strings"

	"github.com/getkin/kin-openapi/openapi2"
)

// Context contains a working set of information about the parsed API Definition.
// This includes the interpretations of the files themselves
 type Context struct {
	FilePath string

	// WithRefs is the parsed spec with references intact
	WithRefs openapi2.T
	// Expanded is the parsed spec with all references resolved/inlined where applicable
	Expanded openapi2.T
}

// Operations returns a map of HTTP method -> (path -> operation) for the Expanded spec (kin-openapi)
func (c *Context) Operations() map[string]map[string]*openapi2.Operation {
	ops := make(map[string]map[string]*openapi2.Operation)
	for path, item := range c.Expanded.Paths {
		if item.Get != nil {
			addOp(ops, "get", path, item.Get)
		}
		if item.Put != nil {
			addOp(ops, "put", path, item.Put)
		}
		if item.Post != nil {
			addOp(ops, "post", path, item.Post)
		}
		if item.Delete != nil {
			addOp(ops, "delete", path, item.Delete)
		}
		if item.Options != nil {
			addOp(ops, "options", path, item.Options)
		}
		if item.Head != nil {
			addOp(ops, "head", path, item.Head)
		}
		if item.Patch != nil {
			addOp(ops, "patch", path, item.Patch)
		}
	}
	return ops
}

func addOp(m map[string]map[string]*openapi2.Operation, method, path string, op *openapi2.Operation) {
	method = strings.ToLower(method)
	if m[method] == nil {
		m[method] = make(map[string]*openapi2.Operation)
	}
	m[method][path] = op
}

// OperationForID finds an operation in the WithRefs spec by its operationId (kin-openapi)
func (c *Context) OperationForID(id string) (path string, method string, op *openapi2.Operation, found bool) {
	for p, item := range c.WithRefs.Paths {
		if item.Get != nil && item.Get.OperationID == id {
			return p, "get", item.Get, true
		}
		if item.Put != nil && item.Put.OperationID == id {
			return p, "put", item.Put, true
		}
		if item.Post != nil && item.Post.OperationID == id {
			return p, "post", item.Post, true
		}
		if item.Delete != nil && item.Delete.OperationID == id {
			return p, "delete", item.Delete, true
		}
		if item.Options != nil && item.Options.OperationID == id {
			return p, "options", item.Options, true
		}
		if item.Head != nil && item.Head.OperationID == id {
			return p, "head", item.Head, true
		}
		if item.Patch != nil && item.Patch.OperationID == id {
			return p, "patch", item.Patch, true
		}
	}
	return "", "", nil, false
}
