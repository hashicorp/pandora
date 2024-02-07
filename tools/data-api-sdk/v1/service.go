package v1

import (
	"context"
	"fmt"
)

type GetServiceResponse struct {
	// TODO
}

type ServiceDetails struct {
	// TODO:
}

// GetService returns information about the specified Service.
func (c *Client) GetService(ctx context.Context, service AvailableServiceSummary) (*GetServiceResponse, error) {
	return nil, fmt.Errorf("not yet implemented")
}
