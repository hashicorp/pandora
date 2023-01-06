using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.RecoveryServicesBackup.v2021_12_01.ProtectableContainers;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ContainerTypeConstant
{
    [Description("AzureBackupServerContainer")]
    AzureBackupServerContainer,

    [Description("AzureSqlContainer")]
    AzureSqlContainer,

    [Description("AzureWorkloadContainer")]
    AzureWorkloadContainer,

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

    [Description("Microsoft.ClassicCompute/virtualMachines")]
    MicrosoftPointClassicComputeVirtualMachines,

    [Description("Microsoft.Compute/virtualMachines")]
    MicrosoftPointComputeVirtualMachines,

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
