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

type DetailsForAPIVersionResponse struct {
	// HttpResponse is the raw HTTP Response.
	HttpResponse *http.Response

	// Model describes details about the specified API Version, including the API Resources available within it.
	Model *DetailsForAPIVersionSummary
}

type DetailsForAPIVersionSummary struct {
	// Resources is a map of API Resource names (key) to APIResourceSummary (value).
	// This can be used to retrieve information about the API Resource in question.
	Resources map[string]APIResourceSummary `json:"resources"`

	// Source specifies the origin of the Source Data for this API version.
	Source models.SourceDataOrigin `json:"source"`
}

type APIResourceSummary struct {
	// OperationsURI specifies the endpoint where information about the Operations for
	// this API Resource can be loaded from.
	OperationsURI string `json:"operationsUri"`

	// SchemaURI specifies the endpoint where information about the Schema for the
	// SDK Constants, Models and Resource IDs for this API Resource can be loaded from.
	SchemaURI string `json:"schemaUri"`
}

// DetailsForAPIVersion retrieves information about the specified API Version, including the
// list of API Resources available within it.
func (c *Client) DetailsForAPIVersion(ctx context.Context, apiVersion ServiceAPIVersionSummary) (*DetailsForAPIVersionResponse, error) {
	uri := fmt.Sprintf("%s%s", c.endpoint, apiVersion.URI)
	req, err := http.NewRequestWithContext(ctx, http.MethodGet, uri, nil)
	if err != nil {
		return nil, fmt.Errorf("building request to the %q endpoint: %+v", uri, err)
	}

	out := DetailsForAPIVersionResponse{}
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
