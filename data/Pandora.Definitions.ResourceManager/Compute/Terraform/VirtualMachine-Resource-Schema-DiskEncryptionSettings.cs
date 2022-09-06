using System.Collections.Generic;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CommonSchema;

namespace Pandora.Definitions.ResourceManager.Compute.Terraform;

public class VirtualMachineResourceDiskEncryptionSettingsSchema
{

    [HclName("disk_encryption_key")]
    [Optional]
    public VirtualMachineResourceKeyVaultSecretReferenceSchema DiskEncryptionKey { get; set; }


    [HclName("key_encryption_key")]
    [Optional]
    public VirtualMachineResourceKeyVaultKeyReferenceSchema KeyEncryptionKey { get; set; }


    [HclName("d_enabled")]
    [Optional]
    public bool dEnabled { get; set; }

}
