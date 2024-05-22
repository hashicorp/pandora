// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package pipeline

import (
	"fmt"
	"strconv"
	"strings"
)

func (p pipelineTask) parseResourcesForService(resourceIds ResourceIds, models Models) (resources Resources, err error) {
	resources = make(Resources)
	for pathKey, pathItem := range p.spec.Paths {
		path := strings.Clone(pathKey)
		operations := pathItem.Operations()
		operationTags := make([]string, 0)

		// Check tags and skip
		skip := true
		for _, operation := range operations {
			if tagMatches(p.service, operation.Tags) {
				operationTags = append(operationTags, operation.Tags...)
				skip = false
				break
			}
		}

		parsedPath := NewResourceId(path, operationTags)
		lastSegment := parsedPath.Segments[len(parsedPath.Segments)-1]

		// Determine whether to skip a path containing unsupported segment types
		for idx, segment := range parsedPath.Segments {
			if segment.Type == SegmentCast || segment.Type == SegmentFunction {
				p.logger.Info(fmt.Sprintf("skipping path containing cast or function at position %d for %q: %v", idx, p.service, path))
				skip = true
				break
			}
		}

		if skip {
			continue
		}

		resourceName := ""
		if r, ok := parsedPath.FullyQualifiedResourceName(&resourceSuffix); ok {
			resourceName = *r
		}
		if resourceName == "" {
			p.logger.Warn(fmt.Sprintf("path with unknown name was encountered for %q: %v", p.service, path))
			continue
		}

		// Resources by default go into their own category when their final URI segment is a label or user value
		resourceCategory := ""
		if lastSegment.Type == SegmentLabel || lastSegment.Type == SegmentUserValue {
			if fqrn, ok := parsedPath.FullyQualifiedResourceName(nil); ok {
				resourceCategory = *fqrn
			}
		}

		if _, ok := resources[resourceName]; !ok {
			// Create a new resource if not already encountered
			p.logger.Info(fmt.Sprintf("found new resource %q (category %q, service %q, version %q)", resourceName, resourceCategory, p.service, p.apiVersion))

			resources[resourceName] = &Resource{
				Name:       resourceName,
				Category:   resourceCategory,
				Version:    p.apiVersion,
				Service:    cleanName(p.service),
				Paths:      []ResourceId{parsedPath},
				Operations: make([]Operation, 0),
			}
		} else {
			// Append the current path if the resource was already encountered (used for category matching later)
			resources[resourceName].Paths = append(resources[resourceName].Paths, parsedPath)
		}

		for method, operation := range operations {
			if !tagMatches(p.service, operation.Tags) {
				continue
			}

			// Determine resource ID and/or URI suffix
			var resourceId *ResourceId
			var uriSuffix *string
			match, ok := resourceIds.MatchIdOrAncestor(parsedPath)
			if ok {
				if match.Id != nil {
					resourceId = match.Id
				}
				if match.Remainder != nil && len(match.Remainder.Segments) > 0 {
					uriSuffix = pointerTo(match.Remainder.ID())

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
				if uriSuffixParsed := NewResourceId(*uriSuffix, operationTags); uriSuffixParsed.HasUserValue() {
					p.logger.Info(fmt.Sprintf("skipping URI suffix containing user value in resource %q (category %q, service %q, version %q): %q", resourceName, resourceCategory, p.service, p.apiVersion, *uriSuffix))
					continue
				}
			}

			listOperation := false
			responses := make(Responses, 0)
			if operation.Responses != nil {
				for stat, resp := range operation.Responses {
					var status int
					var contentType, responseModel *string
					var responseType *DataType

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

							unsupportedTypes := []string{"text/plain"}
							for _, unsupportedType := range unsupportedTypes {
								if strings.HasPrefix(strings.ToLower(t), unsupportedType) {
									p.logger.Info(fmt.Sprintf("skipping response with unsupported content-type %q for %q: %v", unsupportedType, p.service, path))
									continue
								}
							}

							// Prefer model name from Ref
							if strings.HasPrefix(m.Schema.Ref, refPrefix) {
								modelName := cleanName(m.Schema.Ref[len(refPrefix):])
								responseModel = &modelName
							}

							if m.Schema != nil {
								// Flatten the response SchemaRef for inspection
								if f, _ := flattenSchemaRef(m.Schema, nil); f != nil {
									if f.Format == "binary" {
										responseType = pointerTo(DataTypeBinary)
										break
									}

									// Derive model and response type from title
									if title := f.Title; title != "" || f.Type != "" {
										if strings.HasPrefix(strings.ToLower(title), "collectionof") {
											title = title[12:]
											listOperation = true
										}

										if responseModel == nil && title != "" {
											if modelName := cleanName(title); models.Found(modelName) {
												responseModel = &modelName
											}
										}

										if l := fieldType(f.Type, title, responseModel != nil); l != nil {
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
						responseModel = pointerTo("DirectoryObject")
					}

					responses = append(responses, Response{
						Status:      status,
						ContentType: contentType,
						ModelName:   responseModel,
						Type:        responseType,
					})
				}
			}

			operationType := NewOperationType(method)
			if listOperation {
				operationType = OperationTypeList
			}

			// Skip unknown operations
			if operationType == OperationTypeUnknown {
				p.logger.Info(fmt.Sprintf("skipping unknown operation type for %q: %v", p.service, path))
				continue
			}

			operationName := ""

			prefixToTrim := singularize(cleanName(p.service))
			if resourceId != nil && uriSuffix == nil {
				prefixToTrim = fmt.Sprintf("%sById", prefixToTrim)
			}
			shortResourceName := strings.TrimPrefix(resourceName, prefixToTrim)

			switch operationType {
			case OperationTypeList:
				if _, ok = verbs.match(shortResourceName); ok {
					operationName = pluralize(singularize(resourceName))
				} else {
					operationName = fmt.Sprintf("List%s", pluralize(singularize(resourceName)))
				}
			case OperationTypeRead:
				operationName = fmt.Sprintf("Get%s", singularize(resourceName))
			case OperationTypeCreate:
				if _, ok = verbs.match(shortResourceName); ok {
					operationName = singularize(resourceName)
				} else if lastSegment.Type == SegmentODataReference {
					operationName = fmt.Sprintf("Add%s", singularize(resourceName))
				} else {
					operationName = fmt.Sprintf("Create%s", singularize(resourceName))
				}
			case OperationTypeCreateUpdate:
				operationName = fmt.Sprintf("CreateUpdate%s", singularize(resourceName))
			case OperationTypeUpdate:
				operationName = fmt.Sprintf("Update%s", singularize(resourceName))
			case OperationTypeDelete:
				if lastSegment.Type == SegmentODataReference {
					operationName = fmt.Sprintf("Remove%s", singularize(resourceName))
				} else {
					operationName = fmt.Sprintf("Delete%s", singularize(resourceName))
				}
			}

			// Determine request model
			var requestModel *string
			var requestType *DataType
			if operation.RequestBody != nil && operation.RequestBody.Value != nil {
				for contentType, content := range operation.RequestBody.Value.Content {
					if content.Schema != nil {
						if schema, _ := flattenSchemaRef(content.Schema, nil); schema != nil {
							if strings.ToLower(schema.Format) == "binary" {
								requestType = pointerTo(DataTypeBinary)
								break
							}

							if strings.HasPrefix(strings.ToLower(contentType), "application/json") {
								var modelName string
								if strings.HasPrefix(content.Schema.Ref, refPrefix) {
									// Should be a known model
									if modelName = cleanName(content.Schema.Ref[len(refPrefix):]); models.Found(modelName) {
										requestModel = &modelName
										break
									}
								} else if schema.Title != "" {
									// Should be a known model
									if modelName = cleanName(schema.Title); models.Found(modelName) {
										requestModel = &modelName
										break
									}
								} else if len(schema.Schemas) > 0 {
									// Unique object for this operation
									modelName = fmt.Sprintf("%sRequest", operationName)
									models = parseSchemas(*schema, modelName, models, false)
									requestModel = &modelName
									break
								}
							}
						}
					}
				}
			}

			if operationType == OperationTypeCreate || operationType == OperationTypeUpdate || operationType == OperationTypeCreateUpdate {
				if resourceId != nil && len(resourceId.Segments) > 0 && resourceId.Segments[len(resourceId.Segments)-1].Value == "$ref" {
					requestModel = pointerTo("DirectoryObject")
				}
			}

			resources[resourceName].Operations = append(resources[resourceName].Operations, Operation{
				Name:         operationName,
				Type:         operationType,
				Method:       method,
				ResourceId:   resourceId,
				UriSuffix:    uriSuffix,
				RequestModel: requestModel,
				RequestType:  requestType,
				Responses:    responses,
				Tags:         operation.Tags,
			})
		}
	}

	for _, resource := range resources {
		// Look for resources without a category, then iterate the known paths of it and all potential parent resources
		// to find a match by truncating its path to the preceding label segment. Once a match is found, adopt the
		// resource category of the matched parent to ensure they are grouped together.
		if pathsLen := len(resource.Paths); resource.Category == "" && pathsLen > 0 {
			for _, path := range resource.Paths {
				if trimmedPath := path.TruncateToLastSegmentOfTypeBeforeSegment([]ResourceIdSegmentType{SegmentLabel}, -1); trimmedPath != nil {
					for _, parentResource := range resources {
						if parentResource.Category != "" {
							for _, parentPath := range parentResource.Paths {
								if parentPath.ID() == trimmedPath.ID() {
									resource.Category = parentResource.Category
									break
								}
							}
						}
					}
				}
			}
		}
	}

	return
}
