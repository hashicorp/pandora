using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.KubeEnvironments;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum StorageTypeConstant
{
    [Description("LocalNode")]
    LocalNode,

    [Description("NetworkFileSystem")]
    NetworkFileSystem,
}
