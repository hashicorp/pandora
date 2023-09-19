// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.ServicePrincipals.StableV1.ServicePrincipalSynchronizationJobSchemaDirectory;

internal class Definition : ResourceDefinition
{
    public string Name => "ServicePrincipalSynchronizationJobSchemaDirectory";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateServicePrincipalByIdSynchronizationJobByIdSchemaDirectoryOperation(),
        new DeleteServicePrincipalByIdSynchronizationJobByIdSchemaDirectoryByIdOperation(),
        new DiscoverServicePrincipalByIdSynchronizationJobByIdSchemaDirectoryByIdOperation(),
        new GetServicePrincipalByIdSynchronizationJobByIdSchemaDirectoryByIdOperation(),
        new GetServicePrincipalByIdSynchronizationJobByIdSchemaDirectoryCountOperation(),
        new ListServicePrincipalByIdSynchronizationJobByIdSchemaDirectoriesOperation(),
        new UpdateServicePrincipalByIdSynchronizationJobByIdSchemaDirectoryByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
