package definitions

import (
	"fmt"
	"sort"
	"strings"

	"github.com/hashicorp/pandora/tools/generator-terraform/generator/helpers"
	"github.com/hashicorp/pandora/tools/generator-terraform/generator/models"
)

var servicesUsingOldBaseLayer = map[string]struct{}{
	// TODO: the old base layer related logic can be removed from `generator-terraform` in a follow-up PR

	// purely for testing purposes
	"examplelegacypackage": {},
}

func templateForServiceClient(input models.ServiceInput) string {
	importLines := make([]string, 0)
	autoClientLines := make([]string, 0)
	assignmentLines := make([]string, 0)
	assignmentOldBaseLayerLines := make([]string, 0)
	returnLines := make([]string, 0)
	returnOldBaseLayerLines := make([]string, 0)

	versions := make([]string, 0)
	versionsToResources := make(map[string][]string, 0)
	for resource, version := range input.ResourceToApiVersion {
		if _, ok := versionsToResources[version]; !ok {
			versions = append(versions, version)
		}
		versionsToResources[version] = append(versionsToResources[version], resource)
	}

	sort.Strings(versions)

	for _, version := range versions {
		apiVersionFormatted := strings.Title(helpers.NamespaceForApiVersion(version))

		importLine := fmt.Sprintf(`%[1]s%[2]s "github.com/hashicorp/go-azure-sdk/resource-manager/%[1]s/%[3]s"`, strings.ToLower(input.SdkServiceName), apiVersionFormatted, version)
		importLines = append(importLines, importLine)

		autoClientLine := fmt.Sprintf(`%[1]s %[2]s%[1]s.Client`, apiVersionFormatted, strings.ToLower(input.SdkServiceName))
		autoClientLines = append(autoClientLines, autoClientLine)

		assignmentLine := fmt.Sprintf(`
		%[1]sClient, err := %[2]s%[3]s.NewClientWithBaseURI(o.Environment.ResourceManager, func(c *resourcemanager.Client) {
			o.Configure(c, o.Authorizers.ResourceManager)
		})
		if err != nil {
			return nil, fmt.Errorf("building client for %[2]s %[3]s: %%+v", err)
		}
`, helpers.NamespaceForApiVersion(version), strings.ToLower(input.SdkServiceName), apiVersionFormatted)
		assignmentLines = append(assignmentLines, assignmentLine)

		assignmentOldBaseLayerLine := fmt.Sprintf(`
		%[1]sClient := %[2]s%[3]s.NewClientWithBaseURI(o.ResourceManagerEndpoint, func(c *autorest.Client) {
			o.ConfigureClient(c, o.ResourceManagerAuthorizer)
		})
`, helpers.NamespaceForApiVersion(version), strings.ToLower(input.SdkServiceName), apiVersionFormatted)
		assignmentOldBaseLayerLines = append(assignmentOldBaseLayerLines, assignmentOldBaseLayerLine)

		returnLine := fmt.Sprintf(`%[1]s: *%[2]sClient,`, apiVersionFormatted, helpers.NamespaceForApiVersion(version))
		returnLines = append(returnLines, returnLine)

		returnOldBaseLayerLine := fmt.Sprintf(`%[1]s: %[2]sClient,`, apiVersionFormatted, helpers.NamespaceForApiVersion(version))
		returnOldBaseLayerLines = append(returnOldBaseLayerLines, returnOldBaseLayerLine)
	}

	output := fmt.Sprintf(`
package client

import (
	%[1]s
	"github.com/hashicorp/go-azure-sdk/sdk/client/resourcemanager"
	"github.com/hashicorp/terraform-provider-%[5]s/internal/common"
)

type AutoClient struct {
	%[2]s
}

func NewClient(o *common.ClientOptions) (*AutoClient, error) {
	%[3]s

	return &AutoClient{
		%[4]s
	}, nil
}
`, strings.Join(importLines, "\n"), strings.Join(autoClientLines, "\n"), strings.Join(assignmentLines, "\n"), strings.Join(returnLines, "\n"), input.ProviderPrefix)

	if _, ok := servicesUsingOldBaseLayer[strings.ToLower(input.SdkServiceName)]; ok {
		output = fmt.Sprintf(`
package client

import (
	"github.com/Azure/go-autorest/autorest"
	%[1]s
	"github.com/hashicorp/terraform-provider-%[5]s/internal/common"
)

type AutoClient struct {
	%[2]s
}

func NewClient(o *common.ClientOptions) (*AutoClient, error) {
	%[3]s

	return &AutoClient{
		%[4]s
	}, nil
}
`, strings.Join(importLines, "\n"), strings.Join(autoClientLines, "\n"), strings.Join(assignmentOldBaseLayerLines, "\n"), strings.Join(returnOldBaseLayerLines, "\n"), input.ProviderPrefix)
	}

	return strings.TrimSpace(output)
}
