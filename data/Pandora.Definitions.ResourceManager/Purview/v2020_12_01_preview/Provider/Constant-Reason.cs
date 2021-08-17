using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Purview.v2020_12_01_preview.Provider
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
