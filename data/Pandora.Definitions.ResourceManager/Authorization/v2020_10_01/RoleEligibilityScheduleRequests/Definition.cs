using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Authorization.v2020_10_01.RoleEligibilityScheduleRequests;

internal class Definition : ResourceDefinition
{
    public string Name => "RoleEligibilityScheduleRequests";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CancelOperation(),
        new CreateOperation(),
        new GetOperation(),
        new ListForScopeOperation(),
        new ValidateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(PrincipalTypeConstant),
        typeof(RequestTypeConstant),
        typeof(StatusConstant),
        typeof(TypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ExpandedPropertiesModel),
        typeof(ExpandedPropertiesPrincipalModel),
        typeof(ExpandedPropertiesRoleDefinitionModel),
        typeof(ExpandedPropertiesScopeModel),
        typeof(RoleEligibilityScheduleRequestModel),
        typeof(RoleEligibilityScheduleRequestPropertiesModel),
        typeof(RoleEligibilityScheduleRequestPropertiesScheduleInfoModel),
        typeof(RoleEligibilityScheduleRequestPropertiesScheduleInfoExpirationModel),
        typeof(RoleEligibilityScheduleRequestPropertiesTicketInfoModel),
    };
}
