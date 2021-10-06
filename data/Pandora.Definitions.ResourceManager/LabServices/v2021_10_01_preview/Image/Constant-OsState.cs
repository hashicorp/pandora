using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.LabServices.v2021_10_01_preview.Image
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum OsStateConstant
    {
        [Description("Generalized")]
        Generalized,

        [Description("Specialized")]
        Specialized,
    }
}
