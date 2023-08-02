using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CostManagement.v2023_03_01.BenefitUtilizationSummariesAsync;

internal class Definition : ResourceDefinition
{
    public string Name => "BenefitUtilizationSummariesAsync";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GenerateBenefitUtilizationSummariesReportGenerateByBillingAccountOperation(),
        new GenerateBenefitUtilizationSummariesReportGenerateByBillingProfileOperation(),
        new GenerateBenefitUtilizationSummariesReportGenerateByReservationIdOperation(),
        new GenerateBenefitUtilizationSummariesReportGenerateByReservationOrderIdOperation(),
        new GenerateBenefitUtilizationSummariesReportGenerateBySavingsPlanIdOperation(),
        new GenerateBenefitUtilizationSummariesReportGenerateBySavingsPlanOrderIdOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(BenefitKindConstant),
        typeof(BenefitUtilizationSummaryReportSchemaConstant),
        typeof(GrainConstant),
        typeof(OperationStatusTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AsyncOperationStatusPropertiesModel),
        typeof(BenefitUtilizationSummariesOperationStatusModel),
        typeof(BenefitUtilizationSummariesRequestModel),
    };
}
