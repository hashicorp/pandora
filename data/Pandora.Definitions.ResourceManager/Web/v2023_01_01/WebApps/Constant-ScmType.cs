using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.WebApps;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ScmTypeConstant
{
    [Description("BitbucketGit")]
    BitbucketGit,

    [Description("BitbucketHg")]
    BitbucketHg,

    [Description("CodePlexGit")]
    CodePlexGit,

    [Description("CodePlexHg")]
    CodePlexHg,

    [Description("Dropbox")]
    Dropbox,

    [Description("ExternalGit")]
    ExternalGit,

    [Description("ExternalHg")]
    ExternalHg,

    [Description("GitHub")]
    GitHub,

    [Description("LocalGit")]
    LocalGit,

    [Description("None")]
    None,

    [Description("OneDrive")]
    OneDrive,

    [Description("Tfs")]
    Tfs,

    [Description("VSO")]
    VSO,

    [Description("VSTSRM")]
    VSTSRM,
}
