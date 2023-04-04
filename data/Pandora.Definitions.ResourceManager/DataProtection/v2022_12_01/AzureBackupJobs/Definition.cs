using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataProtection.v2022_12_01.AzureBackupJobs;

internal class Definition : ResourceDefinition
{
    public string Name => "AzureBackupJobs";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new JobsListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AzureBackupJobModel),
        typeof(AzureBackupJobResourceModel),
        typeof(InnerErrorModel),
        typeof(JobExtendedInfoModel),
        typeof(JobSubTaskModel),
        typeof(RestoreJobRecoveryPointDetailsModel),
        typeof(UserFacingErrorModel),
    };
}
