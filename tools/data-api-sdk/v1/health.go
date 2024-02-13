package v1

import (
	"context"
	"fmt"
	"net/http"
)

type HealthResponse struct {
	// Available specifies whether the Data API is available or not.
	Available bool

	// HttpResponse is the raw HTTP Response
	HttpResponse *http.Response
}

// Health checks the current status of the Data API, returning whether it's ready
// to accept requests or not.
func (c *Client) Health(ctx context.Context) (*HealthResponse, error) {
	uri := fmt.Sprintf("%s/v1/health", c.endpoint)
	req, err := http.NewRequestWithContext(ctx, http.MethodGet, uri, nil)
	if err != nil {
		return nil, fmt.Errorf("checking the health endpoint: %+v", err)
	}

	resp, err := c.client.Do(req)
	if err != nil {
		return nil, fmt.Errorf("performing request: %+v", err)
	}

	return &HealthResponse{
		Available:    resp.StatusCode == http.StatusOK,
		HttpResponse: resp,
	}, nil
}
