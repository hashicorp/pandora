using System.Collections.Generic;

namespace Pandora.Data.Models
{
    public class OperationDefinition
    {
        public string Name { get; set; }
        public string? ContentType { get; set; }
        public List<int> ExpectedStatusCodes { get; set; }
        public string? FieldContainingPaginationDetails { get; set; }
        public bool LongRunning { get; set; }
        public string Method { get; set; }
        public List<OptionDefinition> Options { get; set; }
        public ObjectDefinition? RequestObject { get; set; }
        public ObjectDefinition? ResponseObject { get; set; }
        public string? ResourceIdName { get; set; }
        public string? UriSuffix { get; set; }
    }
}