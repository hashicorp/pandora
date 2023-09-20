// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Users.Beta.UserCloudPC;

internal class Definition : ResourceDefinition
{
    public string Name => "UserCloudPC";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateUserByIdCloudPCBulkResizeOperation(),
        new CreateUserByIdCloudPCByIdChangeUserAccountTypeOperation(),
        new CreateUserByIdCloudPCByIdCreateSnapshotOperation(),
        new CreateUserByIdCloudPCByIdEndGracePeriodOperation(),
        new CreateUserByIdCloudPCByIdPowerOffOperation(),
        new CreateUserByIdCloudPCByIdPowerOnOperation(),
        new CreateUserByIdCloudPCByIdRebootOperation(),
        new CreateUserByIdCloudPCByIdRenameOperation(),
        new CreateUserByIdCloudPCByIdReprovisionOperation(),
        new CreateUserByIdCloudPCByIdResizeOperation(),
        new CreateUserByIdCloudPCByIdRetryPartnerAgentInstallationOperation(),
        new CreateUserByIdCloudPCByIdTroubleshootOperation(),
        new CreateUserByIdCloudPCOperation(),
        new DeleteUserByIdCloudPCByIdOperation(),
        new GetUserByIdCloudPCByIdOperation(),
        new GetUserByIdCloudPCCountOperation(),
        new ListUserByIdCloudPCsOperation(),
        new RestoreUserByIdCloudPCByIdOperation(),
        new StartUserByIdCloudPCByIdOperation(),
        new StopUserByIdCloudPCByIdOperation(),
        new UpdateUserByIdCloudPCByIdOperation(),
        new ValidateUserByIdCloudPCsBulkResizeOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CreateUserByIdCloudPCByIdChangeUserAccountTypeRequestUserAccountTypeConstant),
        typeof(CreateUserByIdCloudPCByIdReprovisionRequestOsVersionConstant),
        typeof(CreateUserByIdCloudPCByIdReprovisionRequestUserAccountTypeConstant)
    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateUserByIdCloudPCBulkResizeRequestModel),
        typeof(CreateUserByIdCloudPCByIdChangeUserAccountTypeRequestModel),
        typeof(CreateUserByIdCloudPCByIdRenameRequestModel),
        typeof(CreateUserByIdCloudPCByIdReprovisionRequestModel),
        typeof(CreateUserByIdCloudPCByIdResizeRequestModel),
        typeof(RestoreUserByIdCloudPCByIdRequestModel),
        typeof(ValidateUserByIdCloudPCsBulkResizeRequestModel)
    };
}
