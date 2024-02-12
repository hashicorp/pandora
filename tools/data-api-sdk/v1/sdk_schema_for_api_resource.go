package v1

import (
	"context"
	"encoding/json"
	"fmt"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
	"net/http"
)

type GetSDKSchemaForAPIResourceResponse struct {
	// HttpResponse is the raw HTTP Response.
	HttpResponse *http.Response

	// Constants describes a map of Constant Name (key) to SDKConstant (value) used within this APIResource.
	// The Constant Name is a valid Identifier.
	Constants *map[string]models.SDKConstant

	// Models describes a map of Model Name (key) to SDKModel (value) used within this APIResource.
	// The Model Name is a valid Identifier.
	Models *map[string]models.SDKModel

	// ResourceIDs describes a map of Resource ID Name (key) to ResourceID (value) used within this APIResource.
	// The Resource ID Name is a valid Identifier.
	ResourceIDs *map[string]models.ResourceID
}

// GetSDKSchemaForAPIResource returns the SDK Schema for the specified API Resource (within a given API Version/Service).
func (c *Client) GetSDKSchemaForAPIResource(ctx context.Context, apiResource APIResourceSummary) (*GetSDKSchemaForAPIResourceResponse, error) {
	uri := fmt.Sprintf("%s%s", c.endpoint, apiResource.SchemaURI)
	req, err := http.NewRequestWithContext(ctx, http.MethodGet, uri, nil)
	if err != nil {
		return nil, fmt.Errorf("building request to the %q endpoint: %+v", uri, err)
	}

	out := GetSDKSchemaForAPIResourceResponse{}
	out.HttpResponse, err = c.client.Do(req)
	if err != nil {
		return nil, fmt.Errorf("performing request to %q: %+v", uri, err)
	}

	if out.HttpResponse.StatusCode != http.StatusOK {
		return nil, fmt.Errorf("expected a 200 OK but got %d %s for %q", out.HttpResponse.StatusCode, out.HttpResponse.Status, uri)
	}

	var response struct {
		Constants   map[string]models.SDKConstant `json:"constants"`
		Models      map[string]models.SDKModel    `json:"models"`
		ResourceIDs map[string]models.ResourceID  `json:"resourceIds"`
	}
	if err := json.NewDecoder(out.HttpResponse.Body).Decode(&response); err != nil {
		return nil, err
	}

	out.Constants = &response.Constants
	out.Models = &response.Models
	out.ResourceIDs = &response.ResourceIDs

	return &out, nil
}
