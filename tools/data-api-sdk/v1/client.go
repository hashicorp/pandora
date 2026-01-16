// Copyright IBM Corp. 2021, 2025
// SPDX-License-Identifier: MPL-2.0

package v1

import (
	"net/http"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/go-retryablehttp"
	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

type Client struct {
	// client is the HTTP Client used for HTTP requests
	client *http.Client

	// endpoint specifies the base endpoint for the Data API.
	// Typically this will be `http://localhost:8080` but can vary.
	endpoint string

	// logger specifies the logger for this SDK Client, this can be configured
	// using the SetLogger function.
	logger hclog.Logger

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
		logger:         hclog.NewNullLogger(),
		sourceDataType: sourceDataType,
	}
}

// SetLogger enables configuring a logger for debug purposes
func (c *Client) SetLogger(logger hclog.Logger) {
	c.logger = logger
}
