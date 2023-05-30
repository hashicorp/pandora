using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.ChangeDataCapture;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum FrequencyTypeConstant
{
    [Description("Hour")]
    Hour,

    [Description("Minute")]
    Minute,

    [Description("Second")]
    Second,
}
