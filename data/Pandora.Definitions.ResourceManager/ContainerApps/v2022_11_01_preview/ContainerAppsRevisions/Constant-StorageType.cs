using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2022_11_01_preview.ContainerAppsRevisions;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StorageTypeConstant
{
    [Description("AzureFile")]
    AzureFile,

    [Description("EmptyDir")]
    EmptyDir,

    [Description("Secret")]
    Secret,
}
