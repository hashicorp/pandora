package generator

import (
	"testing"
)

func TestTemplateClient(t *testing.T) {
	input := ServiceGeneratorData{
		baseClientPackage: "baseClient",
		baseClientMethod:  "NewBaseClient",
		packageName:       "somepackage",
		serviceClientName: "ExampleClient",
		source:            AccTestLicenceType,
	}

	actual, err := clientsTemplater{}.template(input)
	if err != nil {
		t.Fatal(err.Error())
	}

	expected := `package somepackage

import (
	sdkEnv "github.com/hashicorp/go-azure-sdk/sdk/environments"
	"github.com/hashicorp/go-azure-sdk/sdk/client/baseClient"
)

// acctests licence placeholder

type ExampleClient struct {
	Client  *baseClient.Client
}

func NewExampleClientWithBaseURI(api sdkEnv.Api) (*ExampleClient, error) {
	client, err := baseClient.NewBaseClient(api, "somepackage", defaultApiVersion)
	if err != nil {
		return nil, fmt.Errorf("instantiating ExampleClient: %+v", err)
	}

	return &ExampleClient{
		Client: client,
	}, nil
}
`
	assertTemplatedCodeMatches(t, expected, *actual)
}
