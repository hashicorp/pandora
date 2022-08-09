package generator

import (
	"testing"
)

func TestTemplateAutoRestClient(t *testing.T) {
	input := ServiceGeneratorData{
		packageName:       "somepackage",
		serviceClientName: "ExampleClient",
		source:            AccTestLicenceType,
	}

	actual, err := clientsAutoRestTemplater{}.template(input)
	if err != nil {
		t.Fatal(err.Error())
	}

	expected := `package somepackage

import "github.com/Azure/go-autorest/autorest"

// acctests licence placeholder

type ExampleClient struct {
	Client  autorest.Client
	baseUri string
}

func NewExampleClientWithBaseURI(endpoint string) ExampleClient {
	return ExampleClient{
		Client: autorest.NewClientWithUserAgent(userAgent()),
		baseUri: endpoint,
	}
}`
	assertTemplatedCodeMatches(t, expected, *actual)
}
