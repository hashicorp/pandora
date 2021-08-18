using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Operations;

namespace Pandora.Definitions.TestData.Pandamonium.v2020_01_01.Grouping
{
    public class GetListOfModelImmediate : GetOperation
    {
        public override Type? ResponseObject() => typeof(List<SomeModel>);

        public override string? UriSuffix() => "/hello";

        private class SomeModel
        {
            [JsonPropertyName("foo")]
            public string Foo { get; set; }
        }
    }
}