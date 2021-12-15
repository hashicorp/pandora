using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Purview.v2021_07_01.Account
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum TypeConstant
    {
        [Description("None")]
        None,

        [Description("SystemAssigned")]
        SystemAssigned,

        [Description("UserAssigned")]
        UserAssigned,
    }
}
