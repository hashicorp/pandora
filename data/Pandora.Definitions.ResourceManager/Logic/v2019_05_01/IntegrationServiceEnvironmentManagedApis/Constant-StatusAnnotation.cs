using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Logic.v2019_05_01.IntegrationServiceEnvironmentManagedApis;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StatusAnnotationConstant
{
    [Description("NotSpecified")]
    NotSpecified,

    [Description("Preview")]
    Preview,

    [Description("Production")]
    Production,
}
