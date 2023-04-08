using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2019_08_01.IoTSecuritySolution;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AdditionalWorkspaceDataTypeConstant
{
    [Description("Alerts")]
    Alerts,

    [Description("RawEvents")]
    RawEvents,
}
