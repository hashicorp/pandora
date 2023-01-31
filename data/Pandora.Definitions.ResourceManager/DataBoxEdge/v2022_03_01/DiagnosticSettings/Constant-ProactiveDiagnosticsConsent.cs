using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2022_03_01.DiagnosticSettings;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ProactiveDiagnosticsConsentConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
