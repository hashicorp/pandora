// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Domains.Beta.Domain;

internal class Definition : ResourceDefinition
{
    public string Name => "Domain";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateDomainByIdForceDeleteOperation(),
        new CreateDomainByIdPromoteOperation(),
        new CreateDomainByIdPromoteToInitialOperation(),
        new CreateDomainByIdVerifyOperation(),
        new CreateDomainOperation(),
        new DeleteDomainByIdOperation(),
        new GetDomainByIdOperation(),
        new GetDomainCountOperation(),
        new ListDomainsOperation(),
        new UpdateDomainByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CreateDomainByIdForceDeleteRequestModel)
    };
}
