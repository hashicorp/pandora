package v1

import (
	"context"
	"encoding/json"
	"fmt"
	"net/http"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

type GetCommonTypesResponse struct {
	// HttpResponse is the raw HTTP Response.
	HttpResponse *http.Response

	// Model is the Common SDK Types for this Source Data Type.
	Model *models.CommonTypes
}

// GetCommonTypes returns the Common SDK Types for this Source Data Type.
func (c *Client) GetCommonTypes(ctx context.Context) (*GetCommonTypesResponse, error) {
	uri := fmt.Sprintf("%s/v1/%s/commonTypes", c.endpoint, string(c.sourceDataType))
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

	var response models.CommonTypes
	if err := json.NewDecoder(out.HttpResponse.Body).Decode(&response); err != nil {
		return nil, err
	}
	out.Model = &response

	return &out, nil
}
