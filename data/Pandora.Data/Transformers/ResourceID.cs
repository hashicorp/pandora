using Pandora.Data.Models;

namespace Pandora.Data.Transformers
{
    public static class ResourceID
    {
        public static ResourceIdDefinition Map(Definitions.Interfaces.ResourceID input)
        {
            return new ResourceIdDefinition
            {
                Name = input.GetType().Name,
                Format = input.ID(),
            };
        }
    }
}