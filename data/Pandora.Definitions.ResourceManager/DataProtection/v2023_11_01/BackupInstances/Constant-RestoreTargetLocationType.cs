using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.DataProtection.v2023_11_01.BackupInstances;

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
