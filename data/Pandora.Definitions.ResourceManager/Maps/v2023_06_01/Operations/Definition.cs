using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Maps.v2023_06_01.Operations;

internal class Definition : ResourceDefinition
{
    public string Name => "Operations";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new MapsListSubscriptionOperationsOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(DimensionModel),
        typeof(MetricSpecificationModel),
        typeof(OperationDetailModel),
        typeof(OperationDisplayModel),
        typeof(OperationPropertiesModel),
        typeof(ServiceSpecificationModel),
    };
}
