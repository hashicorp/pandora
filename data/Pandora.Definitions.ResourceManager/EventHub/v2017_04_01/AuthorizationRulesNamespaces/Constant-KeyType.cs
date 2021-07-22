using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventHub.v2017_04_01.AuthorizationRulesNamespaces
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
