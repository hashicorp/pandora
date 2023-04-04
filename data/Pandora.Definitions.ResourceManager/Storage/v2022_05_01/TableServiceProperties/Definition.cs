using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Storage.v2022_05_01.TableServiceProperties;

internal class Definition : ResourceDefinition
{
    public string Name => "TableServiceProperties";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new TableServicesGetServicePropertiesOperation(),
        new TableServicesListOperation(),
        new TableServicesSetServicePropertiesOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(AllowedMethodsConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(CorsRuleModel),
        typeof(CorsRulesModel),
        typeof(ListTableServicesModel),
        typeof(TableServicePropertiesModel),
        typeof(TableServicePropertiesPropertiesModel),
    };
}
