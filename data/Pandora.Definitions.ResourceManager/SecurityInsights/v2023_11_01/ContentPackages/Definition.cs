using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2023_11_01.ContentPackages;

internal class Definition : ResourceDefinition
{
    public string Name => "ContentPackages";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ContentPackageInstallOperation(),
        new ContentPackageUninstallOperation(),
        new GetOperation(),
        new ListOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {
        typeof(FlagConstant),
        typeof(KindConstant),
        typeof(OperatorConstant),
        typeof(PackageKindConstant),
        typeof(SourceKindConstant),
        typeof(SupportTierConstant),
    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(MetadataAuthorModel),
        typeof(MetadataCategoriesModel),
        typeof(MetadataDependenciesModel),
        typeof(MetadataSourceModel),
        typeof(MetadataSupportModel),
        typeof(PackageBasePropertiesModel),
        typeof(PackageModelModel),
    };
}
