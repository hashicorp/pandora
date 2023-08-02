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
		if skip {
			continue
		}

		parsedPath := NewResourceId(path, operationTags)
		lastSegment := parsedPath.Segments[len(parsedPath.Segments)-1]
		if lastSegment.Type == SegmentCast || lastSegment.Type == SegmentFunction {
			p.logger.Info(fmt.Sprintf("skipping path containing cast or function for %q: %v", p.service, path))
			continue
		}

		resourceName := ""
		if r, ok := parsedPath.FindResourceName(); ok {
			resourceName = *r
		}
		if resourceName == "" {
			p.logger.Warn(fmt.Sprintf("path with unknown name was encountered for %q: %v", p.service, path))
			continue
		}

		fullyQualifiedResourceName := ""
		if fqrn, ok := parsedPath.FullyQualifiedResourceName(); ok {
			fullyQualifiedResourceName = *fqrn
		}
		if fullyQualifiedResourceName == "" {
			p.logger.Warn(fmt.Sprintf("path with unknown fully-qualified name was encountered for %q: %v", p.service, path))
			continue
		}

		// Resources by default go into their own category when their final URI segment is a label
		resourceCategory := ""
		if lastSegment.Type == SegmentLabel || lastSegment.Type == SegmentUserValue {
			resourceCategory = fullyQualifiedResourceName
		}

		if _, ok := resources[fullyQualifiedResourceName]; !ok {
			// Create a new resource if not already encountered
			p.logger.Info(fmt.Sprintf("found new resource %q (category %q, service %q, version %q)", resourceName, resourceCategory, p.service, p.apiVersion))

			resources[fullyQualifiedResourceName] = &Resource{
				Name:       resourceName,
				Category:   resourceCategory,
				Version:    p.apiVersion,
				Service:    cleanName(p.service),
				Paths:      []ResourceId{parsedPath},
				Operations: make([]Operation, 0),
			}
		} else {
			// Append the current path if the resource was already encountered (used for category matching later)
			resources[fullyQualifiedResourceName].Paths = append(resources[fullyQualifiedResourceName].Paths, parsedPath)
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
					err = fmt.Errorf("encountered URI suffix containing user value in resource %q (category %q, service %q, version %q): %q", resourceName, resourceCategory, p.service, p.apiVersion, *uriSuffix)
					return
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
						for t, m := range resp.Value.Content {
							contentType = &t

							if s := parseSchemaRef(m.Schema); s != nil {
								f, _ := flattenSchema(s, nil)

								if f.Format == "binary" {
									responseType = pointerTo(DataTypeBinary)
									break
								}

								if title := f.Title; title != "" || f.Type != "" {
									if strings.HasPrefix(strings.ToLower(title), "collection of ") {
										title = title[14:]
										listOperation = true
									}

									if modelName := cleanName(title); models.Found(modelName) {
										responseModel = &modelName
									}

									if l := fieldType(f.Type, title, responseModel != nil); l != nil {
										responseType = l
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
				continue
			}

			operationName := ""
			shortResourceName := strings.TrimPrefix(resourceName, singularize(cleanName(p.service)))

			switch operationType {
			case OperationTypeList:
				if _, ok = verbs.match(shortResourceName); ok {
					operationName = resourceName
				} else {
					operationName = fmt.Sprintf("List%s", pluralize(resourceName))
				}
			case OperationTypeRead:
				operationName = fmt.Sprintf("Get%s", resourceName)
			case OperationTypeCreate:
				if _, ok = verbs.match(shortResourceName); ok {
					operationName = resourceName
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
					operationName = fmt.Sprintf("Remove%s", resourceName)
				} else {
					operationName = fmt.Sprintf("Delete%s", resourceName)
				}
			}

			// Trim the "Ref" suffix from operation names
			for _, s := range []string{"Ref", "Refs"} {
				operationName = strings.TrimSuffix(operationName, s)
			}

			// Determine request model
			var requestModel *string
			var requestType *DataType
			if operation.RequestBody != nil && operation.RequestBody.Value != nil {
				for contentType, content := range operation.RequestBody.Value.Content {
					if content.Schema != nil {
						schema, _ := flattenSchema(content.Schema.Value, nil)

						if strings.ToLower(schema.Format) == "binary" {
							requestType = pointerTo(DataTypeBinary)
							break
						}

						if strings.HasPrefix(strings.ToLower(contentType), "application/json") {
							var modelName string
							if schema.Title != "" {
								// Should be a known model
								if modelName = cleanName(schema.Title); models.Found(modelName) {
									requestModel = &modelName
									break
								}
							} else if len(schema.Schemas) > 0 {
								// Unique object for this operation
								modelName = fmt.Sprintf("%sRequest", operationName)
								models = parseSchemas(schema, modelName, models, false)
								requestModel = &modelName
								break
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

			resources[fullyQualifiedResourceName].Operations = append(resources[fullyQualifiedResourceName].Operations, Operation{
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

	// Look for resources without a category, then iterate the known paths of it and all potential parent resources
	// to find a match by truncating its path to the preceding label segment. Once a match is found, adopt the
	// resource category of the matched parent to ensure they are grouped together.
	for _, resource := range resources {
		if pathsLen := len(resource.Paths); resource.Category == "" && pathsLen > 0 {
			for _, path := range resource.Paths {
				if trimmedPath := path.TruncateToLastSegmentOfTypeBeforeSegment([]ResourceIdSegmentType{SegmentLabel}, -1); trimmedPath != nil {
					for _, parentResource := range resources {
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

	return
}
