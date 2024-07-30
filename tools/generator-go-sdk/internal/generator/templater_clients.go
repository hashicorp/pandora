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
	"github.com/hashicorp/go-azure-sdk/sdk/client"
	"github.com/hashicorp/go-azure-sdk/sdk/client/msgraph"
	"github.com/hashicorp/go-azure-sdk/sdk/client/resourcemanager"
	sdkEnv "github.com/hashicorp/go-azure-sdk/sdk/environments"
)

%[4]s

type %[2]s struct {
	Client  *%[3]s.Client
}

func New%[2]sWithBaseURI(sdkApi sdkEnv.Api) (*%[2]s, error) {
	client, err := %[3]s.NewResourceManagerClient(sdkApi, %[1]q, defaultApiVersion)
	if err != nil {
		return nil, fmt.Errorf("instantiating %[2]s: %%+v", err)
	}

	return &%[2]s{
		Client: client,
	}, nil
}`, data.packageName, data.serviceClientName, data.baseClientPackage, *copyrightLines)
	return &template, nil
}
