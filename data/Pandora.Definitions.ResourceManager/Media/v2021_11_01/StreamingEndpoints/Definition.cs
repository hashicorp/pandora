using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2021_11_01.StreamingEndpoints;

internal class Definition : ResourceDefinition
{
    public string Name => "StreamingEndpoints";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new ScaleOperation(),
        new SkusOperation(),
        new StartOperation(),
        new StopOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(StreamingEndpointResourceStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AkamaiAccessControlModel),
        typeof(AkamaiSignatureHeaderAuthenticationKeyModel),
        typeof(ArmStreamingEndpointCapacityModel),
        typeof(ArmStreamingEndpointCurrentSkuModel),
        typeof(ArmStreamingEndpointSkuModel),
        typeof(ArmStreamingEndpointSkuInfoModel),
        typeof(CrossSiteAccessPoliciesModel),
        typeof(IPAccessControlModel),
        typeof(IPRangeModel),
        typeof(StreamingEndpointModel),
        typeof(StreamingEndpointAccessControlModel),
        typeof(StreamingEndpointPropertiesModel),
        typeof(StreamingEndpointSkuInfoListResultModel),
        typeof(StreamingEntityScaleUnitModel),
    };
}
