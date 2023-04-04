using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AzureStackHCI.v2023_02_01.UpdateSummaries;

internal class Definition : ResourceDefinition
{
    public string Name => "UpdateSummaries";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new UpdateSummariesDeleteOperation(),
        new UpdateSummariesGetOperation(),
        new UpdateSummariesListOperation(),
        new UpdateSummariesPutOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(HealthStateConstant),
        typeof(ProvisioningStateConstant),
        typeof(SeverityConstant),
        typeof(StatusConstant),
        typeof(UpdateSummariesPropertiesStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(PackageVersionInfoModel),
        typeof(PrecheckResultModel),
        typeof(PrecheckResultTagsModel),
        typeof(UpdateSummariesModel),
        typeof(UpdateSummariesPropertiesModel),
    };
}
