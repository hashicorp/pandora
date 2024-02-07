package v1

import (
	"context"
	"fmt"
)

type GetAvailableServicesResponse struct {
	// TODO
}

type AvailableServiceSummary struct {
	// Generate specifies whether this API should be generated or not
	Generate bool `json:"generate"`

	// Uri is the Uri used to access more information about this Service
	Uri string `json:"uri"`
}

// GetAvailableServices returns the list of available Services within this Source Data Type.
func (c *Client) GetAvailableServices(ctx context.Context) (*GetAvailableServicesResponse, error) {
	return nil, fmt.Errorf("not yet implemented")
}
