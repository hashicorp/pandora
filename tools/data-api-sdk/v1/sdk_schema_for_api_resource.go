package v1

import (
	"context"
	"fmt"
)

type GetSDKSchemaForAPIResourceResponse struct {
	// TODO
}

// GetSDKSchemaForAPIResource returns the SDK Schema for the specified API Resource (within a given API Version/Service).
func (c *Client) GetSDKSchemaForAPIResource(ctx context.Context, apiResource APIResourceSummary) (*GetSDKSchemaForAPIResourceResponse, error) {
	return nil, fmt.Errorf("not yet implemented")
}
