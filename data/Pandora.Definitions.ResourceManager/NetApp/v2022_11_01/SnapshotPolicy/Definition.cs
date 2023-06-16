using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.NetApp.v2022_11_01.SnapshotPolicy;

internal class Definition : ResourceDefinition
{
    public string Name => "SnapshotPolicy";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new SnapshotPoliciesCreateOperation(),
        new SnapshotPoliciesDeleteOperation(),
        new SnapshotPoliciesGetOperation(),
        new SnapshotPoliciesListOperation(),
        new SnapshotPoliciesUpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(DailyScheduleModel),
        typeof(HourlyScheduleModel),
        typeof(MonthlyScheduleModel),
        typeof(SnapshotPoliciesListModel),
        typeof(SnapshotPolicyModel),
        typeof(SnapshotPolicyPatchModel),
        typeof(SnapshotPolicyPropertiesModel),
        typeof(WeeklyScheduleModel),
    };
}
