// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package parser

import (
	"fmt"
	"net/http"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
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
	Name               string
	Description        string
	Type               OperationType
	Method             string
	ResourceId         *ResourceId
	UriSuffix          *string
	RequestContentType *string
	RequestModel       *string
	RequestHeaders     *Headers
	RequestParams      *Params
	RequestType        *DataType
	Responses          Responses
	PaginationField    *string
	Tags               []string
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

type Headers []Header

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

type Params []Param

type Response struct {
	Status        int
	ContentType   *string
	ReferenceName *string
	Type          *DataType
	Model         *Model
	Constant      *Constant
}

type Responses []Response

func (rs Responses) FindModelName() *string {
	for _, r := range rs {
		if r.ReferenceName != nil {
			return r.ReferenceName
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
