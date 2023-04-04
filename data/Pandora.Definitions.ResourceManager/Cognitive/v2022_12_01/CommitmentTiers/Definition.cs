using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Cognitive.v2022_12_01.CommitmentTiers;

internal class Definition : ResourceDefinition
{
    public string Name => "CommitmentTiers";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(HostingModelConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CommitmentCostModel),
        typeof(CommitmentQuotaModel),
        typeof(CommitmentTierModel),
    };
}
