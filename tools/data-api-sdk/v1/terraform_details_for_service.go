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

type GetTerraformDetailsForServiceResponse struct {
	// HttpResponse is the raw HTTP Response.
	HttpResponse *http.Response

	// Model returns the Terraform Definition for this Service.
	Model *models.TerraformDefinition
}

// GetTerraformDetailsForService retrieves the Terraform Details for the specified Service.
func (c *Client) GetTerraformDetailsForService(ctx context.Context, service ServiceDetailsResponse) (*GetTerraformDetailsForServiceResponse, error) {
	uri := fmt.Sprintf("%s%s", c.endpoint, service.TerraformURI)
	req, err := http.NewRequestWithContext(ctx, http.MethodGet, uri, nil)
	if err != nil {
		return nil, fmt.Errorf("building request to the %q endpoint: %+v", uri, err)
	}

	out := GetTerraformDetailsForServiceResponse{}
	out.HttpResponse, err = c.client.Do(req)
	if err != nil {
		return nil, fmt.Errorf("performing request to %q: %+v", uri, err)
	}

	if out.HttpResponse.StatusCode == http.StatusNoContent {
		// no Terraform Definitions for this Service
		return &out, nil
	}

	if out.HttpResponse.StatusCode != http.StatusOK {
		return nil, fmt.Errorf("expected a 200 OK but got %d %s for %q", out.HttpResponse.StatusCode, out.HttpResponse.Status, uri)
	}

	if err := json.NewDecoder(out.HttpResponse.Body).Decode(&out.Model); err != nil {
		return nil, err
	}

	if out.Model != nil && service.TerraformPackageName != nil {
		out.Model.TerraformPackageName = *service.TerraformPackageName
	}

	return &out, nil
}
