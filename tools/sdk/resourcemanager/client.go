package resourcemanager

import "net/http"

type Client struct {
	endpoint string
	client   *http.Client
}

func NewClient(endpoint string) Client {
	return Client{
		endpoint: endpoint,
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
