// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Data.Models;
using Pandora.Definitions.DataPlane;
using Pandora.Definitions.HandDefined;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.MicrosoftGraph.Beta;
using Pandora.Definitions.MicrosoftGraph.StableV1;
using Pandora.Definitions.ResourceManager;
using ServiceDefinition = Pandora.Definitions.Interfaces.ServiceDefinition;

namespace Pandora.Data;

public static class DefinitionTypes
{
    public static Dictionary<ServiceDefinitionType, List<ServicesDefinition>> Get()
    {
        return new Dictionary<ServiceDefinitionType, List<ServicesDefinition>>
        {
            {
                ServiceDefinitionType.DataPlane,
                new List<ServicesDefinition>
                {
                    new DataPlaneServices(),
                }
            },
            {
                ServiceDefinitionType.MicrosoftGraphBeta,
                new List<ServicesDefinition>
                {
                    new MicrosoftGraphBetaServices(),
                }
            },
            {
                ServiceDefinitionType.MicrosoftGraphStableV1,
                new List<ServicesDefinition>
                {
                    new MicrosoftGraphStableV1Services(),
                }
            },
            {
                ServiceDefinitionType.ResourceManager,
                new List<ServicesDefinition>
                {
                    new HandDefinedServices(),
                    new ResourceManagerServices(),
                }
            },
        };
    }
}
