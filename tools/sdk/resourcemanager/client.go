package resourcemanager

import (
	"fmt"
	"net/http"
)

type Client struct {
	// endpoint is the domain where the Data API is running (e.g. `http://localhost:5000`)
	endpoint string

	// apiEndpoint defines the root api endpoint for this client (e.g. `/v1/resource-manager`)
	apiEndpoint string

	// client is the HTTP Client used for HTTP requests
	client *http.Client
}

func NewMicrosoftGraphBetaClient(endpoint string) Client {
	return Client{
		endpoint:    fmt.Sprintf("%s", endpoint),
		apiEndpoint: "/v1/microsoft-graph/beta",
		client:      http.DefaultClient,
	}
}

func NewMicrosoftGraphStableV1Client(endpoint string) Client {
	return Client{
		endpoint:    fmt.Sprintf("%s", endpoint),
		apiEndpoint: "/v1/microsoft-graph/stable-v1",
		client:      http.DefaultClient,
	}
}

func NewResourceManagerClient(endpoint string) Client {
	return Client{
		endpoint:    fmt.Sprintf("%s", endpoint),
		apiEndpoint: "/v1/resource-manager",
		client:      http.DefaultClient,
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

func (c Client) CommonTypes() CommonTypesClient {
	return CommonTypesClient{
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
