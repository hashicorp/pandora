using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataProtection.v2022_05_01.BackupInstances;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum RestoreTargetLocationTypeConstant
{
    [Description("AzureBlobs")]
    AzureBlobs,

    [Description("AzureFiles")]
    AzureFiles,

    [Description("Invalid")]
    Invalid,
}
