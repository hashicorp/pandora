package pipeline

import (
	"fmt"
	"net/http"
	"strconv"
	"strings"

	"github.com/getkin/kin-openapi/openapi3"
)

type Resource struct {
	Name    string
	Version string
	Service string

	ID         ResourceId
	Operations []Operation
}

type Operation struct {
	Name         string
	Type         OperationType
	Method       string
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

func (pipelineTask) parseResourcesForService(service string, serviceTags []string, paths openapi3.Paths) (ret []*Resource) {
	ret = make([]*Resource, 0)
	for path, item := range paths {
		id := NewResourceId(path, make([]string, 0))
		operations := item.Operations()

		// Check tags and skip
		skip := true
		for _, operation := range operations {
			if tagMatches(service, serviceTags, operation.Tags) {
				skip = false
			}
		}
		if skip {
			continue
		}

		resource := Resource{
			ID:         id,
			Version:    "v1.0",
			Service:    pluralize(cleanName(service)),
			Operations: make([]Operation, 0, len(operations)),
		}

		// Name the resource by reverse walking the URI segments
		resourceName := ""
		operationSuffix := ""
		segmentsLastIndex := len(id.Segments) - 1

		for i := segmentsLastIndex; i >= 0; i-- {
			segment := id.Segments[i]
			if segment.Type == SegmentCast || segment.Type == SegmentFunction { // TODO: skip these for now
				break
			} else if i < segmentsLastIndex && segment.Type == SegmentUserValue {
				break
			} else if previousLabel := id.LastLabelBeforeSegment(i - 1); i > 1 && id.Segments[i-1].Type == SegmentUserValue && previousLabel != nil {
				resourceName = singularize(cleanName(previousLabel.Value))
				operationSuffix = singularize(cleanName(segment.Value))
			} else if segment.Type == SegmentLabel || segment.Type == SegmentODataFunction {
				resourceName = fmt.Sprintf("%s%s", singularize(cleanName(segment.Value)), resourceName)
			}
		}

		// TODO: skip unknown resources for now
		if resourceName == "" {
			continue
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
					// TODO: expand this
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

			// We aren't interested in GET /.../$ref
			if operationType == OperationTypeList || operationType == OperationTypeRead {
				if lastSegment := resource.ID.Segments[len(resource.ID.Segments)-1]; lastSegment.Value == "$ref" {
					continue
				}
			}

			operationName := ""
			lastSegment := id.Segments[len(id.Segments)-1]

			switch operationType {
			case OperationTypeList:
				operationName = fmt.Sprintf("List%s", pluralize(operationSuffix))
			case OperationTypeRead:
				operationName = "Get"
			case OperationTypeCreate:
				if lastSegment.Value == "$ref" {
					operationName = "Add"
				} else {
					operationName = fmt.Sprintf("Create%s", operationSuffix)
				}
			case OperationTypeCreateUpdate:
				operationName = fmt.Sprintf("CreateUpdate%s", operationSuffix)
			case OperationTypeUpdate:
				operationName = fmt.Sprintf("Update%s", operationSuffix)
			case OperationTypeDelete:
				if lastSegment.Value == "$ref" {
					operationName = fmt.Sprintf("Remove%s", operationSuffix)
				} else {
					operationName = fmt.Sprintf("Delete%s", operationSuffix)
				}
			}

			//if lastLabel := id.LastLabel(); lastLabel != nil {
			//	if operationType == OperationTypeList {
			//		resourceName = pluralize(cleanName(lastLabel.Value))
			//	} else {
			//		resourceName = singularize(cleanName(lastLabel.Value))
			//	}
			//}

			// If no resource name computed, derive it from tags
			if resourceName == "" {
				if len(operation.Tags) > 1 {
					panic(fmt.Sprintf("found %d tags for operation %s/%s: %s", len(operation.Tags), id.ID(), operationType, operation.Tags)) // TODO handle
				} else if len(operation.Tags) == 1 {
					t := strings.Split(operation.Tags[0], ".")
					if len(t) != 2 {
						panic(fmt.Sprintf("invalid tag for operation %s/%s: %s", id.ID(), operationType, operation.Tags[0])) // TODO handle
					}
					resourceName = cleanName(t[1])
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

			resource.Name = resourceName
			resource.Operations = append(resource.Operations, Operation{
				Name:         operationName,
				Type:         operationType,
				Method:       method,
				RequestModel: requestModel,
				Responses:    responses,
				Tags:         operation.Tags,
			})
		}
		if len(resource.Operations) > 0 {
			//if len(resource.Operations)==1 && resource.Operations[0].Type==OperationTypeCreate
			ret = append(ret, &resource)
		}
	}
	return
}
