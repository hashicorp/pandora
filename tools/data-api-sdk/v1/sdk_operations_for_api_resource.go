// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package v1

import (
	"context"
	"encoding/json"
	"fmt"
	"net/http"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

type GetSDKOperationsForAPIResourceResponse struct {
	// HttpResponse is the raw HTTP Response.
	HttpResponse *http.Response

	// Model contains the SDKOperations for this APIResource.
	Model *GetSDKOperationsForAPIResource
}

type GetSDKOperationsForAPIResource struct {
	// Operations describes a map of key (Operation Name) to value (SDKOperation) of the
	// SDK Operations available within this API Resource.
	Operations map[string]models.SDKOperation `json:"operations"`
}

// GetSDKOperationsForAPIResource returns the SDK Operations for the specified API Resource (within a given API Version/Service).
func (c *Client) GetSDKOperationsForAPIResource(ctx context.Context, apiResource APIResourceSummary) (*GetSDKOperationsForAPIResourceResponse, error) {
	uri := fmt.Sprintf("%s%s", c.endpoint, apiResource.OperationsURI)
	req, err := http.NewRequestWithContext(ctx, http.MethodGet, uri, nil)
	if err != nil {
		return nil, fmt.Errorf("building request to the %q endpoint: %+v", uri, err)
	}

	out := GetSDKOperationsForAPIResourceResponse{}
	out.HttpResponse, err = c.client.Do(req)
	if err != nil {
		return nil, fmt.Errorf("performing request to %q: %+v", uri, err)
	}

	if out.HttpResponse.StatusCode != http.StatusOK {
		return nil, fmt.Errorf("expected a 200 OK but got %d %s for %q", out.HttpResponse.StatusCode, out.HttpResponse.Status, uri)
	}

	if err := json.NewDecoder(out.HttpResponse.Body).Decode(&out.Model); err != nil {
		return nil, err
	}

	return &out, nil
}
