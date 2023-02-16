package generator

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/sdk/resourcemanager"
	"github.com/hashicorp/pandora/tools/sdk/services"
)

type metaClientTemplater struct {
	serviceName string
	apiVersion  string
	resources   map[string]services.Resource
	source      resourcemanager.ApiDefinitionsSource
}

func (m metaClientTemplater) template() (*string, error) {
	resourceNames := make([]string, 0)
	for k := range m.resources {
		resourceNames = append(resourceNames, k)
	}
	sort.Strings(resourceNames)

	imports := make([]string, 0)
	clientInitialization := make([]string, 0)
	fields := make([]string, 0)
	assignments := make([]string, 0)
	for _, resourceName := range resourceNames {
		variableName := fmt.Sprintf("%s%sClient", strings.ToLower(string(resourceName[0])), resourceName[1:])

		imports = append(imports, fmt.Sprintf(`"github.com/hashicorp/go-azure-sdk/resource-manager/%s/%s/%s"`, strings.ToLower(m.serviceName), m.apiVersion, strings.ToLower(resourceName)))
		fields = append(fields, fmt.Sprintf("%[1]s *%[2]s.%[1]sClient", resourceName, strings.ToLower(resourceName)))
		clientInitializationTemplate := fmt.Sprintf(`%[1]s, err := %[2]s.New%[3]sClientWithBaseURI(api)
if err != nil {
	return nil, fmt.Errorf("building %[3]s client: %%+v", err)
}
configureFunc(%[1]s.Client)
`, variableName, strings.ToLower(resourceName), resourceName)
		clientInitialization = append(clientInitialization, clientInitializationTemplate)
		assignments = append(assignments, fmt.Sprintf("%[1]s: %[2]s,", resourceName, variableName))
	}

	sort.Strings(assignments)
	sort.Strings(clientInitialization)
	sort.Strings(fields)
	sort.Strings(imports)

	packageName := fmt.Sprintf("v%s", strings.ReplaceAll(m.apiVersion, "-", "_"))

	out := fmt.Sprintf(`package %[1]s

import (
	"github.com/hashicorp/go-azure-sdk/sdk/environments"
	"github.com/hashicorp/go-azure-sdk/sdk/client/resourcemanager"
	%[2]s
)

type Client struct {
	%[3]s
}

func NewClientWithBaseURI(api environments.Api, configureFunc func(c *resourcemanager.Client)) (*Client, error) {
	%[4]s

	return &Client{
		%[5]s
	}, nil
}
`, packageName, strings.Join(imports, "\n"), strings.Join(fields, "\n"), strings.Join(clientInitialization, "\n"), strings.Join(assignments, "\n"))
	return &out, nil
}
