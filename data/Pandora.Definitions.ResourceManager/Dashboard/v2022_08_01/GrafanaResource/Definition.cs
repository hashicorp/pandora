using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Dashboard.v2022_08_01.GrafanaResource;

internal class Definition : ResourceDefinition
{
    public string Name => "GrafanaResource";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GrafanaCreateOperation(),
        new GrafanaDeleteOperation(),
        new GrafanaGetOperation(),
        new GrafanaListOperation(),
        new GrafanaListByResourceGroupOperation(),
        new GrafanaUpdateOperation(),
    };
}
