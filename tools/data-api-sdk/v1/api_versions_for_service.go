package v1

import (
	"context"
	"fmt"
)

type GetAPIVersionsForServiceResponse struct {
	// TODO
}

type ServiceAPIVersionSummary struct {
	// TODO
}

type APIResourceSummary struct {
	// TODO
}

// GetAPIVersionsForService returns the list of available API Versions for the current Service.
func (c *Client) GetAPIVersionsForService(ctx context.Context, service AvailableServiceSummary) (*GetAPIVersionsForServiceResponse, error) {
	return nil, fmt.Errorf("not yet implemented")
}
