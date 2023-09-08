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
	sdkEnv "github.com/hashicorp/go-azure-sdk/sdk/environments"
	"github.com/hashicorp/go-azure-sdk/sdk/client/%[4]s"
)

%[3]s

type %[2]s struct {
	Client  *%[4]s.Client
}

func New%[2]sWithBaseURI(api sdkEnv.Api) (*%[2]s, error) {
	client, err := %[4]s.%[5]s(api, %[1]q, defaultApiVersion)
	if err != nil {
		return nil, fmt.Errorf("instantiating %[2]s: %%+v", err)
	}

	return &%[2]s{
		Client: client,
	}, nil
}`, data.packageName, data.serviceClientName, *copyrightLines, data.baseClientPackage, data.baseClientMethod)
	return &template, nil
}
