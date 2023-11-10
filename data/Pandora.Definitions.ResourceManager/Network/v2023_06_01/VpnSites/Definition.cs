using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Network.v2023_06_01.VpnSites;

internal class Definition : ResourceDefinition
{
    public string Name => "VpnSites";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new UpdateTagsOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AddressSpaceModel),
        typeof(BgpSettingsModel),
        typeof(DevicePropertiesModel),
        typeof(IPConfigurationBgpPeeringAddressModel),
        typeof(O365BreakOutCategoryPoliciesModel),
        typeof(O365PolicyPropertiesModel),
        typeof(SubResourceModel),
        typeof(TagsObjectModel),
        typeof(VpnLinkBgpSettingsModel),
        typeof(VpnLinkProviderPropertiesModel),
        typeof(VpnSiteModel),
        typeof(VpnSiteLinkModel),
        typeof(VpnSiteLinkPropertiesModel),
        typeof(VpnSitePropertiesModel),
    };
}
