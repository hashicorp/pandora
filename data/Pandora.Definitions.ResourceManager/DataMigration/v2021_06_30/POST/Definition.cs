using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataMigration.v2021_06_30.POST;

internal class Definition : ResourceDefinition
{
    public string Name => "POST";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new FilesReadOperation(),
        new FilesReadWriteOperation(),
        new ServiceTasksCancelOperation(),
        new ServicesCheckChildrenNameAvailabilityOperation(),
        new ServicesCheckNameAvailabilityOperation(),
        new ServicesCheckStatusOperation(),
        new ServicesStartOperation(),
        new ServicesStopOperation(),
        new TasksCancelOperation(),
        new TasksCommandOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(CommandStateConstant),
        typeof(NameCheckFailureReasonConstant),
        typeof(TaskStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CommandPropertiesModel),
        typeof(DataMigrationServiceStatusResponseModel),
        typeof(FileStorageInfoModel),
        typeof(NameAvailabilityRequestModel),
        typeof(NameAvailabilityResponseModel),
        typeof(ODataErrorModel),
        typeof(ProjectTaskModel),
        typeof(ProjectTaskPropertiesModel),
    };
}
