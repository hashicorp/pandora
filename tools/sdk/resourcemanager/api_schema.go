// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourcemanager

import (
	"encoding/json"
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

type ApiSchemaClient struct {
	Client
}

func (c ApiSchemaClient) Get(input ResourceSummary) (*ApiSchemaDetails, error) {
	endpoint := fmt.Sprintf("%s%s", c.endpoint, input.SchemaUri)
	resp, err := c.client.Get(endpoint)
	if err != nil {
		return nil, err
	}

	// TODO: handle this being a 404 etc

	var response ApiSchemaDetails
	if err := json.NewDecoder(resp.Body).Decode(&response); err != nil {
		return nil, err
	}

	return &response, nil
}

type ApiSchemaDetails struct {
	// Constants is a map of key (Constant Name) to value (ConstantDetails) describing
	// each Constant supported by this API Version.
	Constants map[string]models.SDKConstant `json:"constants"`

	// Models is a map of key (Model Name) to value (SDKModel) describing
	// each Model supported by this API version, used in either Requests or Responses
	Models map[string]models.SDKModel `json:"models"`

	// ResourceIds is a map of key (Resource Name) to value (Resource ID Definitions)
	// used by this API
	ResourceIds map[string]models.ResourceID `json:"resourceIds"`
}

type FieldValidationDetails struct {
	// Type specifies the Type of Validation which should be applied
	Type FieldValidationType `json:"type"`

	// Values is an optional field specifying zero or more values which can be
	// contextually useful for the validation type. As an example, a "Range"
	// validation may have a pre-defined range of values for the Range (e.g. min/max)
	Values *[]interface{} `json:"values"`
}

type FieldValidationType string

const (
	// RangeValidation specifies that this field must fall within a Range of pre-defined values
	RangeValidation FieldValidationType = "Range"
)
