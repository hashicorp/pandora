using System.Collections.Generic;

namespace Pandora.Definitions.Interfaces
{
    public interface TerraformSchemaMapper
    {
        List<Mapping> GetMappings();
    }

    public class Mapping
    {
        public MappingDetails Schema { get; set; }
        public MappingDetails Object { get; set; }
    }

    public class MappingDetails
    {
        public string Model { get; set; }
        public string Field { get; set; }
    }
}