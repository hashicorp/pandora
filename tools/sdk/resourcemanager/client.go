// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package resourcemanager

import (
	"fmt"
	"net/http"

	"github.com/hashicorp/go-retryablehttp"
)

type Client struct {
	// endpoint is the domain where the Data API is running (e.g. `http://localhost:5000`)
	endpoint string

	// apiEndpoint defines the root api endpoint for this client (e.g. `/v1/resource-manager`)
	apiEndpoint string

	// client is the HTTP Client used for HTTP requests
	client *http.Client
}

func NewMicrosoftGraphClient(endpoint string) Client {
	return Client{
		endpoint:    fmt.Sprintf("%s", endpoint),
		apiEndpoint: "/v1/microsoft-graph",
		client:      retryablehttp.NewClient().StandardClient(),
	}
}
func NewResourceManagerClient(endpoint string) Client {
	return Client{
		endpoint:    fmt.Sprintf("%s", endpoint),
		apiEndpoint: "/v1/resource-manager",
		client:      retryablehttp.NewClient().StandardClient(),
	}
}

func (c Client) ApiOperations() ApiOperationsClient {
	return ApiOperationsClient{
		Client: c,
	}
}

func (c Client) ApiSchema() ApiSchemaClient {
	return ApiSchemaClient{
		Client: c,
	}
}

func (c Client) ServiceDetails() ServiceDetailsClient {
	return ServiceDetailsClient{
		Client: c,
	}
}

func (c Client) ServiceVersion() ServiceVersionClient {
	return ServiceVersionClient{
		Client: c,
	}
}

func (c Client) Services() ServicesClient {
	return ServicesClient{
		Client: c,
	}
}

func (c Client) Terraform() TerraformClient {
	return TerraformClient{
		Client: c,
	}
}
