using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_01_01_preview.AuthorizationRulesEventHubs
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum KeyType
    {
        [Description("PrimaryKey")]
        PrimaryKey,

        [Description("SecondaryKey")]
        SecondaryKey,
    }
}
