using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2021_07_01.Workspaces;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum EncryptionStatusConstant
{
    [Description("Disabled")]
    Disabled,

    [Description("Enabled")]
    Enabled,
}
