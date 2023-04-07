using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ManagedApplications.v2021_07_01.Applications;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ApplicationArtifactTypeConstant
{
    [Description("Custom")]
    Custom,

    [Description("NotSpecified")]
    NotSpecified,

    [Description("Template")]
    Template,
}
