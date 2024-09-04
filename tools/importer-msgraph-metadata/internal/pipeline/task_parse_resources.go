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

const directoryObjectSchemaName = "microsoft.graph.directoryObject"

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

		// maintainer note: this is a good place to add a breakpoint for inspecting individual resources and their operations
		// example breakpoint conditions:
		//   p.service=="administrativeUnits"
		//   path=="/applications/{application-id}/owners"
		//   len(path)>62 && path[:62]=="/directory/administrativeUnits/{administrativeUnit-id}/members"
		parsedPath := parser.NewResourceId(path, operationTags)
		lastSegment := parsedPath.Segments[len(parsedPath.Segments)-1]

		if len(parsedPath.Segments) == 0 {
			continue
		}

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

		// Determine the resource name
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

		// maintainer note: this is a good place to add a breakpoint for inspecting individual resources and their operations
		// example breakpoint conditions:
		//   resourceName=="ApplicationOwner"
		//   len(resourceName)>27 && resourceName[:27]=="DirectoryAdministrativeUnit"
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
				if resourceCategory == "" && len(match.Remainder.Segments) == 1 &&
					(match.Remainder.Segments[0].Type == parser.SegmentAction || match.Remainder.Segments[0].Type == parser.SegmentCast || match.Remainder.Segments[0].Type == parser.SegmentFunction) {
					resourceCategory = parsedPath.ID()
				}
			}
		} else {
			uriSuffix = pointer.To(parsedPath.ID())
		}

		// Skip this path when the uriSuffix contains a user-specified value. This should ordinarily not occur, but
		// can happen when no parent resource ID has been matched, for example if a resource ID was blacklisted.
		if uriSuffix != nil {
			if uriSuffixParsed := parser.NewResourceId(*uriSuffix, operationTags); uriSuffixParsed.HasUserValue() {
				logging.Infof(fmt.Sprintf("Skipping URI suffix containing user value in resource %q (category %q, service %q, version %q): %q", resourceName, resourceCategory, p.service, p.apiVersion, *uriSuffix))
				continue
			}
		}

		for method, operation := range operations {
			if !tags.Matches(p.service, operation.Tags) {
				continue
			}

			listOperation := false
			responses := make(parser.Responses, 0)
			if operation.Responses != nil {
				for stat, resp := range operation.Responses {
					var status int
					var responseContentType, responseReferenceName *string
					var responseType *parser.DataType
					var responseConstant *parser.Constant
					var responseModel *parser.Model

					if s, err := strconv.Atoi(strings.ReplaceAll(stat, "X", "0")); err == nil {
						status = s
					}
					if status < 200 || status >= 300 {
						continue
					}

					if resp.Value != nil {
						for contentType, content := range resp.Value.Content {
							responseContentType = &contentType

							if content.Schema == nil {
								continue
							}

							switch strings.ToLower(contentType) {
							// Binary payloads are handled by the SDK and unmarshalled into []byte
							case "application/octet-stream", "text/plain", "text/powershell":
								responseType = pointer.To(parser.DataTypeBinary)

							// Supported content types for unmarshalling into a model or other type
							case "application/json", "application/xml", "text/xml":
								// This is a temporary name for the response model until we determine the name of the operation, or find a referenced type name
								schemaName := "ResponseObject"

								// Try to identify constant or model from ref
								if ref := parser.TrimRefPrefix(content.Schema.Ref); ref != "" {
									schemaName = ref
								} else if value := content.Schema.Value; value != nil && value.AnyOf != nil {
									for _, ref := range value.AnyOf {
										if referencedSchemaName := parser.TrimRefPrefix(ref.Ref); referencedSchemaName != "" {
											if schemaName != "ResponseObject" {
												return nil, fmt.Errorf("identifying response object: reference %q already set, cannot set new reference %q", schemaName, referencedSchemaName)
											}

											schemaName = referencedSchemaName
										}
									}
								}

								// Look for a referenced constant or model
								if schemaName != "ResponseObject" {
									if constants.Found(schemaName) {
										responseConstant = constants[schemaName]
										responseReferenceName = &schemaName
										responseType = pointer.To(parser.DataTypeReference)
									} else if models.Found(schemaName) {
										responseModel = models[schemaName]
										responseReferenceName = &schemaName
										responseType = pointer.To(parser.DataTypeReference)
									}
								}

								// If no constant/model was found, build one from the provided schema
								if responseConstant == nil && responseModel == nil {
									model, constant, err := parser.ModelOrConstant(schemaName, content.Schema, false)
									if err != nil {
										return nil, fmt.Errorf("building response model: %v", err)
									}

									if constant == nil && model == nil {
										return nil, fmt.Errorf("building response object: could not find a constant or model for the reference %q", schemaName)
									}
									if constant != nil && model != nil {
										return nil, fmt.Errorf("building response object: received a constant and a model for the reference %q", schemaName)
									}

									if constant != nil {
										responseConstant = constant
										responseReferenceName = &schemaName
										responseType = pointer.To(parser.DataTypeReference)

									} else if model != nil {
										// An empty model will be returned if there is no schema, skip this
										if len(model.Fields) > 0 || model.ParentModel != nil {
											responseModel = model
											responseReferenceName = &schemaName
											responseType = pointer.To(parser.DataTypeReference)
										}
									}
								}

								// GET requests to URIs ending in '/$ref' should always return one or more directoryObjects,
								// but this isn't always described in the spec, so hardcode this.
								if strings.ToUpper(method) == "GET" && lastSegment.Type == parser.SegmentODataReference && lastSegment.Value == "$ref" {
									var value *parser.ModelField
									if responseModel != nil {
										value, _ = responseModel.Fields["value"]
									}
									if value != nil && value.Type != nil && *value.Type == parser.DataTypeArray {
										value.ItemType = pointer.To(parser.DataTypeReference)
										value.ReferenceName = pointer.To(directoryObjectSchemaName)
									} else {
										responseModel = models[directoryObjectSchemaName]
										responseReferenceName = pointer.To(directoryObjectSchemaName)
									}
								}

								if responseModel != nil {
									// When the response comprises a `value` field containing an array, this is probably a
									// paginated list operation, so mark it as such, and take the item type as the response
									// type, since the SDK handles pagination without needing an intermediary model.
									if value, ok := responseModel.Fields["value"]; ok && value.Type != nil && *value.Type == parser.DataTypeArray {
										// Make this a list operation to enable pagination
										listOperation = true

										// Prefer the type of the `value` array item
										if value.ReferenceName != nil {
											// `value` items contain a referenced model
											responseReferenceName = value.ReferenceName
											responseType = pointer.To(parser.DataTypeReference)
										} else if value.ItemType != nil {
											// `value` items contain a simple type
											responseReferenceName = nil
											responseType = value.ItemType
										}
									}
								}

							default:
								return nil, fmt.Errorf("unsupported content-type: %q", contentType)
							}

							break
						}
					}

					responses = append(responses, parser.Response{
						Status:        status,
						ContentType:   responseContentType,
						ReferenceName: responseReferenceName,
						Type:          responseType,
						Constant:      responseConstant,
						Model:         responseModel,
					})
				}
			}

			var paginationField *string

			operationType := parser.NewOperationType(method)
			if listOperation {
				operationType = parser.OperationTypeList
				paginationField = pointer.To("@odata.nextLink")
			}

			// Skip unknown operation types
			if operationType == parser.OperationTypeUnknown {
				logging.Warnf(fmt.Sprintf("Skipping unknown operation type for %q: %v", p.service, path))
				continue
			}

			// Determine the base name of the operation, attempting to trim a leading service name since that is redundant
			operationName := ""

			prefixesToTrim := []string{
				normalize.CleanName(p.service),
				normalize.Singularize(normalize.CleanName(p.service)),
			}
			if resourceId != nil && uriSuffix == nil {
				for i := range prefixesToTrim {
					prefixesToTrim[i] = fmt.Sprintf("%s%s", prefixesToTrim[i], parser.ResourceSuffix)
				}
			}
			shortResourceName := resourceName
			for _, prefixToTrim := range prefixesToTrim {
				shortResourceName = strings.TrimPrefix(shortResourceName, prefixToTrim)
			}

			operationName = shortResourceName
			if len(operationName) == 0 {
				operationName = resourceName
			}

			// Now qualify the operation name based on the type of operation. Additionally, if the operation name
			// matches a known verb, move that verb to the beginning and use it instead of a standard verb.
			// For example, a Create operation for "Application" should get an operation name of "CreateApplication",
			// but a Create operation for "ApplicationTemplateInstantiate" should get an operation name of "InstantiateApplicationTemplate"
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

			// Now that we have determined the operation name, we can rename any ad-hoc response models accordingly and
			// persist them in the global constants or models map. We _might_ have more than one ad-hoc response model,
			// so for subsequent ones we just append an integer to ensure the resulting SDK code compiles. Ad-hoc
			// response models are those that are described in the response but don't exist as a formal constant/model.
			if len(responses) > 0 {
				usedNames := make(map[string]struct{})

				nextAvailableObjectName := func() string {
					proposed := fmt.Sprintf("%sResult", operationName)
					var count int
					for {
						if _, ok := usedNames[proposed]; !ok {
							break
						}
						count++
						proposed = fmt.Sprintf("%s%dResult", operationName, count)
					}
					usedNames[proposed] = struct{}{}
					return proposed
				}

				for i, response := range responses {
					if response.ReferenceName != nil && *response.ReferenceName == "ResponseObject" {
						objectName := nextAvailableObjectName()
						responses[i].ReferenceName = pointer.To(objectName)

						if response.Constant != nil && response.Constant.Name == "ResponseObject" {
							response.Constant.Name = objectName

							// Persist the constant to the global constants
							constants[objectName] = response.Constant
						} else if response.Model != nil && response.Model.Name == "ResponseObject" {
							response.Model.Name = objectName

							// Persist the model to the global models
							models[objectName] = response.Model
						}
					}
				}
			}

			// Determine request model
			var requestContentType, requestModelName *string
			var requestType *parser.DataType
			if operation.RequestBody != nil && operation.RequestBody.Value != nil {
				for contentType, content := range operation.RequestBody.Value.Content {
					requestContentType = &contentType

					if content.Schema == nil {
						continue
					}

					// Binary payloads are handled by the SDK
					if content.Schema.Value != nil && content.Schema.Value.Format == "binary" {
						requestType = pointer.To(parser.DataTypeBinary)
						break
					}

					// Try to locate model from ref
					var requestModel *parser.Model
					if referencedSchemaName := parser.TrimRefPrefix(content.Schema.Ref); referencedSchemaName != "" {
						if models.Found(referencedSchemaName) {
							requestModel = models[referencedSchemaName]
							requestModelName = &referencedSchemaName
						}
					}

					// If no model was found, build one
					if requestModel == nil && content.Schema != nil {
						requestModelName = pointer.To(fmt.Sprintf("%sRequest", operationName))

						model, constant, err := parser.ModelOrConstant(*requestModelName, content.Schema, false)
						if err != nil {
							return nil, fmt.Errorf("building request model: %v", err)
						}
						if constant != nil {
							return nil, fmt.Errorf("building request model: received a constant but expected a model")
						}
						if model == nil {
							return nil, fmt.Errorf("building request model: received a nil model")
						}

						models[*requestModelName] = model
					}

					break
				}
			}

			// Determine request options
			var requestHeaders *parser.Headers
			var requestParams *parser.Params
			headers := make(parser.Headers, 0)
			params := make(parser.Params, 0)
			for _, param := range operation.Parameters {
				if param.Value == nil || param.Value.Schema == nil || param.Value.Schema.Value == nil {
					continue
				}

				paramType := parser.FieldType(param.Value.Schema.Value.Type, param.Value.Schema.Value.Format, false)

				switch param.Value.In {
				case "header":
					headers = append(headers, parser.Header{
						Name: param.Value.Name,
						Type: paramType,
					})
				case "query":
					var itemType *parser.DataType
					if paramType != nil && *paramType == parser.DataTypeArray {
						items := param.Value.Schema.Value.Items
						if items == nil || items.Value == nil {
							return nil, fmt.Errorf("encountered query parameter %q with Array type but no Items", param.Value.Name)
						}
						itemType = parser.FieldType(items.Value.Type, items.Value.Format, false)
					}

					params = append(params, parser.Param{
						Name:     param.Value.Name,
						Type:     paramType,
						ItemType: itemType,
					})
				}
			}
			if len(headers) > 0 {
				requestHeaders = &headers
			}
			if len(params) > 0 {
				requestParams = &params
			}

			// Construct a description for the operation method
			descriptionChunks := make([]string, 0)
			if operation.Summary != "" {
				descriptionChunks = append(descriptionChunks, operation.Summary)
			}
			if operation.Description != "" {
				descriptionChunks = append(descriptionChunks, operation.Description)
			}

			// Trim a trailing colon/semicolon from descriptions because they are confusing
			operationDescription := strings.Join(descriptionChunks, ". ")
			operationDescription = strings.TrimPrefix(operationDescription, ":")
			operationDescription = strings.TrimPrefix(operationDescription, ";")

			resources[resourceName].Operations = append(resources[resourceName].Operations, parser.Operation{
				Name:               operationName,
				Description:        operationDescription,
				Type:               operationType,
				Method:             method,
				ResourceId:         resourceId,
				UriSuffix:          uriSuffix,
				RequestContentType: requestContentType,
				RequestModel:       requestModelName,
				RequestHeaders:     requestHeaders,
				RequestParams:      requestParams,
				RequestType:        requestType,
				Responses:          responses,
				PaginationField:    paginationField,
				Tags:               operation.Tags,
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
