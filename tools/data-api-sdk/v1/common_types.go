// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package v1

import (
	"context"
	"encoding/json"
	"fmt"
	"net/http"
)

type GetCommonTypesResponse struct {
	// HttpResponse is the raw HTTP Response.
	HttpResponse *http.Response

	// Model is a GetCommonTypes, representing the response for this endpoint.
	Model *GetCommonTypesSummary
}

type GetCommonTypesSummary struct {
	// CommonTypes is a map of APIVersion (key) to GetCommonTypesMetaData (value) which contains the
	// URI to obtain the Common Types for this APIVersion.
	CommonTypes map[string]GetCommonTypesMetaData `json:"commonTypes"`
}

type GetCommonTypesMetaData struct {
	// CommonTypesURI is the URI containing the Common Types for this APIVersion
	CommonTypesURI string `json:"commonTypesUri"`
}

// GetCommonTypes returns the Common SDK Types for this Source Data Type.
func (c *Client) GetCommonTypes(ctx context.Context) (*GetCommonTypesResponse, error) {
	uri := fmt.Sprintf("%s/v1/%s/common-types", c.endpoint, string(c.sourceDataType))
	req, err := http.NewRequestWithContext(ctx, http.MethodGet, uri, nil)
	if err != nil {
		return nil, fmt.Errorf("building request to the %q endpoint: %+v", uri, err)
	}

	out := GetCommonTypesResponse{}
	out.HttpResponse, err = c.client.Do(req)
	if err != nil {
		return nil, fmt.Errorf("performing request to %q: %+v", uri, err)
	}

	if out.HttpResponse.StatusCode != http.StatusOK {
		return nil, fmt.Errorf("expected a 200 OK but got %d %s for %q", out.HttpResponse.StatusCode, out.HttpResponse.Status, uri)
	}

	var response GetCommonTypesSummary
	if err := json.NewDecoder(out.HttpResponse.Body).Decode(&response); err != nil {
		return nil, err
	}
	out.Model = &response

	return &out, nil
}
