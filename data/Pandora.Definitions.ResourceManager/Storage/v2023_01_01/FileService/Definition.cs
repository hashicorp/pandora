using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Storage.v2023_01_01.FileService;

internal class Definition : ResourceDefinition
{
    public string Name => "FileService";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetServicePropertiesOperation(),
        new ListOperation(),
        new SetServicePropertiesOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AllowedMethodsConstant),
        typeof(SkuNameConstant),
        typeof(SkuTierConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CorsRuleModel),
        typeof(CorsRulesModel),
        typeof(DeleteRetentionPolicyModel),
        typeof(FileServiceItemsModel),
        typeof(FileServicePropertiesModel),
        typeof(FileServicePropertiesPropertiesModel),
        typeof(MultichannelModel),
        typeof(ProtocolSettingsModel),
        typeof(SkuModel),
        typeof(SmbSettingModel),
    };
}
