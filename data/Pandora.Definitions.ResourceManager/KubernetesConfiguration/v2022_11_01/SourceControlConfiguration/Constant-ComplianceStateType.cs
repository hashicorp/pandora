using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.KubernetesConfiguration.v2022_11_01.SourceControlConfiguration;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ComplianceStateTypeConstant
{
    [Description("Compliant")]
    Compliant,

    [Description("Failed")]
    Failed,

    [Description("Installed")]
    Installed,

    [Description("Noncompliant")]
    Noncompliant,

    [Description("Pending")]
    Pending,
}
