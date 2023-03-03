package pipeline

import (
	"net/http"
	"strconv"
	"strings"

	"github.com/getkin/kin-openapi/openapi3"
)

type Endpoint struct {
	Id         ResourceId
	Operations []Operation
}

type Operation struct {
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

func (o OperationType) Name(id ResourceId) string {
	switch o {
	case OperationTypeList:
		return "List"
	case OperationTypeRead:
		return "Get"
	case OperationTypeCreate:
		if lastSegment := id.segments[len(id.segments)-1]; lastSegment.Value == "$ref" {
			return "Add"
		}
		return "Create"
	case OperationTypeCreateUpdate:
		return "CreateUpdate"
	case OperationTypeUpdate:
		return "Update"
	case OperationTypeDelete:
		if lastSegment := id.segments[len(id.segments)-1]; lastSegment.Value == "$ref" {
			return "Remove"
		}
		return "Delete"
	}
	return ""
}

func parseEndpointsForTag(tag string, subtags []string, paths openapi3.Paths) (ret []*Endpoint) {
	ret = make([]*Endpoint, 0)
	for path, item := range paths {
		id := NewResourceId(path, make([]string, 0))
		endpoint := Endpoint{
			Id:         id,
			Operations: make([]Operation, 0),
		}
		for method, operation := range item.Operations() {
			if !tagMatches(tag, subtags, operation.Tags) {
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
				if lastSegment := endpoint.Id.segments[len(endpoint.Id.segments)-1]; lastSegment.Value == "$ref" {
					continue
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
			endpoint.Operations = append(endpoint.Operations, Operation{
				Type:         operationType,
				Method:       method,
				RequestModel: requestModel,
				Responses:    responses,
				Tags:         operation.Tags,
			})
		}
		if len(endpoint.Operations) > 0 {
			ret = append(ret, &endpoint)
		}
	}
	return
}
