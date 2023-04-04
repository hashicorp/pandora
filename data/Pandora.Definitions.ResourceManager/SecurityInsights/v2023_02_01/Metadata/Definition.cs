using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2023_02_01.Metadata;

internal class Definition : ResourceDefinition
{
    public string Name => "Metadata";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CreateOperation(),
        new DeleteOperation(),
        new GetOperation(),
        new ListOperation(),
        new UpdateOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(OperatorConstant),
        typeof(SourceKindConstant),
        typeof(SupportTierConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(MetadataAuthorModel),
        typeof(MetadataCategoriesModel),
        typeof(MetadataDependenciesModel),
        typeof(MetadataModelModel),
        typeof(MetadataPatchModel),
        typeof(MetadataPropertiesModel),
        typeof(MetadataPropertiesPatchModel),
        typeof(MetadataSourceModel),
        typeof(MetadataSupportModel),
    };
}
