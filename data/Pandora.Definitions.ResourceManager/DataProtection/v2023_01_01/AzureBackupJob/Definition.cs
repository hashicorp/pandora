using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataProtection.v2023_01_01.AzureBackupJob;

internal class Definition : ResourceDefinition
{
    public string Name => "AzureBackupJob";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ExportJobsOperationResultGetOperation(),
        new ExportJobsTriggerOperation(),
        new JobsGetOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AzureBackupJobModel),
        typeof(AzureBackupJobResourceModel),
        typeof(ExportJobsResultModel),
        typeof(InnerErrorModel),
        typeof(JobExtendedInfoModel),
        typeof(JobSubTaskModel),
        typeof(RestoreJobRecoveryPointDetailsModel),
        typeof(UserFacingErrorModel),
    };
}
