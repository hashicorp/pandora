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
	"github.com/hashicorp/go-azure-sdk/sdk/client/resourcemanager"
	"github.com/hashicorp/go-azure-sdk/sdk/environments"
)

// acctests licence placeholder

type ExampleClient struct {
	Client  *resourcemanager.Client
	baseUri string
}

func NewExampleClientWithBaseURI(endpoint string) ExampleClient {
	return ExampleClient{
		Client: resourcemanager.NewResourceManagerClient(environments.ApiEndpoint(endpoint)),
		baseUri: endpoint,
	}
}`
	assertTemplatedCodeMatches(t, expected, *actual)
}
