// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package v1

import (
	"context"
	"encoding/json"
	"fmt"
	"net/http"

	sdkModels "github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

type GetCommonTypesForAPIVersionResponse struct {
	// HttpResponse is the raw HTTP Response.
	HttpResponse *http.Response

	// Model is a GetCommonTypes, representing the response for this endpoint.
	Model *sdkModels.CommonTypes
}

// GetCommonTypesForAPIVersion returns the Common SDK Types for the specified API Version/SourceDataType combination.
func (c *Client) GetCommonTypesForAPIVersion(ctx context.Context, metadata GetCommonTypesMetaData) (*GetCommonTypesForAPIVersionResponse, error) {
	uri := fmt.Sprintf("%s%s", c.endpoint, metadata.CommonTypesURI)
	req, err := http.NewRequestWithContext(ctx, http.MethodGet, uri, nil)
	if err != nil {
		return nil, fmt.Errorf("building request to the %q endpoint: %+v", uri, err)
	}

	out := GetCommonTypesForAPIVersionResponse{}
	out.HttpResponse, err = c.client.Do(req)
	if err != nil {
		return nil, fmt.Errorf("performing request to %q: %+v", uri, err)
	}

	if out.HttpResponse.StatusCode != http.StatusOK {
		return nil, fmt.Errorf("expected a 200 OK but got %d %s for %q", out.HttpResponse.StatusCode, out.HttpResponse.Status, uri)
	}

	var response sdkModels.CommonTypes
	if err := json.NewDecoder(out.HttpResponse.Body).Decode(&response); err != nil {
		return nil, err
	}
	out.Model = &response

	return &out, nil
}
