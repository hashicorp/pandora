using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ElasticSan.v2021_11_20_preview.ElasticSans;

internal class Definition : ResourceDefinition
{
    public string Name => "ElasticSans";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListBySubscriptionOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ProvisioningStatesConstant),
        typeof(SkuNameConstant),
        typeof(SkuTierConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ElasticSanModel),
        typeof(ElasticSanPropertiesModel),
        typeof(ElasticSanUpdateModel),
        typeof(ElasticSanUpdatePropertiesModel),
        typeof(SkuModel),
    };
}
