using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataMigration.v2018_04_19.CustomOperation;

internal class Definition : ResourceDefinition
{
    public string Name => "CustomOperation";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ServicesCheckStatusOperation(),
        new ServicesNestedCheckNameAvailabilityOperation(),
        new ServicesStartOperation(),
        new ServicesStopOperation(),
        new TasksCancelOperation(),
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
        typeof(NameAvailabilityRequestModel),
        typeof(NameAvailabilityResponseModel),
        typeof(ODataErrorModel),
        typeof(ProjectTaskModel),
        typeof(ProjectTaskPropertiesModel),
    };
}
