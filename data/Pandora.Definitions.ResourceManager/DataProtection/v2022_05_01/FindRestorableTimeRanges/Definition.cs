using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataProtection.v2022_05_01.FindRestorableTimeRanges;

internal class Definition : ResourceDefinition
{
    public string Name => "FindRestorableTimeRanges";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new RestorableTimeRangesFindOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(RestoreSourceDataStoreTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AzureBackupFindRestorableTimeRangesRequestModel),
        typeof(AzureBackupFindRestorableTimeRangesResponseModel),
        typeof(AzureBackupFindRestorableTimeRangesResponseResourceModel),
        typeof(RestorableTimeRangeModel),
    };
}
