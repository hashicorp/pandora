// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Users.StableV1.User;

internal class Definition : ResourceDefinition
{
    public string Name => "User";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AssignUserByIdLicenseOperation(),
        new CheckUserByIdMemberGroupOperation(),
        new CheckUserByIdMemberObjectOperation(),
        new CreateUserByIdChangePasswordOperation(),
        new CreateUserByIdExportPersonalDataOperation(),
        new CreateUserByIdFindMeetingTimeOperation(),
        new CreateUserByIdReprocessLicenseAssignmentOperation(),
        new CreateUserByIdRetryServiceProvisioningOperation(),
        new CreateUserByIdRevokeSignInSessionOperation(),
        new CreateUserByIdSendMailOperation(),
        new CreateUserByIdTranslateExchangeIdOperation(),
        new CreateUserByIdWipeManagedAppRegistrationsByDeviceTagOperation(),
        new CreateUserOperation(),
        new DeleteUserByIdOperation(),
        new GetUserByIdMailTipOperation(),
        new GetUserByIdMemberGroupOperation(),
        new GetUserByIdMemberObjectOperation(),
        new GetUserByIdOperation(),
        new GetUserCountOperation(),
        new GetUsersAvailableExtensionPropertiesOperation(),
        new GetUsersByIdsOperation(),
        new ListUsersOperation(),
        new RemoveUserByIdAllDevicesFromManagementOperation(),
        new RestoreUserByIdOperation(),
        new UpdateUserByIdOperation(),
        new ValidateUsersPropertyOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CreateUserByIdTranslateExchangeIdRequestSourceIdTypeConstant),
        typeof(CreateUserByIdTranslateExchangeIdRequestTargetIdTypeConstant),
        typeof(GetUserByIdMailTipRequestMailTipsOptionsConstant)
    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AssignUserByIdLicenseRequestModel),
        typeof(CheckUserByIdMemberGroupRequestModel),
        typeof(CheckUserByIdMemberObjectRequestModel),
        typeof(CreateUserByIdChangePasswordRequestModel),
        typeof(CreateUserByIdExportPersonalDataRequestModel),
        typeof(CreateUserByIdFindMeetingTimeRequestModel),
        typeof(CreateUserByIdSendMailRequestModel),
        typeof(CreateUserByIdTranslateExchangeIdRequestModel),
        typeof(CreateUserByIdWipeManagedAppRegistrationsByDeviceTagRequestModel),
        typeof(GetUserByIdMailTipRequestModel),
        typeof(GetUserByIdMemberGroupRequestModel),
        typeof(GetUserByIdMemberObjectRequestModel),
        typeof(GetUsersAvailableExtensionPropertiesRequestModel),
        typeof(GetUsersByIdsRequestModel),
        typeof(ValidateUsersPropertyRequestModel)
    };
}
