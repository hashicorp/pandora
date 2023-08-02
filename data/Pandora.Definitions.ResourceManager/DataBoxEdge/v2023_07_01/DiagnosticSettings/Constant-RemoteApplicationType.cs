using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2023_07_01.DiagnosticSettings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RemoteApplicationTypeConstant
{
    [Description("AllApplications")]
    AllApplications,

    [Description("LocalUI")]
    LocalUI,

    [Description("Powershell")]
    Powershell,

    [Description("WAC")]
    WAC,
}
