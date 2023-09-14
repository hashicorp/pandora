using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.ImportSitesController;

internal class Definition : ResourceDefinition
{
    public string Name => "ImportSitesController";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new DeleteImportedMachinesOperation(),
        new ExportUriOperation(),
        new GetOperation(),
        new ImportUriOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(ProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ImportSiteModel),
        typeof(ImportSitePropertiesModel),
        typeof(ImportSiteUpdateModel),
        typeof(ImportSiteUpdatePropertiesModel),
        typeof(SasUriResponseModel),
    };
}
