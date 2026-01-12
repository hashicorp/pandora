package generator

import (
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

var _ templaterForResource = clientsTemplater{}

type clientsTemplater struct {
}

var (
	resourceManagerClientTemplate = `package %[1]s

import (
	"fmt"

	"github.com/hashicorp/go-azure-sdk/sdk/client"
	"github.com/hashicorp/go-azure-sdk/sdk/client/dataplane"
	"github.com/hashicorp/go-azure-sdk/sdk/client/msgraph"
	"github.com/hashicorp/go-azure-sdk/sdk/client/resourcemanager"
	sdkEnv "github.com/hashicorp/go-azure-sdk/sdk/environments"
)

%[4]s

type %[2]s struct {
	Client  *%[3]s.Client
}

func New%[2]sWithBaseURI(sdkApi sdkEnv.Api) (*%[2]s, error) {
	client, err := %[3]s.NewClient(sdkApi, %[1]q, defaultApiVersion)
	if err != nil {
		return nil, fmt.Errorf("instantiating %[2]s: %%+v", err)
	}

	return &%[2]s{
		Client: client,
	}, nil
}`
	dataPlaneClientTemplate = `package %[1]s

import (
	"fmt"

	"github.com/hashicorp/go-azure-sdk/sdk/client"
	"github.com/hashicorp/go-azure-sdk/sdk/client/dataplane"
	"github.com/hashicorp/go-azure-sdk/sdk/client/msgraph"
	"github.com/hashicorp/go-azure-sdk/sdk/client/resourcemanager"
	sdkEnv "github.com/hashicorp/go-azure-sdk/sdk/environments"
)

%[4]s

type %[2]s struct {
	Client  *%[3]s.Client
}

func New%[2]sUnconfigured() (*%[2]s, error) {
	client, err := %[3]s.NewClient("please_configure_client_endpoint", %[1]q, defaultApiVersion)
	if err != nil {
		return nil, fmt.Errorf("instantiating %[2]s: %%+v", err)
	}

	return &%[2]s{
		Client: client,
	}, nil
}

func (c *%[2]s) %[2]sSetEndpoint(endpoint string) {
	c.Client.Client.BaseUri = endpoint 
}

func New%[2]sWithBaseURI(endpoint string) (*%[2]s, error) {
	client, err := %[3]s.NewClient(endpoint, %[1]q, defaultApiVersion)
	if err != nil {
		return nil, fmt.Errorf("instantiating %[2]s: %%+v", err)
	}

	return &%[2]s{
		Client: client,
	}, nil
}

func (c *%[2]s) Clone(endpoint string) *%[2]s {
	return &%[2]s{
		Client: c.Client.CloneClient(endpoint),
	}
}
`
)

func (c clientsTemplater) template(data GeneratorData) (*string, error) {
	copyrightLines, err := copyrightLinesForSource(data.source)
	if err != nil {
		return nil, fmt.Errorf("retrieving copyright lines: %+v", err)
	}

	var template string
	switch data.sourceType {
	case models.DataPlaneSourceDataType:
		template = fmt.Sprintf(dataPlaneClientTemplate, data.packageName, data.serviceClientName, data.baseClientPackage, *copyrightLines)
	default:
		template = fmt.Sprintf(resourceManagerClientTemplate, data.packageName, data.serviceClientName, data.baseClientPackage, *copyrightLines)
	}

	return &template, nil
}
