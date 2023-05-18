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
		if lastSegment := id.Segments[len(id.Segments)-1]; lastSegment.Value == "$ref" {
			return "Add"
		}
		return "Create"
	case OperationTypeCreateUpdate:
		return "CreateUpdate"
	case OperationTypeUpdate:
		return "Update"
	case OperationTypeDelete:
		if lastSegment := id.Segments[len(id.Segments)-1]; lastSegment.Value == "$ref" {
			return "Remove"
		}
		return "Delete"
	}
	return ""
}

func (pipelineTask) parseResourceIDsForTag(tag string, subTags []string, paths openapi3.Paths) (ret []ResourceId) {
	ret = make([]ResourceId, 0)

	for path, item := range paths {
		id := NewResourceId(path, make([]string, 0))

		// Check tags and skip
		skip := true
		for _, operation := range item.Operations() {
			if tagMatches(tag, subTags, operation.Tags) {
				id.Tag = tag
				id.SubTags = subTags
				skip = false
			}
		}
		if skip {
			continue
		}

		// Name the resource by reverse walking the URI segments
		name := ""
		segmentsCount := len(id.Segments) - 1

		for i := segmentsCount; i > 0; i-- {
			segment := id.Segments[i]
			if segment.Type == SegmentCast || segment.Type == SegmentFunction { // TODO: skip these for now
				break
			} else if i < segmentsCount && segment.Type == SegmentUserValue {
				break
			} else if segment.Type == SegmentLabel || segment.Type == SegmentODataFunction {
				name = fmt.Sprintf("%s%s", cleanName(segment.Value), name)
			}
		}

		id.Name = pluralize(name)

		// TODO: skip unknown IDs for now
		if id.Name == "" {
			break
		}
	}

	return
}

func (pipelineTask) parseResourcesForTag(tag string, resourceIds []ResourceId) (ret []*Resource) {
	ret = make([]*Resource, 0)

	for _, id := range resourceIds {
		// Check tags and skip
		if tag != id.Tag {
			continue
		}

		resource := Resource{
			ID:         id,
			Version:    "v1.0",
			Service:    pluralize(cleanName(tag)),
			Operations: make([]Operation, 0), //, len(operations)),
		}

		// Name the resource by reverse walking the URI segments
		resourceName := ""
		segmentsCount := len(id.Segments) - 1

		for i := segmentsCount; i > 0; i-- {
			segment := id.Segments[i]
			if segment.Type == SegmentCast || segment.Type == SegmentFunction { // TODO: skip these for now
				break
			} else if i < segmentsCount && segment.Type == SegmentUserValue {
				break
			} else if segment.Type == SegmentLabel || segment.Type == SegmentODataFunction {
				resourceName = fmt.Sprintf("%s%s", cleanName(segment.Value), resourceName)
			}
		}

		resourceName = pluralize(resourceName)

		// TODO: skip unknown resources for now
		if resourceName == "" {
			break
		}
		if len(resource.Operations) > 0 {
			//if len(resource.Operations)==1 && resource.Operations[0].Type==OperationTypeCreate
			ret = append(ret, &resource)
		}
	}

	return
}

func (pipelineTask) parseMethodsForTag(tag string, subTags []string, paths openapi3.Paths) (ret []*Resource) {
	ret = make([]*Resource, 0)
	for path, item := range paths {
		id := NewResourceId(path, make([]string, 0))
		operations := item.Operations()

		// Check tags and skip
		skip := true
		for _, operation := range operations {
			if tagMatches(tag, subTags, operation.Tags) {
				skip = false
			}
		}
		if skip {
			continue
		}

		resource := Resource{
			ID:         id,
			Version:    "v1.0",
			Service:    pluralize(cleanName(tag)),
			Operations: make([]Operation, 0, len(operations)),
		}

		// Name the resource by reverse walking the URI segments
		resourceName := ""
		segmentsCount := len(id.Segments) - 1

		for i := segmentsCount; i > 0; i-- {
			segment := id.Segments[i]
			if segment.Type == SegmentCast || segment.Type == SegmentFunction { // TODO: skip these for now
				break
			} else if i < segmentsCount && segment.Type == SegmentUserValue {
				break
			} else if segment.Type == SegmentLabel || segment.Type == SegmentODataFunction {
				resourceName = fmt.Sprintf("%s%s", cleanName(segment.Value), resourceName)
			}
		}

		resourceName = pluralize(resourceName)

		// TODO: skip unknown resources for now
		if resourceName == "" {
			break
		}

		for method, operation := range operations {
			if !tagMatches(tag, subTags, operation.Tags) {
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

			resource.Name = pluralize(resourceName)
			resource.Operations = append(resource.Operations, Operation{
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
