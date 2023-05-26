using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.GuestConfiguration.v2022_01_25.GuestConfigurationAssignments;

internal class Definition : ResourceDefinition
{
    public string Name => "GuestConfigurationAssignments";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new RGListOperation(),
        new SubscriptionListOperation(),
        new VMSSCreateOrUpdateOperation(),
        new VMSSDeleteOperation(),
        new VMSSGetOperation(),
        new VMSSListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ActionAfterRebootConstant),
        typeof(AssignmentTypeConstant),
        typeof(ComplianceStatusConstant),
        typeof(ConfigurationModeConstant),
        typeof(KindConstant),
        typeof(ProvisioningStateConstant),
        typeof(TypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AssignmentInfoModel),
        typeof(AssignmentReportModel),
        typeof(AssignmentReportResourceModel),
        typeof(AssignmentReportResourceComplianceReasonModel),
        typeof(ConfigurationInfoModel),
        typeof(ConfigurationParameterModel),
        typeof(ConfigurationSettingModel),
        typeof(GuestConfigurationAssignmentModel),
        typeof(GuestConfigurationAssignmentListModel),
        typeof(GuestConfigurationAssignmentPropertiesModel),
        typeof(GuestConfigurationNavigationModel),
        typeof(VMInfoModel),
        typeof(VMSSVMInfoModel),
    };
}
