using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ManagedApplications.v2021_07_01.ApplicationDefinitions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum DeploymentModeConstant
{
    [Description("Complete")]
    Complete,

    [Description("Incremental")]
    Incremental,

    [Description("NotSpecified")]
    NotSpecified,
}
