package generator

import "fmt"

var _ templaterForResource = clientsTemplater{}

type clientsTemplater struct {
}

func (c clientsTemplater) template(data GeneratorData) (*string, error) {
	copyrightLines, err := copyrightLinesForSource(data.source)
	if err != nil {
		return nil, fmt.Errorf("retrieving copyright lines: %+v", err)
	}

	template := fmt.Sprintf(`package %[1]s

import (
	"github.com/hashicorp/go-azure-sdk/sdk/client/resourcemanager"
	sdkEnv "github.com/hashicorp/go-azure-sdk/sdk/environments"
)

%[3]s

type %[2]s struct {
	Client  *resourcemanager.Client
}

func New%[2]sWithBaseURI(sdkApi sdkEnv.Api) (*%[2]s, error) {
	client, err := resourcemanager.NewResourceManagerClient(sdkApi, %[1]q, defaultApiVersion)
	if err != nil {
		return nil, fmt.Errorf("instantiating %[2]s: %%+v", err)
	}

	return &%[2]s{
		Client: client,
	}, nil
}`, data.packageName, data.serviceClientName, *copyrightLines)
	return &template, nil
}
