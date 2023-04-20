using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.KeyVault.v2023_02_01.MHSMPrivateLinkResources;

internal class Definition : ResourceDefinition
{
    public string Name => "MHSMPrivateLinkResources";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ListByMHSMResourceOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ManagedHsmSkuFamilyConstant),
        typeof(ManagedHsmSkuNameConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(MHSMPrivateLinkResourceModel),
        typeof(MHSMPrivateLinkResourceListResultModel),
        typeof(MHSMPrivateLinkResourcePropertiesModel),
        typeof(ManagedHsmSkuModel),
    };
}
