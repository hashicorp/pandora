// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.ServicePrincipals.StableV1.ServicePrincipalSynchronizationTemplateSchemaDirectory;

internal class Definition : ResourceDefinition
{
    public string Name => "ServicePrincipalSynchronizationTemplateSchemaDirectory";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateServicePrincipalByIdSynchronizationTemplateByIdSchemaDirectoryOperation(),
        new DeleteServicePrincipalByIdSynchronizationTemplateByIdSchemaDirectoryByIdOperation(),
        new DiscoverServicePrincipalByIdSynchronizationTemplateByIdSchemaDirectoryByIdOperation(),
        new GetServicePrincipalByIdSynchronizationTemplateByIdSchemaDirectoryByIdOperation(),
        new GetServicePrincipalByIdSynchronizationTemplateByIdSchemaDirectoryCountOperation(),
        new ListServicePrincipalByIdSynchronizationTemplateByIdSchemaDirectoriesOperation(),
        new UpdateServicePrincipalByIdSynchronizationTemplateByIdSchemaDirectoryByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
