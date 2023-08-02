using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerApps.v2023_05_01.ContainerAppsRevisions;

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
