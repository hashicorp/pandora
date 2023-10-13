using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2022_02_01.TemplateSpecs;

internal class Definition : ResourceDefinition
{
    public string Name => "TemplateSpecs";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetBuiltInOperation(),
        new ListBuiltInsOperation(),
        new ListByResourceGroupOperation(),
        new ListBySubscriptionOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(TemplateSpecExpandKindConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(TemplateSpecModel),
        typeof(TemplateSpecPropertiesModel),
        typeof(TemplateSpecUpdateModelModel),
        typeof(TemplateSpecVersionInfoModel),
    };
}
