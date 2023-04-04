using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServices.v2022_09_10.VaultUsages;

internal class Definition : ResourceDefinition
{
    public string Name => "VaultUsages";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new UsagesListByVaultsOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(UsagesUnitConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(NameInfoModel),
        typeof(VaultUsageModel),
        typeof(VaultUsageListModel),
    };
}
