using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.LabServices.v2021_10_01_preview.Lab
{
    [ConstantType(ConstantTypeAttribute.ConstantType.String)]
    internal enum OsTypeConstant
    {
        [Description("Linux")]
        Linux,

        [Description("Windows")]
        Windows,
    }
}
