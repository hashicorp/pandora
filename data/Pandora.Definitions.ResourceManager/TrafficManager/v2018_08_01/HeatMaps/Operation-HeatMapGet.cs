using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.TrafficManager.v2018_08_01.HeatMaps
{
    internal class HeatMapGet : GetOperation
    {
        public override ResourceID? ResourceId()
        {
            return new HeatMapId();
        }

        public override object? ResponseObject()
        {
            return new HeatMapModel();
        }

        public override object? OptionsObject()
        {
            return new HeatMapGet.HeatMapGetOptions();
        }

        internal class HeatMapGetOptions
        {
            [QueryStringName("botRight")]
            [Optional]
            public string BotRight { get; set; }
            [QueryStringName("topLeft")]
            [Optional]
            public string TopLeft { get; set; }
        }
    }
}
