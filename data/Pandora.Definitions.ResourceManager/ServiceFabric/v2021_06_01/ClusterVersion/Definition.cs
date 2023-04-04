using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceFabric.v2021_06_01.ClusterVersion;

internal class Definition : ResourceDefinition
{
    public string Name => "ClusterVersion";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new GetByEnvironmentOperation(),
        new ListOperation(),
        new ListByEnvironmentOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ClusterVersionsEnvironmentConstant),
        typeof(EnvironmentConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ClusterCodeVersionsListResultModel),
        typeof(ClusterCodeVersionsResultModel),
        typeof(ClusterVersionDetailsModel),
    };
}
