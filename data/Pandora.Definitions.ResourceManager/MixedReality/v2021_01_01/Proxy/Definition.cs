using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MixedReality.v2021_01_01.Proxy;

internal class Definition : ResourceDefinition
{
    public string Name => "Proxy";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckNameAvailabilityLocalOperation(),
        new RemoteRenderingAccountsListBySubscriptionOperation(),
        new SpatialAnchorsAccountsListBySubscriptionOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(NameUnavailableReasonConstant),
        typeof(SkuTierConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CheckNameAvailabilityRequestModel),
        typeof(CheckNameAvailabilityResponseModel),
        typeof(MixedRealityAccountPropertiesModel),
        typeof(RemoteRenderingAccountModel),
        typeof(SkuModel),
        typeof(SpatialAnchorsAccountModel),
    };
}
