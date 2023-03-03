package pipeline

import (
	"fmt"
	"strings"
)

func templateClient(files *Tree, packageName string) error {
	clientName := strings.Title(packageName)
	tmpl := []string{
		`const defaultApiVersion = "v1.0"`,
		fmt.Sprintf(`type %sClient struct {
			Client *msgraph.Client
		}`, strings.Title(packageName)),
		fmt.Sprintf(`func New%[1]sClient(api environments.Api) (*%[1]sClient, error) {
			client, err := msgraph.NewMsGraphClient(api, defaultApiVersion)
			if err != nil {
				return nil, fmt.Errorf("instantiating %[1]sClient: %%+v", err)
			}

			return &%[1]sClient{
				Client: client,
			}, nil
		}`, clientName),
	}
	return files.addFile(fmt.Sprintf("%s/client.go", packageName), templateFile(packageName, tmpl))
}

func templateOptions(files *Tree, packageName string) error {
	tmpl := []string{
		`type Options struct{}`,
		`func (o Options) ToHeaders() *client.Headers {
			return nil
		}`,
		`func (o Options) ToOData() *odata.Query {
			return nil
		}`,
		`func (o Options) ToQuery() *client.QueryParams {
			return nil
		}`,
	}
	return files.addFile(fmt.Sprintf("%s/options.go", packageName), templateFile(packageName, tmpl))
}
