package resourcemanager

import (
	"encoding/json"
	"fmt"
)

type ServicesClient struct {
	Client
}

type ServiceSummary struct {
	// Generate specifies whether this API should be generated or not
	Generate bool `json:"generate"`

	// Uri is the Uri used to access more information about this Service
	Uri string `json:"uri"`
}

func (c ServicesClient) Get() (*map[string]ServiceSummary, error) {
	endpoint := fmt.Sprintf("%s/v1/resource-manager/services", c.endpoint)
	resp, err := c.client.Get(endpoint)
	if err != nil {
		return nil, err
	}

	// TODO: handle this being a 404 etc

	var response struct {
		Services map[string]ServiceSummary `json:"services"`
	}
	if err := json.NewDecoder(resp.Body).Decode(&response); err != nil {
		return nil, err
	}

	return &response.Services, nil
}
