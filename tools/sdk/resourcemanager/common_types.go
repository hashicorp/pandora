package resourcemanager

import (
	"encoding/json"
	"fmt"
)

type CommonTypesClient struct {
	Client
}

func (c CommonTypesClient) Get() (*CommonTypesDetails, error) {
	endpoint := fmt.Sprintf("%s%s/commonTypes", c.endpoint, c.apiEndpoint)
	resp, err := c.client.Get(endpoint)
	if err != nil {
		return nil, err
	}

	// TODO: handle this being a 404 etc

	var response CommonTypesDetails
	if err := json.NewDecoder(resp.Body).Decode(&response); err != nil {
		return nil, err
	}

	return &response, nil
}

type CommonTypesDetails struct {
	// Constants is a map of key (Constant Name) to value (ConstantDetails) describing
	// each common Constant supported by this API
	Constants map[string]ConstantDetails `json:"constants"`

	// Models is a map of key (Model Name) to value (ModelDetails) describing
	// each common Model supported by this API
	Models map[string]ModelDetails `json:"models"`
}
