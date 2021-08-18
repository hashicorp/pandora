using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Operations;

namespace Pandora.Definitions.TestData.Pandamonium.v2020_01_01.Grouping
{
    public class PagedListOfStringsImmediate : ListOperation
    {
        public override Type NestedItemType()
        {
            return typeof(List<string>);
        }

        public override string? FieldContainingPaginationDetails()
        {
            return "@odata.goes-bang";
        }

        public override string? UriSuffix()
        {
            return "/list-things";
        }
    }
}