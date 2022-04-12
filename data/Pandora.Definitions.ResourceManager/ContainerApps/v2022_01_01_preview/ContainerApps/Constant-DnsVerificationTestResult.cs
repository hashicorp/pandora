using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_01_01_preview.ContainerApps;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DnsVerificationTestResultConstant
{
    [Description("Failed")]
    Failed,

    [Description("Passed")]
    Passed,

    [Description("Skipped")]
    Skipped,
}
