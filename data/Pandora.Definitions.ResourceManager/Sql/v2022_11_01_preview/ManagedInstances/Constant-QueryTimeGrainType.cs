using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.ManagedInstances;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum QueryTimeGrainTypeConstant
{
    [Description("P1D")]
    POneD,

    [Description("PT1H")]
    PTOneH,
}
