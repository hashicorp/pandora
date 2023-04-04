using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerRegistry.v2022_12_01.Tokens;

internal class Definition : ResourceDefinition
{
    public string Name => "Tokens";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ProvisioningStateConstant),
        typeof(TokenCertificateNameConstant),
        typeof(TokenPasswordNameConstant),
        typeof(TokenStatusConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(TokenModel),
        typeof(TokenCertificateModel),
        typeof(TokenCredentialsPropertiesModel),
        typeof(TokenPasswordModel),
        typeof(TokenPropertiesModel),
        typeof(TokenUpdateParametersModel),
        typeof(TokenUpdatePropertiesModel),
    };
}
