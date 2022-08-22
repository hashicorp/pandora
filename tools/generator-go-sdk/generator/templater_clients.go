package generator

import "fmt"

var _ templaterForResource = clientsTemplater{}

type clientsTemplater struct {
}

func (c clientsTemplater) template(data ServiceGeneratorData) (*string, error) {
	copyrightLines, err := copyrightLinesForSource(data.source)
	if err != nil {
		return nil, fmt.Errorf("retrieving copyright lines: %+v", err)
	}

	template := fmt.Sprintf(`package %[1]s

import (
	"github.com/hashicorp/go-azure-sdk/sdk/client/resourcemanager"
	"github.com/hashicorp/go-azure-sdk/sdk/environments"
)

%[3]s

type %[2]s struct {
	Client  *resourcemanager.Client
	baseUri string
}

func New%[2]sWithBaseURI(endpoint string) %[2]s {
	return %[2]s{
		Client: resourcemanager.NewResourceManagerClient(environments.ApiEndpoint(endpoint)),
		baseUri: endpoint,
	}
}`, data.packageName, data.serviceClientName, *copyrightLines)
	return &template, nil
}
