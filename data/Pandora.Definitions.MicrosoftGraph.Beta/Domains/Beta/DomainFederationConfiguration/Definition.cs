// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.Beta.Domains.Beta.DomainFederationConfiguration;

internal class Definition : ResourceDefinition
{
    public string Name => "DomainFederationConfiguration";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateDomainByIdFederationConfigurationOperation(),
        new DeleteDomainByIdFederationConfigurationByIdOperation(),
        new GetDomainByIdFederationConfigurationByIdOperation(),
        new GetDomainByIdFederationConfigurationCountOperation(),
        new ListDomainByIdFederationConfigurationsOperation(),
        new UpdateDomainByIdFederationConfigurationByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
