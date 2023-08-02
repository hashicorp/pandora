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
        new CreateSynchronizationJobOperation(),
        new DeleteSynchronizationJobOperation(),
        new GetSynchronizationJobOperation(),
        new GetSynchronizationJobsCountOperation(),
        new ListSynchronizationJobsOperation(),
        new PauseSynchronizationJobOperation(),
        new ProvisionSynchronizationJobOnDemandOperation(),
        new RestartSynchronizationJobOperation(),
        new StartSynchronizationJobOperation(),
        new UpdateSynchronizationJobOperation(),
        new ValidateSynchronizationJobCredentialsOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ProvisionSynchronizationJobOnDemandRequestModel),
        typeof(RestartSynchronizationJobRequestModel),
        typeof(ValidateSynchronizationJobCredentialsRequestModel)
    };
}
