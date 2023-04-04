using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Storage.v2022_09_01.BlobService;

internal class Definition : ResourceDefinition
{
    public string Name => "BlobService";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetServicePropertiesOperation(),
        new ListOperation(),
        new SetServicePropertiesOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AllowedMethodsConstant),
        typeof(NameConstant),
        typeof(SkuNameConstant),
        typeof(SkuTierConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(BlobServiceItemsModel),
        typeof(BlobServicePropertiesModel),
        typeof(BlobServicePropertiesPropertiesModel),
        typeof(ChangeFeedModel),
        typeof(CorsRuleModel),
        typeof(CorsRulesModel),
        typeof(DeleteRetentionPolicyModel),
        typeof(LastAccessTimeTrackingPolicyModel),
        typeof(RestorePolicyPropertiesModel),
        typeof(SkuModel),
    };
}
