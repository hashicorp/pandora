using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DesktopVirtualization.v2022_02_10_preview.MsixImage;

internal class Definition : ResourceDefinition
{
    public string Name => "MsixImage";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new ExpandOperation(),
    };
    public IEnumerable<System.Type> Constants => new List<System.Type>
    {

    };
    public IEnumerable<System.Type> Models => new List<System.Type>
    {
        typeof(ExpandMsixImageModel),
        typeof(ExpandMsixImagePropertiesModel),
        typeof(MSIXImageURIModel),
        typeof(MsixPackageApplicationsModel),
        typeof(MsixPackageDependenciesModel),
    };
}
