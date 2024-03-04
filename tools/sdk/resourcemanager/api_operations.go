// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourcemanager

import (
	"encoding/json"
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

type ApiOperationsClient struct {
	Client
}

func (c ApiOperationsClient) Get(input ResourceSummary) (*ApiOperationDetails, error) {
	endpoint := fmt.Sprintf("%s%s", c.endpoint, input.OperationsUri)
	resp, err := c.client.Get(endpoint)
	if err != nil {
		return nil, err
	}

	// TODO: handle this being a 404 etc

	var response ApiOperationDetails
	if err := json.NewDecoder(resp.Body).Decode(&response); err != nil {
		return nil, err
	}

	return &response, nil
}

type ApiOperationDetails struct {
	// Operations is a map of key (Operation Name) to value (SDKOperation)
	// for the Operations supported by this API
	Operations map[string]models.SDKOperation `json:"operations"`
}

type MetaData struct {
	// ResourceProvider is the name of the Azure Resource Provider which must be
	// registered to use this API Operation
	ResourceProvider *string `json:"resourceProvider"`
}
