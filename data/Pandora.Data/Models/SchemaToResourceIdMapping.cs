using System.Collections.Generic;

namespace Pandora.Data.Models
{
    public class SchemaToResourceIdMapping
    {
        public string ResourceIdType { get; set; }
        public List<string> SegmentMapping { get; set; }
    }
}