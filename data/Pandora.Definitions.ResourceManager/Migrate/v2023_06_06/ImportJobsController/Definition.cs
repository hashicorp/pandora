using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2023_06_06.ImportJobsController;

internal class Definition : ResourceDefinition
{
    public string Name => "ImportJobsController";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new GetDeletejobOperation(),
        new GetExportjobOperation(),
        new GetImportjobOperation(),
        new ListByImportSiteOperation(),
        new ListDeletejobsOperation(),
        new ListExportjobsOperation(),
        new ListImportjobsOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(DeleteImportedMachinesJobPropertiesJobStateConstant),
        typeof(JobResultConstant),
        typeof(ProvisioningStateConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(DeleteImportMachinesJobModel),
        typeof(DeleteImportedMachinesJobPropertiesModel),
        typeof(ErrorDetailsModel),
        typeof(ExportImportedMachinesJobModel),
        typeof(ExportImportedMachinesJobEntityPropertiesModel),
        typeof(ImportJobModel),
        typeof(ImportMachinesJobModel),
        typeof(ImportMachinesJobPropertiesModel),
        typeof(JobErrorSummaryModel),
        typeof(JobPropertiesModel),
    };
}
