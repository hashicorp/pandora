using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.TrafficManager.v2018_08_01.HeatMaps;

internal class HeatMapGetOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new HeatMapTypeId();

    public override Type? ResponseObject() => typeof(HeatMapModelModel);

    public override Type? OptionsObject() => typeof(HeatMapGetOperation.HeatMapGetOptions);

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
