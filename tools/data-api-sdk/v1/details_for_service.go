// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package v1

import (
	"context"
	"encoding/json"
	"fmt"
	"net/http"
)

type GetDetailsForServiceResponse struct {
	// HttpResponse is the raw HTTP Response.
	HttpResponse *http.Response

	// Model describes details about the specified Service, including the API Versions that are available.
	Model *ServiceDetailsResponse
}

type ServiceDetailsResponse struct {
	// ResourceProvider specifies the Azure Resource Provider associated with this Service. This is
	// only relevant for Source Data from Resource Manager. For other Source Data Types this is null.
	ResourceProvider *string `json:"resourceProvider,omitempty"`

	// TerraformPackageName specifies the name of the Service Package associated with this Service used
	// in the associated Terraform Provider.
	TerraformPackageName *string `json:"terraformPackageName,omitempty"`

	// TerraformURI specifies the URI where the Terraform-specific information can be loaded from.
	TerraformURI string `json:"terraformUri"`

	// Versions specifies a map of ApiVersion (key) to ServiceAPIVersionSummary, containing
	Versions map[string]ServiceAPIVersionSummary `json:"versions"`
}

type ServiceAPIVersionSummary struct {
	// Generate specifies whether this API Version should be generated or not.
	Generate bool `json:"generate"`

	// Preview specifies whether this API Version is a Preview rather than a Stable version.
	Preview bool `json:"preview"`

	// URI specifies the URI where additional information about this API version can be loaded from.
	URI string `json:"uri"`
}

// GetDetailsForServiceResponse returns information about the specified Service, including the list of available API Versions.
func (c *Client) GetDetailsForServiceResponse(ctx context.Context, service AvailableServiceSummary) (*GetDetailsForServiceResponse, error) {
	uri := fmt.Sprintf("%s%s", c.endpoint, service.Uri)
	req, err := http.NewRequestWithContext(ctx, http.MethodGet, uri, nil)
	if err != nil {
		return nil, fmt.Errorf("building request to the %q endpoint: %+v", uri, err)
	}

	out := GetDetailsForServiceResponse{}
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
