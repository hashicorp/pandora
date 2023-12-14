using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2023_11_01.Activity;

internal class Definition : ResourceDefinition
{
    public string Name => "Activity";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new GetOperation(),
        new ListByModuleOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ActivityModel),
        typeof(ActivityOutputTypeModel),
        typeof(ActivityParameterModel),
        typeof(ActivityParameterSetModel),
        typeof(ActivityParameterValidationSetModel),
        typeof(ActivityPropertiesModel),
    };
}
