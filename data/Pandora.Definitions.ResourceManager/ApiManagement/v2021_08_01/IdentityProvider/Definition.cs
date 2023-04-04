using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.IdentityProvider;

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
        typeof(AccessIdNameConstant),
        typeof(IdentityProviderTypeConstant),
        typeof(NotificationNameConstant),
        typeof(TemplateNameConstant),
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
