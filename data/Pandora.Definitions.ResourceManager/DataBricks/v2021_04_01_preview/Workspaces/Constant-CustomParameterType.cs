using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataBricks.v2021_04_01_preview.Workspaces
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum CustomParameterTypeConstant
    {
        [Description("Bool")]
        Bool,

        [Description("Object")]
        Object,

        [Description("String")]
        String,
    }
}
