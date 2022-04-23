package generator

import "fmt"

var _ templater = clientsTemplater{}

type clientsTemplater struct {
}

func (c clientsTemplater) template(data ServiceGeneratorData) (*string, error) {
	template := fmt.Sprintf(`package %[1]s

import "github.com/Azure/go-autorest/autorest"

type %[2]s struct {
	Client  autorest.Client
	baseUri string
}

func New%[2]sWithBaseURI(endpoint string) %[2]s {
	return %[2]s{
		Client: autorest.NewClientWithUserAgent(userAgent()),
		baseUri: endpoint,
	}
}`, data.packageName, data.serviceClientName)
	return &template, nil
}
