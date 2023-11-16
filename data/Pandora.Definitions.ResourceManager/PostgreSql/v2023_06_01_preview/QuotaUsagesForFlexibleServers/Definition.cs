using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PostgreSql.v2023_06_01_preview.QuotaUsagesForFlexibleServers;

internal class Definition : ResourceDefinition
{
    public string Name => "QuotaUsagesForFlexibleServers";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new QuotaUsagesListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(NamePropertyModel),
        typeof(QuotaUsageModel),
    };
}
