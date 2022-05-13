using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.HandDefined.AADB2C.v2021_04_01_preview.Tenants;

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