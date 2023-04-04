using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Storage.v2022_05_01.QueueServiceProperties;

internal class Definition : ResourceDefinition
{
    public string Name => "QueueServiceProperties";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new QueueServicesGetServicePropertiesOperation(),
        new QueueServicesListOperation(),
        new QueueServicesSetServicePropertiesOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AllowedMethodsConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CorsRuleModel),
        typeof(CorsRulesModel),
        typeof(ListQueueServicesModel),
        typeof(QueueServicePropertiesModel),
        typeof(QueueServicePropertiesPropertiesModel),
    };
}
