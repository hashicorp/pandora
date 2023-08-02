using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.ApiOperation;

internal class Definition : ResourceDefinition
{
    public string Name => "ApiOperation";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetEntityTagOperation(),
        new ListByApiOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(OperationContractModel),
        typeof(OperationContractPropertiesModel),
        typeof(OperationUpdateContractModel),
        typeof(OperationUpdateContractPropertiesModel),
        typeof(ParameterContractModel),
        typeof(ParameterExampleContractModel),
        typeof(RepresentationContractModel),
        typeof(RequestContractModel),
        typeof(ResponseContractModel),
    };
}
