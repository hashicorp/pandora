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
	RequestType  *DataType
	Responses    Responses
	Tags         []string
}

type Response struct {
	Status      int
	ContentType *string
	ModelName   *string
	Type        *DataType
}

type Responses []Response

func (rs Responses) FindModelName() *string {
	for _, r := range rs {
		if r.ModelName != nil {
			return r.ModelName
		}
	}
	return nil
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

// ServiceHasValidResources returns true when resources are found for the provided serviceName that have usable operations
// defined (specifically any operations that do not require a response model, or that have a response model for any response)
func (r Resources) ServiceHasValidResources(serviceName string) bool {
	for _, resource := range r {
		if resource.Category == "" {
			// These are logged earlier in the pipeline
			continue
		}

		for _, operation := range resource.Operations {
			if operation.Type == OperationTypeList || operation.Type == OperationTypeRead {
				// Determine whether to skip operation with missing response model
				if operation.Type != OperationTypeDelete {
					if responseModel := operation.Responses.FindModelName(); responseModel == nil {
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
