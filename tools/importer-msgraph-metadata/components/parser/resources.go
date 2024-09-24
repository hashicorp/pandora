// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package parser

import (
	"fmt"
	"net/http"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

type Resources map[string]*Resource

type Resource struct {
	// The name of this resource
	Name string

	// The category for this resource, used to group resources together in the same SDK package
	Category string

	// The API version for this resource
	Version string

	// The name of the service associated with this resource
	Service string

	// All known paths for this resource, used for category matching between different resources
	Paths []ResourceId

	// Supported operations for this resource
	Operations []Operation
}

type Operation struct {
	// The full name of this operation, which should be unique across resources (at least in the same category) so
	// prevent clobbering when resources/operations are grouped into an SDK package
	Name string

	// Optional description which can be added to the generated SDK model as a comment
	Description string

	// The type of this operation, initially determined from the HTTP method
	Type OperationType

	// The HTTP method for this operation
	Method string

	// The resource ID that comprises the first part of the URI for this operation
	ResourceId *ResourceId

	// The remainder of the URI after the resource ID
	UriSuffix *string

	// When the content type is JSON or XML, and this is a List operation, the name of the field
	// that specifies a URL to retrieve the next page of results
	PaginationField *string

	// The content-type of the request body
	RequestContentType *string

	// The name of the model that describes the request body, can reference either a common model or describe the ad-hoc request model
	RequestModelName *string

	// The optional ad-hoc request model, if present
	RequestModel *Model

	// Any user-specified HTTP headers supported for the request
	RequestHeaders *[]Header

	// Any user-specified query string parameters support for the request
	RequestParams *[]Param

	// The internal data type for the request, used when the content type is JSON or XML,
	// and the request is not described by a model
	RequestType *DataType

	// The HTTP status codes associated with this expected response
	ResponseStatusCodes []int

	// The expected content type for this resource
	ResponseContentType *string

	// Specifies a referenced model or constant for the response, noting that this
	// should be the full type name from the spec prior to normalizing
	ResponseReferenceName *string

	// The internal data type for the response, used when the content type is JSON or XML,
	// and the response is not described by a model
	ResponseType *DataType

	// Model and Constant are used internally for ad-hoc response models
	ResponseModel    *Model
	ResponseConstant *Constant

	// OpenAPI3 tags for this operation, used to reconcile operations to services
	Tags []string
}

type Header struct {
	Name string
	Type *DataType
}

func (h Header) DataApiSdkObjectDefinition() (*sdkModels.SDKOperationOptionObjectDefinition, error) {
	if h.Type == nil {
		return nil, fmt.Errorf("param %q has no Type", h.Name)
	}

	return &sdkModels.SDKOperationOptionObjectDefinition{
		NestedItem:    nil,
		ReferenceName: nil,
		Type:          h.Type.DataApiSdkOperationOptionObjectDefinitionType(),
	}, nil
}

type Param struct {
	Name     string
	Type     *DataType
	ItemType *DataType
}

func (p Param) DataApiSdkObjectDefinition() (*sdkModels.SDKOperationOptionObjectDefinition, error) {
	if p.Type == nil {
		return nil, fmt.Errorf("param %q has no Type", p.Name)
	}

	if *p.Type == DataTypeArray {
		if p.ItemType != nil {
			return &sdkModels.SDKOperationOptionObjectDefinition{
				NestedItem: &sdkModels.SDKOperationOptionObjectDefinition{
					NestedItem:    nil,
					ReferenceName: nil,
					Type:          p.ItemType.DataApiSdkOperationOptionObjectDefinitionType(),
				},
				ReferenceName: nil,
				Type:          sdkModels.ListSDKOperationOptionObjectDefinitionType,
			}, nil
		}

		return nil, nil
	}

	return &sdkModels.SDKOperationOptionObjectDefinition{
		NestedItem:    nil,
		ReferenceName: nil,
		Type:          p.Type.DataApiSdkOperationOptionObjectDefinitionType(),
	}, nil
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
