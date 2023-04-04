using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.KeyVault.v2021_10_01.Keys;

internal class Definition : ResourceDefinition
{
    public string Name => "Keys";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateIfNotExistOperation(),
        new GetOperation(),
        new GetVersionOperation(),
        new ListOperation(),
        new ListVersionsOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AccessPolicyUpdateKindConstant),
        typeof(DeletionRecoveryLevelConstant),
        typeof(JsonWebKeyCurveNameConstant),
        typeof(JsonWebKeyOperationConstant),
        typeof(JsonWebKeyTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(KeyModel),
        typeof(KeyAttributesModel),
        typeof(KeyCreateParametersModel),
        typeof(KeyPropertiesModel),
    };
}
