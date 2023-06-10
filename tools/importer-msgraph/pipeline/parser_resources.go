package pipeline

import "net/http"

type Resource struct {
	Name       string
	Category   string
	Version    string
	Service    string
	Id         *ResourceId
	Paths      []ResourceId
	Operations []Operation
}

type Operation struct {
	Name         string
	Type         OperationType
	Method       string
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
