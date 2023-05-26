using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2022_11_01_preview.Jobs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum JobScheduleTypeConstant
{
    [Description("Once")]
    Once,

    [Description("Recurring")]
    Recurring,
}
