package v1

import (
	"net/http"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

type Client struct {
	// client is the HTTP Client used for HTTP requests
	client *http.Client

	// endpoint specifies the base endpoint for the Data API.
	// Typically this will be `http://localhost:8080` but can vary.
	endpoint string

	// sourceDataType specifies the Data Source Type being queried.
	sourceDataType models.SourceDataType
}

// NewClient returns an instance of Client configured for the current endpoint
// and sourceDataType combination - used to retrieve information from the Data API.
func NewClient(endpoint string, sourceDataType models.SourceDataType) *Client {
	return &Client{
		// NOTE: this is retryable to account for tooling interfering with connections
		client:         retryablehttp.NewClient().StandardClient(),
		endpoint:       endpoint,
		sourceDataType: sourceDataType,
	}
}
