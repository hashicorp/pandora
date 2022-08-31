using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.TrafficManager.v2018_08_01.RealUserMetrics;

internal class Definition : ResourceDefinition
{
    public string Name => "RealUserMetrics";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new TrafficManagerUserMetricsKeysCreateOrUpdateOperation(),
        new TrafficManagerUserMetricsKeysDeleteOperation(),
        new TrafficManagerUserMetricsKeysGetOperation(),
    };
}
