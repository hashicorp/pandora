using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2022_10_01.JobDetails;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MabServerTypeConstant
{
    [Description("AzureBackupServerContainer")]
    AzureBackupServerContainer,

    [Description("AzureSqlContainer")]
    AzureSqlContainer,

    [Description("Cluster")]
    Cluster,

    [Description("DPMContainer")]
    DPMContainer,

    [Description("GenericContainer")]
    GenericContainer,

    [Description("IaasVMContainer")]
    IaasVMContainer,

    [Description("IaasVMServiceContainer")]
    IaasVMServiceContainer,

    [Description("Invalid")]
    Invalid,

    [Description("MABContainer")]
    MABContainer,

    [Description("SQLAGWorkLoadContainer")]
    SQLAGWorkLoadContainer,

    [Description("StorageContainer")]
    StorageContainer,

    [Description("Unknown")]
    Unknown,

    [Description("VCenter")]
    VCenter,

    [Description("VMAppContainer")]
    VMAppContainer,

    [Description("Windows")]
    Windows,
}
