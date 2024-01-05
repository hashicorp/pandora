using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CostManagement.v2023_11_01.PriceSheets;

internal class Definition : ResourceDefinition
{
    public string Name => "PriceSheets";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new PriceSheetDownloadByBillingAccountOperation(),
        new PriceSheetDownloadByBillingProfileOperation(),
        new PriceSheetDownloadByInvoiceOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(OperationStatusTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(DownloadUrlModel),
        typeof(EAPriceSheetPropertiesModel),
        typeof(EAPricesheetDownloadPropertiesModel),
        typeof(MCAPriceSheetPropertiesModel),
        typeof(OperationStatusModel),
        typeof(PricesheetDownloadPropertiesModel),
    };
}
