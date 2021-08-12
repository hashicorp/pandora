using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.CustomProviders.v2018_09_01_preview.Associations
{
    internal class AssociationId : ResourceID
    {
        public string ID() => "/{scope}/providers/Microsoft.CustomProviders/associations/{associationName}";
    }
}
