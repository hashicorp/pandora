using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CostManagement.v2022_10_01.ReservedInstances;

internal class Definition : ResourceDefinition
{
    public string Name => "ReservedInstances";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GenerateReservationDetailsReportByBillingAccountIdOperation(),
        new GenerateReservationDetailsReportByBillingProfileIdOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(OperationStatusTypeConstant),
        typeof(ReservationReportSchemaConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(OperationStatusModel),
        typeof(ReportURLModel),
    };
}
