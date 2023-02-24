using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.IntegrationRuntimeObjectMetadata;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SsisObjectMetadataTypeConstant
{
    [Description("Environment")]
    Environment,

    [Description("Folder")]
    Folder,

    [Description("Package")]
    Package,

    [Description("Project")]
    Project,
}
