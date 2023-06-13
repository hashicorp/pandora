using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Sql.v2018_06_01_preview.LocationCapabilities;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum PauseDelayTimeUnitConstant
{
    [Description("Minutes")]
    Minutes,
}
