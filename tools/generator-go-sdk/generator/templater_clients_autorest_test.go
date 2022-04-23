package generator

import (
	"strings"
	"testing"
)

func TestClientsAutoRestTemplater(t *testing.T) {
	input := ServiceGeneratorData{
		packageName:       "somepackage",
		serviceClientName: "ExampleClient",
	}

	actual, err := clientsAutoRestTemplater{}.template(input)
	if err != nil {
		t.Fatal(err.Error())
	}

	expected := `package somepackage

import "github.com/Azure/go-autorest/autorest"

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
	if !strings.EqualFold(strings.TrimSpace(*actual), strings.TrimSpace(expected)) {
		t.Fatalf("Expected:\n\n---\n%s\n---\nActual:\n%s", expected, *actual)
	}
}
