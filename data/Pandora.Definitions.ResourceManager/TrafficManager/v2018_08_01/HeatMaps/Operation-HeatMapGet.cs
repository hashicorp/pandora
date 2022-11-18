using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.TrafficManager.v2018_08_01.HeatMaps;

internal class HeatMapGetOperation : Operations.GetOperation
{
\t\tpublic override ResourceID? ResourceId() => new TrafficManagerProfileId();

\t\tpublic override Type? ResponseObject() => typeof(HeatMapModelModel);

\t\tpublic override Type? OptionsObject() => typeof(HeatMapGetOperation.HeatMapGetOptions);

\t\tpublic override string? UriSuffix() => "/heatMaps/default";

    internal class HeatMapGetOptions
    {
        [QueryStringName("botRight")]
        [Optional]
        public Csv<float> BotRight { get; set; }

        [QueryStringName("topLeft")]
        [Optional]
        public Csv<float> TopLeft { get; set; }
    }
}
