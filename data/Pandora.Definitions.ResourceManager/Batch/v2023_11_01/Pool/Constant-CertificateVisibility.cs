using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Batch.v2023_11_01.Pool;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum CertificateVisibilityConstant
{
    [Description("RemoteUser")]
    RemoteUser,

    [Description("StartTask")]
    StartTask,

    [Description("Task")]
    Task,
}
