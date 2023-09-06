using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2019_06_01.SoftwareUpdateConfiguration;

internal class Definition : ResourceDefinition
{
    public string Name => "SoftwareUpdateConfiguration";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new sCreateOperation(),
        new sDeleteOperation(),
        new sGetByNameOperation(),
        new sListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(LinuxUpdateClassesConstant),
        typeof(OperatingSystemTypeConstant),
        typeof(ScheduleDayConstant),
        typeof(ScheduleFrequencyConstant),
        typeof(TagOperatorsConstant),
        typeof(WindowsUpdateClassesConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AdvancedScheduleModel),
        typeof(AdvancedScheduleMonthlyOccurrenceModel),
        typeof(AzureQueryPropertiesModel),
        typeof(ErrorResponseModel),
        typeof(LinuxPropertiesModel),
        typeof(NonAzureQueryPropertiesModel),
        typeof(SUCSchedulePropertiesModel),
        typeof(SoftwareUpdateConfigurationModel),
        typeof(SoftwareUpdateConfigurationCollectionItemModel),
        typeof(SoftwareUpdateConfigurationCollectionItemPropertiesModel),
        typeof(SoftwareUpdateConfigurationListResultModel),
        typeof(SoftwareUpdateConfigurationPropertiesModel),
        typeof(SoftwareUpdateConfigurationTasksModel),
        typeof(TagSettingsPropertiesModel),
        typeof(TargetPropertiesModel),
        typeof(TaskPropertiesModel),
        typeof(UpdateConfigurationModel),
        typeof(WindowsPropertiesModel),
    };
}
