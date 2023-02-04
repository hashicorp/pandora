package generator

import (
	"testing"
)

func TestTemplateClient(t *testing.T) {
	input := ServiceGeneratorData{
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
	"github.com/hashicorp/go-azure-sdk/sdk/environments"
	"github.com/hashicorp/go-azure-sdk/sdk/client/resourcemanager"
	"github.com/hashicorp/go-azure-sdk/sdk/environments"
)

// acctests licence placeholder

type ExampleClient struct {
	Client  *resourcemanager.Client
}

func NewExampleClientWithBaseURI(api environments.Api) (*ExampleClient, error) {
	client, err := resourcemanager.NewResourceManagerClient(api, "somepackage", defaultApiVersion)
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
