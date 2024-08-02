// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package pipeline

import (
	"fmt"
	"strconv"
	"strings"

	"github.com/hashicorp/go-azure-helpers/lang/pointer"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/normalize"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/parser"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/components/tags"
	"github.com/hashicorp/pandora/tools/importer-msgraph-metadata/internal/logging"
)

func (p pipelineForService) parseResources(resourceIds parser.ResourceIds, models parser.Models, constants parser.Constants) (resources parser.Resources, err error) {
	resources = make(parser.Resources)
	for pathKey, pathItem := range p.spec.Paths {
		path := strings.Clone(pathKey)
		operations := pathItem.Operations()
		operationTags := make([]string, 0)

		// Check tags and skip
		skip := true
		for _, operation := range operations {
			if tags.Matches(p.service, operation.Tags) {
				operationTags = append(operationTags, operation.Tags...)
				skip = false
				break
			}
		}

		if skip {
			continue
		}

		parsedPath := parser.NewResourceId(path, operationTags)
		lastSegment := parsedPath.Segments[len(parsedPath.Segments)-1]

		// Determine whether to skip a path containing unsupported segment types
		for idx, segment := range parsedPath.Segments {
			if segment.Type == parser.SegmentCast || segment.Type == parser.SegmentFunction {
				logging.Debugf(fmt.Sprintf("Skipping path containing %s at position %d for %q: %v", segment.Type, idx, p.service, path))
				skip = true
				break
			}
		}

		if skip {
			continue
		}

		resourceName := ""
		if r, ok := parsedPath.FullyQualifiedResourceName(pointer.To(parser.ResourceSuffix)); ok {
			resourceName = *r
		}
		if resourceName == "" {
			logging.Warnf(fmt.Sprintf("Path with unknown name was encountered for %q: %v", p.service, path))
			continue
		}

		// Resources by default go into their own category when their final URI segment is a label or user value
		resourceCategory := ""
		if lastSegment.Type == parser.SegmentLabel || lastSegment.Type == parser.SegmentUserValue {
			if fqrn, ok := parsedPath.FullyQualifiedResourceName(nil); ok {
				resourceCategory = *fqrn
			}
		}

		if _, ok := resources[resourceName]; !ok {
			// Create a new resource if not already encountered
			logging.Infof(fmt.Sprintf("Found new resource %q (category %q, service %q, version %q)", resourceName, resourceCategory, p.service, p.apiVersion))

			resources[resourceName] = &parser.Resource{
				Name:       resourceName,
				Category:   resourceCategory,
				Version:    p.apiVersion,
				Service:    normalize.CleanName(p.service),
				Paths:      []parser.ResourceId{parsedPath},
				Operations: make([]parser.Operation, 0),
			}
		} else {
			// Append the current path if the resource was already encountered (used for category matching later)
			resources[resourceName].Paths = append(resources[resourceName].Paths, parsedPath)
		}

		for method, operation := range operations {
			if !tags.Matches(p.service, operation.Tags) {
				continue
			}

			// Determine resource ID and/or URI suffix
			var resourceId *parser.ResourceId
			var uriSuffix *string
			match, ok := resourceIds.MatchIdOrAncestor(parsedPath)
			if ok {
				if match.Id != nil {
					resourceId = match.Id
				}
				if match.Remainder != nil && len(match.Remainder.Segments) > 0 {
					uriSuffix = pointer.To(match.Remainder.ID())

					// When last segment is not a label (e.g. an action, function or cast), adopt the parent resource category,
					// but only if the suffix has one segment, else this could indicate a different parent, in which case
					// we'll attempt a match after parsing all resources.
					if resourceCategory == "" && strings.Count(*uriSuffix, "/") == 1 {
						resourceCategory = resourceId.Name
					}
				}
			} else {
				uriSuffix = &path
			}

			if uriSuffix != nil {
				if uriSuffixParsed := parser.NewResourceId(*uriSuffix, operationTags); uriSuffixParsed.HasUserValue() {
					logging.Infof(fmt.Sprintf("Skipping URI suffix containing user value in resource %q (category %q, service %q, version %q): %q", resourceName, resourceCategory, p.service, p.apiVersion, *uriSuffix))
					continue
				}
			}

			listOperation := false
			responses := make(parser.Responses, 0)
			if operation.Responses != nil {
				for stat, resp := range operation.Responses {
					var status int
					var contentType, responseModel *string
					var responseType *parser.DataType

					if s, err := strconv.Atoi(strings.ReplaceAll(stat, "X", "0")); err == nil {
						status = s
					}
					if status < 200 || status >= 300 {
						continue
					}

					if resp.Value != nil && len(resp.Value.Content) > 0 {
						if resp.Value.Description != nil && strings.Contains(strings.ToLower(*resp.Value.Description), "collection") {
							listOperation = true
						}
						for t, m := range resp.Value.Content {
							contentType = &t

							// Prefer model name from Ref
							if strings.HasPrefix(m.Schema.Ref, parser.RefPrefix) {
								modelName := normalize.CleanName(m.Schema.Ref[len(parser.RefPrefix):])
								responseModel = &modelName
							}

							if m.Schema != nil {
								// Flatten the response SchemaRef for inspection
								if f, _ := parser.FlattenSchemaRef(m.Schema, nil); f != nil {
									if f.Format == "binary" {
										responseType = pointer.To(parser.DataTypeBinary)
										break
									}

									// Derive model from schema title and/or and response type from schema type
									if title := f.Title; title != "" || f.Type != "" {
										if strings.HasPrefix(strings.ToLower(title), "collectionof") {
											title = title[12:]
											listOperation = true
										}

										if responseModel == nil && title != "" {
											if modelName := normalize.CleanName(title); models.Found(modelName) {
												responseModel = &modelName
											}
										}

										if l := parser.FieldType(f.Type, title, responseModel != nil); l != nil {
											responseType = l
										}
									}
								}
							}

							break
						}
					}

					// Use generic DirectoryObject model for List operations ending in "/$ref" where no other model was found
					if listOperation && responseModel == nil && resourceId != nil && len(resourceId.Segments) > 0 && resourceId.Segments[len(resourceId.Segments)-1].Value == "$ref" {
						responseModel = pointer.To("DirectoryObject")
					}

					responses = append(responses, parser.Response{
						Status:      status,
						ContentType: contentType,
						ModelName:   responseModel,
						Type:        responseType,
					})
				}
			}

			var paginationField *string

			operationType := parser.NewOperationType(method)
			if listOperation {
				operationType = parser.OperationTypeList
				paginationField = pointer.To("@odata.nextLink")
			}

			// Skip unknown operations
			if operationType == parser.OperationTypeUnknown {
				logging.Warnf(fmt.Sprintf("Skipping unknown operation type for %q: %v", p.service, path))
				continue
			}

			operationName := ""

			prefixToTrim := normalize.Singularize(normalize.CleanName(p.service))
			if resourceId != nil && uriSuffix == nil {
				prefixToTrim = fmt.Sprintf("%s%s", prefixToTrim, parser.ResourceSuffix)
			}
			shortResourceName := strings.TrimPrefix(resourceName, prefixToTrim)

			operationName = shortResourceName
			if len(operationName) == 0 {
				operationName = resourceName
			}

			switch operationType {
			case parser.OperationTypeList:
				if _, ok = normalize.Verbs.Match(shortResourceName); ok {
					operationName = normalize.Pluralize(normalize.Singularize(operationName))
				} else {
					operationName = fmt.Sprintf("List%s", normalize.Pluralize(normalize.Singularize(operationName)))
				}
			case parser.OperationTypeRead:
				operationName = fmt.Sprintf("Get%s", normalize.Singularize(operationName))
			case parser.OperationTypeCreate:
				if _, ok = normalize.Verbs.Match(shortResourceName); ok {
					operationName = normalize.Singularize(operationName)
				} else if lastSegment.Type == parser.SegmentODataReference {
					operationName = fmt.Sprintf("Add%s", normalize.Singularize(operationName))
				} else {
					operationName = fmt.Sprintf("Create%s", normalize.Singularize(operationName))
				}
			case parser.OperationTypeCreateUpdate:
				operationName = fmt.Sprintf("CreateUpdate%s", normalize.Singularize(operationName))
			case parser.OperationTypeUpdate:
				operationName = fmt.Sprintf("Update%s", normalize.Singularize(operationName))
			case parser.OperationTypeDelete:
				if lastSegment.Type == parser.SegmentODataReference {
					operationName = fmt.Sprintf("Remove%s", normalize.Singularize(operationName))
				} else {
					operationName = fmt.Sprintf("Delete%s", normalize.Singularize(operationName))
				}
			}

			// Determine request model
			var requestModel *string
			var requestType *parser.DataType
			if operation.RequestBody != nil && operation.RequestBody.Value != nil {
				for contentType, content := range operation.RequestBody.Value.Content {
					if content.Schema != nil {
						if schema, _ := parser.FlattenSchemaRef(content.Schema, nil); schema != nil {
							if strings.ToLower(schema.Format) == "binary" {
								requestType = pointer.To(parser.DataTypeBinary)
								break
							}

							if strings.HasPrefix(strings.ToLower(contentType), "application/json") {
								var modelName string
								if strings.HasPrefix(content.Schema.Ref, parser.RefPrefix) {
									// Should be a known model
									if modelName = normalize.CleanName(content.Schema.Ref[len(parser.RefPrefix):]); models.Found(modelName) {
										requestModel = &modelName
										break
									}
								} else if schema.Title != "" {
									// Should be a known model
									if modelName = normalize.CleanName(schema.Title); models.Found(modelName) {
										requestModel = &modelName
										break
									}
								} else if len(schema.Schemas) > 0 {
									// Unique object for this operation
									modelName = fmt.Sprintf("%sRequest", operationName)
									models, constants = parser.Schemas(*schema, modelName, models, constants, false)
									requestModel = &modelName
									break
								}
							}
						}
					}
				}
			}

			if operationType == parser.OperationTypeCreate || operationType == parser.OperationTypeUpdate || operationType == parser.OperationTypeCreateUpdate {
				if resourceId != nil && len(resourceId.Segments) > 0 && resourceId.Segments[len(resourceId.Segments)-1].Value == "$ref" {
					requestModel = pointer.To("DirectoryObject")
				}
			}

			resources[resourceName].Operations = append(resources[resourceName].Operations, parser.Operation{
				Name:            operationName,
				Type:            operationType,
				Method:          method,
				ResourceId:      resourceId,
				UriSuffix:       uriSuffix,
				RequestModel:    requestModel,
				RequestType:     requestType,
				Responses:       responses,
				PaginationField: paginationField,
				Tags:            operation.Tags,
			})
		}
	}

	// Look for resources without a category, then iterate the known paths of it and all potential parent resources
	// to find a match by truncating its path to the preceding label segment. Once a match is found, adopt the
	// resource category of the matched parent to ensure they are grouped together.
	for _, resource := range resources {
		pathsLen := len(resource.Paths)
		if resource.Category != "" || pathsLen == 0 {
			continue
		}

		for _, path := range resource.Paths {
			trimmedPath := path.TruncateToLastSegmentOfTypeBeforeSegment([]parser.ResourceIdSegmentType{parser.SegmentLabel}, -1)
			if trimmedPath == nil {
				continue
			}

			for _, parentResource := range resources {
				if parentResource.Category == "" {
					continue
				}

				for _, parentPath := range parentResource.Paths {
					if parentPath.ID() == trimmedPath.ID() {
						resource.Category = parentResource.Category
						break
					}
				}
			}
		}
	}

	// Loop through resources and trim the leading word if it matches the category _and_ there are more words after it
	for _, resource := range resources {
		if resource.Service == "" || resource.Category == "" {
			continue
		}

		serviceSingularized := normalize.Singularize(resource.Service)
		if strings.HasPrefix(resource.Category, serviceSingularized) {
			trimmedCategory := strings.TrimPrefix(resource.Category, serviceSingularized)
			if len(trimmedCategory) > 1 {
				resource.Category = trimmedCategory
			}
		}
	}

	return
}
