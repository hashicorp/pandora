using System;
using System.Text.Json.Serialization;
using Pandora.Definitions.Operations;

namespace Pandora.Definitions.TestData.Pandamonium.v2020_01_01.Grouping;

public class Paged : ListOperation
{
    public override Type NestedItemType()
    {
        return typeof(Foo);
    }

    public override string? FieldContainingPaginationDetails()
    {
        return "@odata.goes-bang";
    }

    public override string? UriSuffix()
    {
        return "/list-things";
    }

    public class Foo
    {
        [JsonPropertyName("widget")]
        public string Widget { get; set; }
    }
}