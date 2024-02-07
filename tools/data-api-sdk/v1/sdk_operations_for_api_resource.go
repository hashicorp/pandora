package v1

import (
	"context"
	"fmt"
)

type GetSDKOperationsForAPIResourceResponse struct {
	// TODO
}

// GetSDKOperationsForAPIResource returns the SDK Operations for the specified API Resource (within a given API Version/Service).
func (c *Client) GetSDKOperationsForAPIResource(ctx context.Context, apiResource APIResourceSummary) (*GetSDKOperationsForAPIResourceResponse, error) {
	return nil, fmt.Errorf("not yet implemented")
}
