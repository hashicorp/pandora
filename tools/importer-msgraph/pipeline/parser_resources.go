package pipeline

import (
	"net/http"
)

type Resource struct {
	Name       string
	Category   string
	Version    string
	Service    string
	Paths      []ResourceId
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

type Resources map[string]*Resource

func (r Resources) ServiceHasValidResources(serviceName string) bool {
	for _, resource := range r {
		if resource.Category == "" {
			continue // TODO do something about orphaned resources
		}

		for _, operation := range resource.Operations {
			// Skip unknown operations
			if operation.Type == OperationTypeUnknown {
				continue
			}

			// Skip functions and casts for now
			if operation.ResourceId != nil && len(operation.ResourceId.Segments) > 0 {
				if lastSegment := operation.ResourceId.Segments[len(operation.ResourceId.Segments)-1]; lastSegment.Type == SegmentCast || lastSegment.Type == SegmentFunction || lastSegment.Type == SegmentODataReference {
					continue
				}
			}

			if operation.Type == OperationTypeList || operation.Type == OperationTypeRead {
				// Determine whether to skip operation with missing response model
				if operation.Type != OperationTypeDelete {
					if responseModel := findModel(operation.Responses); responseModel == "" {
						if operation.ResourceId == nil || len(operation.ResourceId.Segments) == 0 || operation.ResourceId.Segments[len(operation.ResourceId.Segments)-1].Value != "$ref" {
							continue
						}
					}
				}
			}

			return true
		}
	}

	return false
}
