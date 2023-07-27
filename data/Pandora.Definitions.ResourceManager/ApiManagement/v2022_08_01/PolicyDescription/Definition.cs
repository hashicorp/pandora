using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.PolicyDescription;

internal class Definition : ResourceDefinition
{
    public string Name => "PolicyDescription";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ListByServiceOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(PolicyScopeContractConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(PolicyDescriptionCollectionModel),
        typeof(PolicyDescriptionContractModel),
        typeof(PolicyDescriptionContractPropertiesModel),
    };
}
