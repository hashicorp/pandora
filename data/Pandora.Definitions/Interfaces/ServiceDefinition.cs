using System.Collections.Generic;

namespace Pandora.Definitions.Interfaces
{
    public interface ServiceDefinition
    {
        public string Name { get; }
        public bool Generate { get; }
        public string? ResourceProvider { get; }

        public IEnumerable<TerraformResourceDefinition> Resources { get; }
        public IEnumerable<ApiVersionDefinition> Versions { get; }
    }
}