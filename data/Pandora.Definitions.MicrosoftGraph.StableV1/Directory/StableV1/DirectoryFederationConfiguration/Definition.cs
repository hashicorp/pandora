// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.StableV1.CommonTypes;
using System;

namespace Pandora.Definitions.MicrosoftGraph.StableV1.Directory.StableV1.DirectoryFederationConfiguration;

internal class Definition : ResourceDefinition
{
    public string Name => "DirectoryFederationConfiguration";

    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateDirectoryFederationConfigurationOperation(),
        new DeleteDirectoryFederationConfigurationByIdOperation(),
        new GetDirectoryFederationConfigurationByIdOperation(),
        new GetDirectoryFederationConfigurationCountOperation(),
        new ListDirectoryFederationConfigurationsOperation(),
        new UpdateDirectoryFederationConfigurationByIdOperation()
    };

    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };

    public IEnumerable<System.Type> Models => new List<System.Type>
    {

    };
}
