using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.IisWebApplicationsController;

internal class Definition : ResourceDefinition
{
    public string Name => "IisWebApplicationsController";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new ListByWebAppSiteOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(HealthErrorDetailsDiscoveryScopeConstant),
        typeof(HealthErrorDetailsSourceConstant),
        typeof(ProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(DirectoryPathModel),
        typeof(FrontEndBindingModel),
        typeof(HealthErrorDetailsModel),
        typeof(IisApplicationUnitModel),
        typeof(IisVirtualApplicationUnitModel),
        typeof(IisWebApplicationPropertiesModel),
        typeof(IisWebApplicationsModel),
        typeof(IisWebApplicationsUpdateModel),
        typeof(IisWebApplicationsUpdatePropertiesModel),
        typeof(WebApplicationConfigurationUnitModel),
        typeof(WebApplicationDirectoryUnitModel),
        typeof(WebApplicationFrameworkModel),
    };
}
