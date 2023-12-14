// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.User;

internal class Definition : ResourceDefinition
{
    public string Name => "User";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new AssignUserByIdLicenseOperation(),
        new CheckUserByIdMemberGroupOperation(),
        new CheckUserByIdMemberObjectOperation(),
        new CreateUserByIdChangePasswordOperation(),
        new CreateUserByIdDeletePasswordSingleSignOnCredentialOperation(),
        new CreateUserByIdExportPersonalDataOperation(),
        new CreateUserByIdFindMeetingTimeOperation(),
        new CreateUserByIdInvalidateAllRefreshTokenOperation(),
        new CreateUserByIdReprocessLicenseAssignmentOperation(),
        new CreateUserByIdRetryServiceProvisioningOperation(),
        new CreateUserByIdRevokeSignInSessionOperation(),
        new CreateUserByIdSendMailOperation(),
        new CreateUserByIdTranslateExchangeIdOperation(),
        new CreateUserByIdUnblockManagedAppOperation(),
        new CreateUserByIdWipeAndBlockManagedAppOperation(),
        new CreateUserByIdWipeManagedAppRegistrationByDeviceTagOperation(),
        new CreateUserByIdWipeManagedAppRegistrationsByAzureAdDeviceIdOperation(),
        new CreateUserByIdWipeManagedAppRegistrationsByDeviceTagOperation(),
        new CreateUserOperation(),
        new DeleteUserByIdOperation(),
        new GetUserByIdMailTipOperation(),
        new GetUserByIdMemberGroupOperation(),
        new GetUserByIdMemberObjectOperation(),
        new GetUserByIdOperation(),
        new GetUserByIdPasswordSingleSignOnCredentialOperation(),
        new GetUserCountOperation(),
        new GetUsersByIdsOperation(),
        new GetUsersUserOwnedObjectOperation(),
        new ListUsersOperation(),
        new RemoveUserByIdAllDevicesFromManagementOperation(),
        new RestoreUserByIdOperation(),
        new UpdateUserByIdOperation(),
        new ValidateUsersPasswordOperation(),
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
        typeof(CreateUserByIdDeletePasswordSingleSignOnCredentialRequestModel),
        typeof(CreateUserByIdExportPersonalDataRequestModel),
        typeof(CreateUserByIdFindMeetingTimeRequestModel),
        typeof(CreateUserByIdSendMailRequestModel),
        typeof(CreateUserByIdTranslateExchangeIdRequestModel),
        typeof(CreateUserByIdWipeManagedAppRegistrationByDeviceTagRequestModel),
        typeof(CreateUserByIdWipeManagedAppRegistrationsByAzureAdDeviceIdRequestModel),
        typeof(CreateUserByIdWipeManagedAppRegistrationsByDeviceTagRequestModel),
        typeof(GetUserByIdMailTipRequestModel),
        typeof(GetUserByIdMemberGroupRequestModel),
        typeof(GetUserByIdMemberObjectRequestModel),
        typeof(GetUsersByIdsRequestModel),
        typeof(GetUsersUserOwnedObjectRequestModel),
        typeof(ValidateUsersPasswordRequestModel),
        typeof(ValidateUsersPropertyRequestModel)
    };
}
