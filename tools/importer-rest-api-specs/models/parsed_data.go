package models

import "fmt"

type ParsedData struct {
	ServiceName string
	ApiVersion  string
	Resources   map[string]AzureApiResource
}

func (d ParsedData) Key() string {
	return fmt.Sprintf("%s-%s", d.ServiceName, d.ApiVersion)
}
