package pipeline

import (
	"fmt"
	"net/http"
	"strconv"
	"strings"

	"github.com/getkin/kin-openapi/openapi3"
)

type Resource struct {
	Name       string
	Version    string
	Service    string
	Operations []Operation
}

type Operation struct {
	Name         string
	Type         OperationType
	Method       string
	ResourceId   *ResourceId
	UriSuffix    *string
	RequestModel *string
	Responses    []Response
	Tags         []string
}

type Response struct {
	Status      int
	ContentType *string
	Collection  bool
	ModelName   *string
}

type OperationType uint8

const (
	OperationTypeUnknown OperationType = iota
	OperationTypeList
	OperationTypeRead
	OperationTypeCreate
	OperationTypeCreateUpdate
	OperationTypeUpdate
	OperationTypeDelete
)

func NewOperationType(method string) OperationType {
	switch method {
	case http.MethodGet:
		return OperationTypeRead
	case http.MethodPost:
		return OperationTypeCreate
	case http.MethodPatch:
		return OperationTypeUpdate
	case http.MethodPut:
		return OperationTypeCreateUpdate
	case http.MethodDelete:
		return OperationTypeDelete
	}
	return OperationTypeUnknown
}

func (pipelineTask) parseResourcesForService(apiVersion, service string, serviceTags []string, paths openapi3.Paths, resourceIds ResourceIds) (resources map[string]*Resource) {
	resources = make(map[string]*Resource)
	for path, item := range paths {
		operations := item.Operations()
		operationTags := make([]string, 0)

		// Check tags and skip
		skip := true
		for _, operation := range operations {
			if tagMatches(service, serviceTags, operation.Tags) {
				operationTags = append(operationTags, operation.Tags...)
				skip = false
			}
		}
		if skip {
			continue
		}

		id := NewResourceId(path, operationTags)
		segmentsLastIndex := len(id.Segments) - 1
		if lastSegment := id.Segments[segmentsLastIndex]; lastSegment.Type == SegmentCast || lastSegment.Type == SegmentFunction {
			continue
		}

		resourceName := ""
		if r := id.FindResourceName(); r != nil {
			resourceName = singularize(cleanName(*r))
		}

		var resourceId *ResourceId
		var uriSuffix *string
		match, ok := resourceIds.MatchIdOrParent(id)
		if ok {
			if match.Id != nil {
				resourceId = match.Id
			}
			if match.Remainder != nil && len(match.Remainder.Segments) > 0 {
				uriSuffix = pointerTo(match.Remainder.ID())
			}
		}

		// TODO: skip unknown operations for now
		if resourceName == "" {
			continue
		}

		// Create a new resource if not already encountered
		if _, ok := resources[resourceName]; !ok {
			resources[resourceName] = &Resource{
				Name:       resourceName,
				Version:    apiVersion,
				Service:    cleanName(service),
				Operations: make([]Operation, 0, len(operations)),
			}
		}

		for method, operation := range operations {
			if !tagMatches(service, serviceTags, operation.Tags) {
				continue
			}
			listOperation := false
			responses := make([]Response, 0)
			if operation.Responses != nil {
				for stat, resp := range operation.Responses {
					var status int
					var contentType, responseModel *string
					var collection bool
					// TODO: expand status codes so we handle more than 200, 300 etc
					if s, err := strconv.Atoi(strings.ReplaceAll(stat, "X", "0")); err == nil {
						status = s
					}
					if resp.Value != nil && resp.Value.Content != nil {
						for t, m := range resp.Value.Content {
							contentType = &t
							if s := parseSchemaRef(m.Schema); s != nil {
								f, _ := flattenSchema(s, nil)
								if f.Title != "" {
									if strings.HasPrefix(f.Title, "Collection of ") {
										f.Title = f.Title[14:]
										collection = true
										listOperation = true
									}
									if f.Title != "string" {
										responseModel = pointerTo(cleanName(f.Title))
									}
								}
							}
							break
						}
					}
					responses = append(responses, Response{
						Status:      status,
						ContentType: contentType,
						Collection:  collection,
						ModelName:   responseModel,
					})
				}
			}

			operationType := NewOperationType(method)
			if listOperation {
				operationType = OperationTypeList
			}

			operationName := ""
			lastSegment := id.Segments[len(id.Segments)-1]

			switch operationType {
			case OperationTypeList:
				//if len(operationSuffix) >= 3 && strings.HasPrefix(strings.ToLower(operationSuffix), "get") {
				//	operationSuffix = operationSuffix[3:]
				//}
				operationName = fmt.Sprintf("List%s", pluralize(resourceName))
			case OperationTypeRead:
				operationName = fmt.Sprintf("Get%s", resourceName)
			case OperationTypeCreate:
				if verbs.match(resourceName) {
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

			var requestModel *string
			if operation.RequestBody != nil && operation.RequestBody.Value != nil {
				for contentType, content := range operation.RequestBody.Value.Content {
					if strings.HasPrefix(strings.ToLower(contentType), "application/json") {
						if content.Schema != nil {
							schema, _ := flattenSchema(content.Schema.Value, nil)
							if schema.Title != "" {
								requestModel = pointerTo(cleanName(schema.Title))
							}
						}
					}
				}
			}

			resources[resourceName].Operations = append(resources[resourceName].Operations, Operation{
				Name:         operationName,
				Type:         operationType,
				Method:       method,
				ResourceId:   resourceId,
				UriSuffix:    uriSuffix,
				RequestModel: requestModel,
				Responses:    responses,
				Tags:         operation.Tags,
			})
		}
	}

	return
}
