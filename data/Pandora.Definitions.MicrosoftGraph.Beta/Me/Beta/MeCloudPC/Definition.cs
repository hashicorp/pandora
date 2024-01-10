// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Me.Beta.MeCloudPC;

internal class Definition : ResourceDefinition
{
    public string Name => "MeCloudPC";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateMeCloudPCBulkResizeOperation(),
        new CreateMeCloudPCByIdChangeUserAccountTypeOperation(),
        new CreateMeCloudPCByIdCreateSnapshotOperation(),
        new CreateMeCloudPCByIdEndGracePeriodOperation(),
        new CreateMeCloudPCByIdPowerOffOperation(),
        new CreateMeCloudPCByIdPowerOnOperation(),
        new CreateMeCloudPCByIdRebootOperation(),
        new CreateMeCloudPCByIdRenameOperation(),
        new CreateMeCloudPCByIdReprovisionOperation(),
        new CreateMeCloudPCByIdResizeOperation(),
        new CreateMeCloudPCByIdRetryPartnerAgentInstallationOperation(),
        new CreateMeCloudPCByIdTroubleshootOperation(),
        new CreateMeCloudPCOperation(),
        new DeleteMeCloudPCByIdOperation(),
        new GetMeCloudPCByIdOperation(),
        new GetMeCloudPCCountOperation(),
        new ListMeCloudPCsOperation(),
        new RestoreMeCloudPCByIdOperation(),
        new StartMeCloudPCByIdOperation(),
        new StopMeCloudPCByIdOperation(),
        new UpdateMeCloudPCByIdOperation(),
        new ValidateMeCloudPCsBulkResizeOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CreateMeCloudPCByIdChangeUserAccountTypeRequestUserAccountTypeConstant),
        typeof(CreateMeCloudPCByIdReprovisionRequestOsVersionConstant),
        typeof(CreateMeCloudPCByIdReprovisionRequestUserAccountTypeConstant)
    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateMeCloudPCBulkResizeRequestModel),
        typeof(CreateMeCloudPCByIdChangeUserAccountTypeRequestModel),
        typeof(CreateMeCloudPCByIdRenameRequestModel),
        typeof(CreateMeCloudPCByIdReprovisionRequestModel),
        typeof(CreateMeCloudPCByIdResizeRequestModel),
        typeof(RestoreMeCloudPCByIdRequestModel),
        typeof(ValidateMeCloudPCsBulkResizeRequestModel)
    };
}
