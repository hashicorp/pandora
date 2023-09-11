using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.IdentityProvider;

internal class Definition : ResourceDefinition
{
    public string Name => "IdentityProvider";
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
        typeof(IdentityProviderTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ClientSecretContractModel),
        typeof(IdentityProviderContractModel),
        typeof(IdentityProviderContractPropertiesModel),
        typeof(IdentityProviderCreateContractModel),
        typeof(IdentityProviderCreateContractPropertiesModel),
        typeof(IdentityProviderUpdateParametersModel),
        typeof(IdentityProviderUpdatePropertiesModel),
    };
}
