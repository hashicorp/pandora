using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.AuthorizationServer;

internal class Definition : ResourceDefinition
{
    public string Name => "AuthorizationServer";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetEntityTagOperation(),
        new ListByServiceOperation(),
        new ListSecretsOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AuthorizationMethodConstant),
        typeof(BearerTokenSendingMethodConstant),
        typeof(ClientAuthenticationMethodConstant),
        typeof(GrantTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AuthorizationServerContractModel),
        typeof(AuthorizationServerContractPropertiesModel),
        typeof(AuthorizationServerSecretsContractModel),
        typeof(AuthorizationServerUpdateContractModel),
        typeof(AuthorizationServerUpdateContractPropertiesModel),
        typeof(TokenBodyParameterContractModel),
    };
}
