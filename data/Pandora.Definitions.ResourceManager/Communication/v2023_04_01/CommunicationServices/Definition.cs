using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Communication.v2023_04_01.CommunicationServices;

internal class Definition : ResourceDefinition
{
    public string Name => "CommunicationServices";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckNameAvailabilityOperation(),
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new LinkNotificationHubOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new ListKeysOperation(),
        new RegenerateKeyOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CheckNameAvailabilityReasonConstant),
        typeof(CommunicationServicesProvisioningStateConstant),
        typeof(KeyTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CheckNameAvailabilityRequestModel),
        typeof(CheckNameAvailabilityResponseModel),
        typeof(CommunicationServiceKeysModel),
        typeof(CommunicationServicePropertiesModel),
        typeof(CommunicationServiceResourceModel),
        typeof(CommunicationServiceResourceUpdateModel),
        typeof(CommunicationServiceUpdatePropertiesModel),
        typeof(LinkNotificationHubParametersModel),
        typeof(LinkedNotificationHubModel),
        typeof(RegenerateKeyParametersModel),
    };
}
