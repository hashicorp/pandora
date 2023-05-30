package resourcemanager

import (
	"fmt"
	"net/http"
)

type Client struct {
	endpoint string
	client   *http.Client
}

func NewMicrosoftGraphBetaClient(endpoint string) Client {
	return Client{
		endpoint: fmt.Sprintf("%s/v1/microsoft-graph/beta", endpoint),
		client:   http.DefaultClient,
	}
}

func NewMicrosoftGraphStableV1Client(endpoint string) Client {
	return Client{
		endpoint: fmt.Sprintf("%s/v1/microsoft-graph/stable-v1", endpoint),
		client:   http.DefaultClient,
	}
}

func NewResourceManagerClient(endpoint string) Client {
	return Client{
		endpoint: fmt.Sprintf("%s/v1/resource-manager", endpoint),
		client:   http.DefaultClient,
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
