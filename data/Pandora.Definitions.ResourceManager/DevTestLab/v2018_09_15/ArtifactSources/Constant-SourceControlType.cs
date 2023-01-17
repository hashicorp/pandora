using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DevTestLab.v2018_09_15.ArtifactSources;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum SourceControlTypeConstant
{
    [Description("GitHub")]
    GitHub,

    [Description("StorageAccount")]
    StorageAccount,

    [Description("VsoGit")]
    VsoGit,
}
