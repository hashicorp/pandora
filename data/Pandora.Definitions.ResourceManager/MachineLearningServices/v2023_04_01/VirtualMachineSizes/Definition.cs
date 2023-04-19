using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MachineLearningServices.v2023_04_01.VirtualMachineSizes;

internal class Definition : ResourceDefinition
{
    public string Name => "VirtualMachineSizes";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(BillingCurrencyConstant),
        typeof(UnitOfMeasureConstant),
        typeof(VMPriceOSTypeConstant),
        typeof(VMTierConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(EstimatedVMPriceModel),
        typeof(EstimatedVMPricesModel),
        typeof(VirtualMachineSizeModel),
        typeof(VirtualMachineSizeListResultModel),
    };
}
