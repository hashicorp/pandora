using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Nginx.v2022_08_01.NginxDeployment;

internal class Definition : ResourceDefinition
{
    public string Name => "NginxDeployment";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new DeploymentsCreateOperation(),
        new DeploymentsDeleteOperation(),
        new DeploymentsGetOperation(),
        new DeploymentsListOperation(),
        new DeploymentsListByResourceGroupOperation(),
        new DeploymentsUpdateOperation(),
    };
}
