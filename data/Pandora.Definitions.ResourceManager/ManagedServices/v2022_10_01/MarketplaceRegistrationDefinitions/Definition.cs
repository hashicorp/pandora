using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ManagedServices.v2022_10_01.MarketplaceRegistrationDefinitions;

internal class Definition : ResourceDefinition
{
    public string Name => "MarketplaceRegistrationDefinitions";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new ListOperation(),
        new WithoutScopeGetOperation(),
        new WithoutScopeListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(MultiFactorAuthProviderConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AuthorizationModel),
        typeof(EligibleApproverModel),
        typeof(EligibleAuthorizationModel),
        typeof(JustInTimeAccessPolicyModel),
        typeof(MarketplaceRegistrationDefinitionModel),
        typeof(MarketplaceRegistrationDefinitionPropertiesModel),
        typeof(PlanModel),
    };
}
