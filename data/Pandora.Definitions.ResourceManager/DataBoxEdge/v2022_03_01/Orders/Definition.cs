using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataBoxEdge.v2022_03_01.Orders;

internal class Definition : ResourceDefinition
{
    public string Name => "Orders";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListByDataBoxEdgeDeviceOperation(),
        new ListDCAccessCodeOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(OrderStateConstant),
        typeof(ShipmentTypeConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(AddressModel),
        typeof(ContactDetailsModel),
        typeof(DCAccessCodeModel),
        typeof(DCAccessCodePropertiesModel),
        typeof(OrderModel),
        typeof(OrderPropertiesModel),
        typeof(OrderStatusModel),
        typeof(TrackingInfoModel),
    };
}
