package generator

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

type metaClientTemplater struct {
	serviceName       string
	apiVersion        string
	baseClientPackage string
	resources         map[string]models.APIResource
	source            models.SourceDataOrigin
	sourceType        models.SourceDataType
}

func (m metaClientTemplater) template() (*string, error) {
	copyrightLines, err := copyrightLinesForSource(m.source)
	if err != nil {
		return nil, fmt.Errorf("retrieving copyright lines: %+v", err)
	}

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

		imports = append(imports, fmt.Sprintf(`"github.com/hashicorp/go-azure-sdk/%s/%s/%s/%s"`, m.sourceType, strings.ToLower(m.serviceName), m.apiVersion, strings.ToLower(resourceName)))
		fields = append(fields, fmt.Sprintf("%[1]s *%[2]s.%[1]sClient", resourceName, strings.ToLower(resourceName)))
		clientInitializationTemplate := fmt.Sprintf(`%[1]s, err := %[2]s.New%[3]sClientWithBaseURI(sdkApi)
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

	packageName := m.apiVersion
	if strings.Contains(packageName, "-") {
		packageName = fmt.Sprintf("v%s", strings.ReplaceAll(m.apiVersion, "-", "_"))
	}

	out := fmt.Sprintf(`package %[1]s

%[3]s

import (
	"fmt"

	"github.com/hashicorp/go-azure-sdk/sdk/client"
	"github.com/hashicorp/go-azure-sdk/sdk/client/msgraph"
	"github.com/hashicorp/go-azure-sdk/sdk/client/resourcemanager"
	sdkEnv "github.com/hashicorp/go-azure-sdk/sdk/environments"
	%[4]s
)

type Client struct {
	%[5]s
}

func NewClientWithBaseURI(sdkApi sdkEnv.Api, configureFunc func(c *%[2]s.Client)) (*Client, error) {
	%[6]s

	return &Client{
		%[7]s
	}, nil
}
`, packageName, m.baseClientPackage, *copyrightLines, strings.Join(imports, "\n"), strings.Join(fields, "\n"), strings.Join(clientInitialization, "\n"), strings.Join(assignments, "\n"))
	return &out, nil
}
