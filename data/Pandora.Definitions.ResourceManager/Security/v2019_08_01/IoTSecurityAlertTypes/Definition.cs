using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2019_08_01.IoTSecurityAlertTypes;

internal class Definition : ResourceDefinition
{
    public string Name => "IoTSecurityAlertTypes";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new IotAlertTypesGetOperation(),
        new IotAlertTypesListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AlertIntentConstant),
        typeof(AlertSeverityConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(IotAlertTypeModel),
        typeof(IotAlertTypeListModel),
        typeof(IotAlertTypePropertiesModel),
    };
}
