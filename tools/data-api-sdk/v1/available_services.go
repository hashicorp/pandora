// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package v1

import (
	"context"
	"encoding/json"
	"fmt"
	"net/http"
)

type GetAvailableServicesResponse struct {
	// HttpResponse is the raw HTTP Response
	HttpResponse *http.Response

	// Model contains a list of the Available Services within this Source Data Type.
	Model *GetAvailableServices
}

type GetAvailableServices struct {
	// Services is a map of Service Name to AvailableServiceSummary, which can be used to determine
	// the API Versions available for this Service.
	Services map[string]AvailableServiceSummary `json:"services"`
}

type AvailableServiceSummary struct {
	// Generate specifies whether this API should be generated or not
	Generate bool `json:"generate"`

	// Uri is the Uri used to access more information about this Service
	Uri string `json:"uri"`
}

// GetAvailableServices returns the list of available Services within this Source Data Type.
func (c *Client) GetAvailableServices(ctx context.Context) (*GetAvailableServicesResponse, error) {
	uri := fmt.Sprintf("%s/v1/%s/services", c.endpoint, string(c.sourceDataType))
	req, err := http.NewRequestWithContext(ctx, http.MethodGet, uri, nil)
	if err != nil {
		return nil, fmt.Errorf("building request to the %q endpoint: %+v", uri, err)
	}

	out := GetAvailableServicesResponse{}
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
