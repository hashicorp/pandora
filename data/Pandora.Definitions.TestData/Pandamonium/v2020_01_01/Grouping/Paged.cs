using System.Text.Json.Serialization;
using Pandora.Definitions.Operations;

namespace Pandora.Definitions.TestData.Pandamonium.v2020_01_01.Grouping
{
    public class Paged : ListOperation
    {
        public override object NestedItemType()
        {
            return new Foo();
        }

        public override string? FieldContainingPaginationDetails()
        {
            return "@odata.goes-bang";
        }

        public class Foo
        {
            [JsonPropertyName("widget")]
            public string Widget { get; set; }

            [JsonPropertyName("@odata.goes-bang")]
            public string ODataFunTime { get; set; }
        }
    }
}