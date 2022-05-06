package generator

import "fmt"

var _ templater = clientsAutoRestTemplater{}

type clientsAutoRestTemplater struct {
}

func (c clientsAutoRestTemplater) template(data ServiceGeneratorData) (*string, error) {
	copyrightLines, err := copyrightLinesForSource(data.source)
	if err != nil {
		return nil, fmt.Errorf("retrieving copyright lines: %+v", err)
	}

	template := fmt.Sprintf(`package %[1]s

import "github.com/Azure/go-autorest/autorest"

%[3]s

type %[2]s struct {
	Client  autorest.Client
	baseUri string
}

func New%[2]sWithBaseURI(endpoint string) %[2]s {
	return %[2]s{
		Client: autorest.NewClientWithUserAgent(userAgent()),
		baseUri: endpoint,
	}
}`, data.packageName, data.serviceClientName, *copyrightLines)
	return &template, nil
}
