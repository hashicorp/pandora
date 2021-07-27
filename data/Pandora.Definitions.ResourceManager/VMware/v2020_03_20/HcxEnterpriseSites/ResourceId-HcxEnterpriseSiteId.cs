using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.VMware.v2020_03_20.HcxEnterpriseSites
{
    internal class HcxEnterpriseSiteId : ResourceID
    {
        public string ID() => "/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.AVS/privateClouds/{privateCloudName}/hcxEnterpriseSites/{hcxEnterpriseSiteName}";
    }
}
