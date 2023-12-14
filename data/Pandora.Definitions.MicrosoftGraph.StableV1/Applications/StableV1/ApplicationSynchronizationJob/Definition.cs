// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Applications.StableV1.ApplicationSynchronizationJob;

internal class Definition : ResourceDefinition
{
    public string Name => "ApplicationSynchronizationJob";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateApplicationByIdSynchronizationJobOperation(),
        new DeleteApplicationByIdSynchronizationJobByIdOperation(),
        new GetApplicationByIdSynchronizationJobByIdOperation(),
        new GetApplicationByIdSynchronizationJobCountOperation(),
        new ListApplicationByIdSynchronizationJobsOperation(),
        new PauseApplicationByIdSynchronizationJobByIdOperation(),
        new ProvisionApplicationByIdSynchronizationJobByIdOnDemandOperation(),
        new RestartApplicationByIdSynchronizationJobByIdOperation(),
        new StartApplicationByIdSynchronizationJobByIdOperation(),
        new UpdateApplicationByIdSynchronizationJobByIdOperation(),
        new ValidateApplicationByIdSynchronizationJobByIdCredentialOperation(),
        new ValidateApplicationByIdSynchronizationJobsCredentialOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ProvisionApplicationByIdSynchronizationJobByIdOnDemandRequestModel),
        typeof(RestartApplicationByIdSynchronizationJobByIdRequestModel),
        typeof(ValidateApplicationByIdSynchronizationJobByIdCredentialRequestModel),
        typeof(ValidateApplicationByIdSynchronizationJobsCredentialRequestModel)
    };
}
