// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.DataProtection.v2023_11_01;

public partial class Definition : ApiVersionDefinition
{
    public string ApiVersion => "2023-11-01";
    public bool Preview => false;
    public Source Source => Source.ResourceManagerRestApiSpecs;

    public IEnumerable<ResourceDefinition> Resources => new List<ResourceDefinition>
    {
        new AzureBackupJob.Definition(),
        new AzureBackupJobs.Definition(),
        new BackupInstances.Definition(),
        new BackupPolicies.Definition(),
        new BackupVaults.Definition(),
        new DeletedBackupInstances.Definition(),
        new DppFeatureSupport.Definition(),
        new DppJob.Definition(),
        new DppResourceGuardProxies.Definition(),
        new FetchSecondaryRecoveryPoints.Definition(),
        new FindRestorableTimeRanges.Definition(),
        new RecoveryPoint.Definition(),
        new ResourceGuards.Definition(),
    };
}
