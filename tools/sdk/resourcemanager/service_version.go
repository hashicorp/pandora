package resourcemanager

import (
	"encoding/json"
	"fmt"
)

type ServiceVersionClient struct {
	Client
}

func (c ServiceVersionClient) Get(input ServiceVersion) (*ServiceVersionDetails, error) {
	endpoint := fmt.Sprintf("%s%s", c.endpoint, input.Uri)
	resp, err := c.client.Get(endpoint)
	if err != nil {
		return nil, err
	}

	// TODO: handle this being a 404 etc

	var response ServiceVersionDetails
	if err := json.NewDecoder(resp.Body).Decode(&response); err != nil {
		return nil, err
	}

	return &response, nil
}

type ServiceVersionDetails struct {
	// Resources is a key (Resource Name) value (ResourceSummary) pair of Resource
	// supported by this Service Version
	Resources map[string]ResourceSummary `json:"resources"`
}

type ResourceSummary struct {
	// OperationsUri is an endpoint which contains information about the Operations
	// supported by this Resource
	OperationsUri string `json:"operationsUri"`

	// SchemaUri is an endpoint which contains information about the Schema for
	// this Resource
	SchemaUri string `json:"schemaUri"`
}
