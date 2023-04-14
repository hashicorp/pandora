using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MySql.v2021_12_01_preview.Configurations;

internal class Definition : ResourceDefinition
{
    public string Name => "Configurations";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new BatchUpdateOperation(),
        new CreateOrUpdateOperation(),
        new GetOperation(),
        new ListByServerOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ConfigurationSourceConstant),
        typeof(IsConfigPendingRestartConstant),
        typeof(IsDynamicConfigConstant),
        typeof(IsReadOnlyConstant),
        typeof(ResetAllToDefaultConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ConfigurationModel),
        typeof(ConfigurationForBatchUpdateModel),
        typeof(ConfigurationForBatchUpdatePropertiesModel),
        typeof(ConfigurationListForBatchUpdateModel),
        typeof(ConfigurationListResultModel),
        typeof(ConfigurationPropertiesModel),
    };
}
