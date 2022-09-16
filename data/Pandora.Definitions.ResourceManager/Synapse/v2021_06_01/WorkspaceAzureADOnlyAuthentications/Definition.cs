using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Synapse.v2021_06_01.WorkspaceAzureADOnlyAuthentications;

internal class Definition : ResourceDefinition
{
    public string Name => "WorkspaceAzureADOnlyAuthentications";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AzureADOnlyAuthenticationsCreateOperation(),
        new AzureADOnlyAuthenticationsGetOperation(),
        new AzureADOnlyAuthenticationsListOperation(),
    };
}
