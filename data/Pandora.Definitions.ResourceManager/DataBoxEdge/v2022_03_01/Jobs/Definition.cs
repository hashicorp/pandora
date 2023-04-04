using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2022_03_01.Jobs;

internal class Definition : ResourceDefinition
{
    public string Name => "Jobs";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DownloadPhaseConstant),
        typeof(JobStatusConstant),
        typeof(JobTypeConstant),
        typeof(UpdateOperationStageConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(JobModel),
        typeof(JobErrorDetailsModel),
        typeof(JobErrorItemModel),
        typeof(JobPropertiesModel),
        typeof(UpdateDownloadProgressModel),
        typeof(UpdateInstallProgressModel),
    };
}
