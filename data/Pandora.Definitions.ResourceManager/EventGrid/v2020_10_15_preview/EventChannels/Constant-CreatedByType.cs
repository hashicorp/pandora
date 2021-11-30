using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.EventGrid.v2020_10_15_preview.EventChannels
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum CreatedByTypeConstant
    {
        [Description("Application")]
        Application,

        [Description("Key")]
        Key,

        [Description("ManagedIdentity")]
        ManagedIdentity,

        [Description("User")]
        User,
    }
}
