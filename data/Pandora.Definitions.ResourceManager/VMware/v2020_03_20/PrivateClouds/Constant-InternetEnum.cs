using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.VMware.v2020_03_20.PrivateClouds
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum InternetEnum
    {
        [Description("Disabled")]
        Disabled,

        [Description("Enabled")]
        Enabled,
    }
}
