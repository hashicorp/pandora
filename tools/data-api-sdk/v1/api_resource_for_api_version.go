package v1

import (
	"context"
	"fmt"
)

type GetAPIResourceForAPIVersionResponse struct {
	// TODO
}

// GetAPIResourceForAPIVersion returns information about a particular API Resource within the specified API Version for a Service.
func (c *Client) GetAPIResourceForAPIVersion(ctx context.Context, apiVersion APIResourceSummary) (*GetAPIResourceForAPIVersionResponse, error) {
	return nil, fmt.Errorf("not yet implemented")
}
