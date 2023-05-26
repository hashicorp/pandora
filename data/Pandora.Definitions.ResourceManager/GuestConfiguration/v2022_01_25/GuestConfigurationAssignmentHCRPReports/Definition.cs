using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.GuestConfiguration.v2022_01_25.GuestConfigurationAssignmentHCRPReports;

internal class Definition : ResourceDefinition
{
    public string Name => "GuestConfigurationAssignmentHCRPReports";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GuestConfigurationHCRPAssignmentReportsGetOperation(),
        new GuestConfigurationHCRPAssignmentReportsListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ComplianceStatusConstant),
        typeof(TypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AssignmentInfoModel),
        typeof(AssignmentReportDetailsModel),
        typeof(AssignmentReportResourceModel),
        typeof(AssignmentReportResourceComplianceReasonModel),
        typeof(ConfigurationInfoModel),
        typeof(GuestConfigurationAssignmentReportModel),
        typeof(GuestConfigurationAssignmentReportListModel),
        typeof(GuestConfigurationAssignmentReportPropertiesModel),
        typeof(VMInfoModel),
    };
}
