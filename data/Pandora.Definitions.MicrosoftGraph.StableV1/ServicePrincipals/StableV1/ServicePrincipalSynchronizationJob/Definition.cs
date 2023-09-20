// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.ServicePrincipals.StableV1.ServicePrincipalSynchronizationJob;

internal class Definition : ResourceDefinition
{
    public string Name => "ServicePrincipalSynchronizationJob";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateServicePrincipalByIdSynchronizationJobOperation(),
        new DeleteServicePrincipalByIdSynchronizationJobByIdOperation(),
        new GetServicePrincipalByIdSynchronizationJobByIdOperation(),
        new GetServicePrincipalByIdSynchronizationJobCountOperation(),
        new ListServicePrincipalByIdSynchronizationJobsOperation(),
        new PauseServicePrincipalByIdSynchronizationJobByIdOperation(),
        new ProvisionServicePrincipalByIdSynchronizationJobByIdOnDemandOperation(),
        new RestartServicePrincipalByIdSynchronizationJobByIdOperation(),
        new StartServicePrincipalByIdSynchronizationJobByIdOperation(),
        new UpdateServicePrincipalByIdSynchronizationJobByIdOperation(),
        new ValidateServicePrincipalByIdSynchronizationJobByIdCredentialOperation(),
        new ValidateServicePrincipalByIdSynchronizationJobsCredentialOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ProvisionServicePrincipalByIdSynchronizationJobByIdOnDemandRequestModel),
        typeof(RestartServicePrincipalByIdSynchronizationJobByIdRequestModel),
        typeof(ValidateServicePrincipalByIdSynchronizationJobByIdCredentialRequestModel),
        typeof(ValidateServicePrincipalByIdSynchronizationJobsCredentialRequestModel)
    };
}
