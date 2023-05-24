package pipeline

import (
	"fmt"
	"github.com/hashicorp/go-hclog"
)

func (pipelineTask) templateResourceIds(files *Tree, packageName string, resources []*Resource, logger hclog.Logger) error {
	resourceIds := make(map[string]string)

	for _, resource := range resources {
		clientMethodFile := fmt.Sprintf("%s/%s/%s/ResourceId-%s.cs", resource.Service, cleanVersion(resource.Version), pluralize(resource.Name), "BLAH")
		resourceIds[clientMethodFile] = templateResourceId(resource)
	}

	return nil
}

func templateResourceId(resource *Resource) string {
	return fmt.Sprintf(`using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

namespace Pandora.Definitions.MicrosoftGraph.%[1]s.%[2]s.%[3]s;

internal class B2CDirectoryId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroup}/providers/Microsoft.AzureActiveDirectory/b2cDirectories/{directoryName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("subscriptions", "subscriptions"),
        ResourceIDSegment.SubscriptionId("subscriptionId"),
        ResourceIDSegment.Static("resourceGroups", "resourceGroups"),
        ResourceIDSegment.ResourceGroup("resourceGroup"),
        ResourceIDSegment.Static("providers", "providers"),
        ResourceIDSegment.ResourceProvider("microsoftAzureActiveDirectory", "Microsoft.AzureActiveDirectory"),
        ResourceIDSegment.Static("b2cDirectories", "b2cDirectories"),
        ResourceIDSegment.UserSpecified("directoryName"),
    };
}

internal class %[4]sOperation : Operations.%[5]sOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
%[6]s,
        };

    public override ResourceID? ResourceId() => new %[7]s();

    public override Type? ResponseObject() => typeof(%[8]sModel);


}
`, resource.Service, cleanVersion(resource.Version), pluralize(resource.Name))
}
