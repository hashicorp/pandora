using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2022_02_01.TemplateSpecVersions;

internal class Definition : ResourceDefinition
{
    public string Name => "TemplateSpecVersions";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOrUpdateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new GetBuiltInOperation(),
        new ListOperation(),
        new ListBuiltInsOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(LinkedTemplateArtifactModel),
        typeof(TemplateSpecVersionModel),
        typeof(TemplateSpecVersionPropertiesModel),
        typeof(TemplateSpecVersionUpdateModelModel),
    };
}
