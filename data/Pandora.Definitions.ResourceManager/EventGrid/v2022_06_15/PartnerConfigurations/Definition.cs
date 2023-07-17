using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.EventGrid.v2022_06_15.PartnerConfigurations;

internal class Definition : ResourceDefinition
{
    public string Name => "PartnerConfigurations";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AuthorizePartnerOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new UnauthorizePartnerOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(PartnerConfigurationProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(PartnerModel),
        typeof(PartnerAuthorizationModel),
        typeof(PartnerConfigurationModel),
        typeof(PartnerConfigurationPropertiesModel),
        typeof(PartnerConfigurationUpdateParameterPropertiesModel),
        typeof(PartnerConfigurationUpdateParametersModel),
        typeof(PartnerConfigurationsListResultModel),
    };
}
