using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2019_06_01.SoftwareUpdateConfigurationRun;

internal class Definition : ResourceDefinition
{
    public string Name => "SoftwareUpdateConfigurationRun";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new SoftwareUpdateConfigurationRunsGetByIdOperation(),
        new SoftwareUpdateConfigurationRunsListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(SoftwareUpdateConfigurationRunModel),
        typeof(SoftwareUpdateConfigurationRunListResultModel),
        typeof(SoftwareUpdateConfigurationRunPropertiesModel),
        typeof(SoftwareUpdateConfigurationRunTaskPropertiesModel),
        typeof(SoftwareUpdateConfigurationRunTasksModel),
        typeof(UpdateConfigurationNavigationModel),
    };
}
