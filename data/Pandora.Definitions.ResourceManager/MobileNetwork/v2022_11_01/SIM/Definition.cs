using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MobileNetwork.v2022_11_01.SIM;

internal class Definition : ResourceDefinition
{
    public string Name => "SIM";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ProvisioningStateConstant),
        typeof(SimStateConstant),
        typeof(SiteProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AttachedDataNetworkResourceIdModel),
        typeof(SimModel),
        typeof(SimPolicyResourceIdModel),
        typeof(SimPropertiesFormatModel),
        typeof(SimStaticIPPropertiesModel),
        typeof(SimStaticIPPropertiesStaticIPModel),
        typeof(SliceResourceIdModel),
    };
}
