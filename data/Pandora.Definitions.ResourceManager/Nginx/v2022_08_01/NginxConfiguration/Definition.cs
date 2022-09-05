using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Nginx.v2022_08_01.NginxConfiguration;

internal class Definition : ResourceDefinition
{
    public string Name => "NginxConfiguration";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ConfigurationsCreateOrUpdateOperation(),
        new ConfigurationsDeleteOperation(),
        new ConfigurationsGetOperation(),
        new ConfigurationsListOperation(),
    };
}
