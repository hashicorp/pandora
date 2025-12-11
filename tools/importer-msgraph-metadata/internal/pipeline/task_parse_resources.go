// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package pipeline

import (
	"fmt"
	"net/http"
	"sort"
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

	for pathKey, pathItem := range p.spec.Paths.Map() {
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
			logging.Infof(fmt.Sprintf("Found new resource %q (service %q, version %q)", resourceName, p.service, p.apiVersion))

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
		// can happen when no resource ID has been matched, for example if a resource ID was blacklisted.
		if uriSuffix != nil {
			if uriSuffixParsed := parser.NewResourceId(*uriSuffix, operationTags); uriSuffixParsed.HasUserValue() {
				logging.Infof(fmt.Sprintf("Skipping URI suffix containing user value in resource %q (service %q, version %q): %q", resourceName, p.service, p.apiVersion, *uriSuffix))
				continue
			}
		}

		for method, operation := range operations {
			if !tags.Matches(p.service, operation.Tags) {
				continue
			}

			var responseContentType, responseReferenceName *string
			var responseType *parser.DataType
			var responseConstant *parser.Constant
			var responseModel *parser.Model

			listOperation := false
			if operation.Responses != nil {
				responseFound := false

				for stat, resp := range operation.Responses.Map() {

					var status int
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

							responseFound = true
							break
						}
					}

					if responseFound {
						break
					}
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

			// Determine prefixes to trim from the operation name. At this time we are only trimming the singularized
			// service name from the resource name. There are instances of the pluralized service name being present at
			// the beginning of resource names, but trimming this universally causes some naming conflicts, so we'll
			// live with that.
			prefixesToTrim := []string{
				normalize.Singularize(normalize.CleanName(p.service)),
			}
			if resourceId != nil && uriSuffix == nil {
				for i := range prefixesToTrim {
					prefixesToTrim[i] = fmt.Sprintf("%s%s", prefixesToTrim[i], parser.ResourceSuffix)
				}
			}

			// Trim prefixes from the resourceName to get a shortResourceName, which we'll use to build the operationName and to match for known verbs
			shortResourceName := resourceName
			for _, prefixToTrim := range prefixesToTrim {
				if verb, ok := normalize.Verbs.Match(shortResourceName); ok {
					// resource name starts with a standard verb, so remove it before trimming a prefix
					shortResourceName = *verb + strings.TrimPrefix(strings.TrimPrefix(shortResourceName, *verb), prefixToTrim)
				} else {
					shortResourceName = strings.TrimPrefix(shortResourceName, prefixToTrim)
				}
			}

			// Set the name of the operation using the determined shortResourceName (i.e. resourceName with trimmed prefixes)
			operationName := shortResourceName
			if len(operationName) == 0 {
				// If trimming prefixes truncated the operationName, then use the full resourceName
				operationName = resourceName
			}

			// Remove duplicate words in the operationName
			operationName = normalize.DeDuplicateName(operationName)

			// Since the spec does not distinguish between different 20X status codes, and also because many APIs
			// are inconsistent in the status codes they return, we intentionally support any status codes that
			// make sense for the type of operation.
			statusCodes := make([]int, 0)

			// Now qualify the operation name based on the type of operation. Additionally, if the operation name
			// matches a known verb, move that verb to the beginning and use it instead of a standard verb.
			// For example, a Create operation for "Application" should get an operation name of "CreateApplication",
			// but a Create operation for "ApplicationTemplateInstantiate" should get an operation name of "InstantiateApplicationTemplate"
			switch operationType {
			case parser.OperationTypeList:
				statusCodes = []int{http.StatusOK}
				if _, ok = normalize.Verbs.Match(shortResourceName); ok {
					operationName = normalize.Pluralize(normalize.Singularize(operationName))
				} else {
					operationName = fmt.Sprintf("List%s", normalize.Pluralize(normalize.Singularize(operationName)))
				}

			case parser.OperationTypeRead:
				statusCodes = []int{http.StatusOK}
				operationName = fmt.Sprintf("Get%s", normalize.Singularize(operationName))

			case parser.OperationTypeCreate:
				statusCodes = []int{
					http.StatusOK,
					http.StatusCreated,
					http.StatusAccepted,
					http.StatusNoContent,
				}
				if _, ok = normalize.Verbs.Match(shortResourceName); !ok {
					if lastSegment.Type == parser.SegmentODataReference {
						operationName = fmt.Sprintf("Add%s", normalize.Singularize(operationName))
					} else {
						operationName = fmt.Sprintf("Create%s", normalize.Singularize(operationName))
					}
				}

			case parser.OperationTypeCreateUpdate:
				statusCodes = []int{
					http.StatusOK,
					http.StatusCreated,
					http.StatusAccepted,
					http.StatusNoContent,
				}
				operationName = fmt.Sprintf("Set%s", normalize.Singularize(operationName))

			case parser.OperationTypeUpdate:
				statusCodes = []int{
					http.StatusOK,
					http.StatusAccepted,
					http.StatusNoContent,
				}
				operationName = fmt.Sprintf("Update%s", normalize.Singularize(operationName))

			case parser.OperationTypeDelete:
				statusCodes = []int{
					http.StatusOK,
					http.StatusNoContent,
				}
				if lastSegment.Type == parser.SegmentODataReference {
					operationName = fmt.Sprintf("Remove%s", operationName)
				} else {
					operationName = fmt.Sprintf("Delete%s", operationName)
				}
			}

			// Now that we have determined the operation name, we can rename any ad-hoc response models accordingly and
			// persist them in the global constants or models map. Though unlikely, we _might_ have more than one ad-hoc
			// response model, so for any subsequent ones we just append an integer to ensure the resulting SDK code compiles.
			// Ad-hoc response models are those that are described in the response but don't exist as a formal constant/model.
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

			if responseReferenceName != nil && *responseReferenceName == "ResponseObject" {
				objectName := nextAvailableObjectName()
				responseReferenceName = pointer.To(objectName)

				if responseConstant != nil && responseConstant.Name == "ResponseObject" {
					responseConstant.Name = objectName

					// Persist the constant to the global constants
					constants[objectName] = responseConstant
				} else if responseModel != nil && responseModel.Name == "ResponseObject" {
					responseModel.Name = objectName

					// Persist the model to the global models
					models[objectName] = responseModel
				}
			}

			// Determine request model
			var requestContentType, requestModelName *string
			var requestModel *parser.Model
			var requestType *parser.DataType
			if operation.RequestBody != nil && operation.RequestBody.Value != nil {
				for contentType, content := range operation.RequestBody.Value.Content {
					requestContentType = &contentType

					if content.Schema == nil {
						continue
					}

					if content.Schema.Value != nil && content.Schema.Value.Format == "binary" {
						// Set the request type to Binary. When translating to Data API SDK types, we will also work in a
						// ContentType option to be set by the caller.
						requestType = pointer.To(parser.DataTypeBinary)
						break
					}

					// Try to locate a common model from ref
					if referencedSchemaName := parser.TrimRefPrefix(content.Schema.Ref); referencedSchemaName != "" && models.Found(referencedSchemaName) {
						requestModelName = &referencedSchemaName

					} else if content.Schema != nil {
						// If no model was found, build one
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

						requestModel = model
					}

					break
				}
			}

			// Determine request options
			var requestHeaders *[]parser.Header
			var requestParams *[]parser.Param
			headers := make([]parser.Header, 0)
			params := make([]parser.Param, 0)
			for _, param := range operation.Parameters {
				if param.Value == nil || param.Value.Schema == nil || param.Value.Schema.Value == nil {
					continue
				}

				paramType := parser.FieldType(param.Value.Schema.Value.Type.Slice(), param.Value.Schema.Value.Format, false)

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
						itemType = parser.FieldType(items.Value.Type.Slice(), items.Value.Format, false)
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
				descriptionChunks = append(descriptionChunks, strings.TrimSpace(operation.Summary))
			}
			if operation.Description != "" {
				descriptionChunks = append(descriptionChunks, strings.TrimSpace(operation.Description))
			}

			// Trim a trailing colon/semicolon from descriptions because they are confusing
			operationDescription := strings.Join(descriptionChunks, ". ")
			operationDescription = strings.TrimRight(operationDescription, ":;")

			// Save the operation
			resources[resourceName].Operations = append(resources[resourceName].Operations, parser.Operation{
				Name:                  operationName,
				Description:           operationDescription,
				Type:                  operationType,
				Method:                method,
				ResourceId:            resourceId,
				UriSuffix:             uriSuffix,
				PaginationField:       paginationField,
				RequestContentType:    requestContentType,
				RequestModelName:      requestModelName,
				RequestModel:          requestModel,
				RequestHeaders:        requestHeaders,
				RequestParams:         requestParams,
				RequestType:           requestType,
				ResponseStatusCodes:   statusCodes,
				ResponseContentType:   responseContentType,
				ResponseReferenceName: responseReferenceName,
				ResponseType:          responseType,
				ResponseConstant:      responseConstant,
				ResponseModel:         responseModel,
				Tags:                  operation.Tags,
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

	// Clean up category names
	for _, resource := range resources {
		if resource.Service == "" || resource.Category == "" {
			continue
		}

		// Trim the leading word if it matches the category _and_ there are more words after it
		serviceSingularized := normalize.Singularize(resource.Service)
		if strings.HasPrefix(resource.Category, serviceSingularized) {
			trimmedCategory := strings.TrimPrefix(resource.Category, serviceSingularized)
			if len(trimmedCategory) > 1 {
				resource.Category = trimmedCategory
			}
		}

		// Remove duplicate words in the category
		// TODO: Figure out whether we can do this safely; causes clobbering in identityGovernance, e.g.
		// EntitlementManagementAccessPackageResourceRoleScopeClient vs EntitlementManagementAccessPackageAccessPackageResourceRoleScopeClient
		// resource.Category = normalize.DeDuplicateName(resource.Category)
	}

	// Look for resources with no operations, as well as duplicate operations. For duplicate operations drop the one with the
	// shortest path. This can happen when very similar paths resolve to the same resource name, and they have conflicting
	// operation types. For example, if we get two paths like these...
	//   /policies/featureRolloutPolicies/{featureRolloutPolicyId}/appliesTo
	//   /policies/featureRolloutPolicies/{featureRolloutPolicyId}/appliesTo/{directoryObjectId}
	// ...and they both have a DELETE operation, then these will end up as operations in the same resource, and one of them
	// will clobber the other when these are persisted as API Definitions. This leads to flapping diffs, since the resources
	// are read from a map where the order is nondeterministic. Since we cannot support both operations due to this naming
	// conflict, we'll do the least undesirable thing and pick the one with the longest path, since this choice is deterministic
	// and the longer path is likely to be more specific and thus provide a more useful operation in the generated SDK.
	resourcesToDelete := make([]string, 0)
	for resourceName, resource := range resources {
		// Skip resources with no operations and mark for deletion
		if len(resource.Operations) == 0 {
			resourcesToDelete = append(resourcesToDelete, resourceName)
			continue
		}

		// Build a map of operations by name so we can sort through any duplicates per operation name
		collectedOperations := make(map[string][]parser.Operation)
		for _, operation := range resource.Operations {
			if _, ok := collectedOperations[operation.Name]; !ok {
				collectedOperations[operation.Name] = make([]parser.Operation, 0)
			}
			collectedOperations[operation.Name] = append(collectedOperations[operation.Name], operation)
		}

		newOperations := make([]parser.Operation, 0, len(resource.Operations))

		// Iterate collected operations (grouped by operation name) to find duplicates
		for _, operations := range collectedOperations {
			if len(operations) == 1 {
				newOperations = append(newOperations, operations[0])
				continue
			}

			// First sort the operations (having the same name) by path length descending (longest first), and then by the
			// length of the resource ID name if the paths have equal lengths
			sort.SliceStable(operations, func(i int, j int) bool {
				var path1, path2, idName1, idName2 string

				if id := operations[i].ResourceId; id != nil {
					path1 = id.ID()
					idName1 = id.Name
				}
				if suffix := operations[i].UriSuffix; suffix != nil {
					path1 += *suffix
				}

				if id := operations[j].ResourceId; id != nil {
					path2 = id.ID()
					idName2 = id.Name
				}
				if suffix := operations[j].UriSuffix; suffix != nil {
					path2 += *suffix
				}

				if len(path1) > len(path2) {
					return true
				}

				return len(idName1) > len(idName2)
			})

			// Any operations in this slice after the first operation will be duplicates (due to sorting above, operations
			// with longer paths will be encountered first and thus retained). We are iterating here so that we can log
			// any dropped operations.
			for i, operation := range operations {
				if i > 0 {
					logging.Infof("Dropping duplicate operation %q (resource %q, service %s, version %q)", operation.Name, resourceName, p.service, p.apiVersion)
					continue
				}

				newOperations = append(newOperations, operation)
			}
		}

		resource.Operations = newOperations
	}

	// Delete resources with no operations
	for _, resourceName := range resourcesToDelete {
		logging.Infof("Deleting resource %q (service %q, version %q) because it has no operations", resourceName, p.service, p.apiVersion)
		delete(resources, resourceName)
	}

	return
}
