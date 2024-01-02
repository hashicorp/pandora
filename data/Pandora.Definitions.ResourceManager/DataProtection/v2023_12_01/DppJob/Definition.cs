using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataProtection.v2023_12_01.DppJob;

internal class Definition : ResourceDefinition
{
    public string Name => "DppJob";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new FetchCrossRegionRestoreJobGetOperation(),
        new FetchCrossRegionRestoreJobsListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AzureBackupJobModel),
        typeof(AzureBackupJobResourceModel),
        typeof(CrossRegionRestoreJobRequestModel),
        typeof(CrossRegionRestoreJobsRequestModel),
        typeof(InnerErrorModel),
        typeof(JobExtendedInfoModel),
        typeof(JobSubTaskModel),
        typeof(RestoreJobRecoveryPointDetailsModel),
        typeof(UserFacingErrorModel),
        typeof(UserFacingWarningDetailModel),
    };
}
