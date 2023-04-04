using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.GlobalParameters;

internal class Definition : ResourceDefinition
{
    public string Name => "GlobalParameters";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByFactoryOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(GlobalParameterTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(GlobalParameterResourceModel),
        typeof(GlobalParameterSpecificationModel),
    };
}
