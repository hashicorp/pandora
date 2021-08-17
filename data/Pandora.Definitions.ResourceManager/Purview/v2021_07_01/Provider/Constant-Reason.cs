using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Purview.v2021_07_01.Provider
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum ReasonConstant
    {
        [Description("AlreadyExists")]
        AlreadyExists,

        [Description("Invalid")]
        Invalid,
    }
}
