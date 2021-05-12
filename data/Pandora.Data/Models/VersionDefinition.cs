using System.Collections.Generic;

namespace Pandora.Data.Models
{
    public class VersionDefinition
    {
        public string Version { get; set; }

        public bool Generate { get; set; }
        
        public bool Preview { get; set; }
        
        public List<ApiDefinition> Apis { get; set; }
    }
}