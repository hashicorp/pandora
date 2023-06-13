using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2017_03_01_preview.Jobs;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum JobScheduleTypeConstant
{
    [Description("Once")]
    Once,

    [Description("Recurring")]
    Recurring,
}
