using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2021_08_01.PortalSettings;

internal class Definition : ResourceDefinition
{
    public string Name => "PortalSettings";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ListByServiceOperation(),
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
        typeof(PortalSettingsCollectionModel),
        typeof(PortalSettingsContractModel),
        typeof(PortalSettingsContractPropertiesModel),
        typeof(RegistrationDelegationSettingsPropertiesModel),
        typeof(SubscriptionsDelegationSettingsPropertiesModel),
        typeof(TermsOfServicePropertiesModel),
    };
}
