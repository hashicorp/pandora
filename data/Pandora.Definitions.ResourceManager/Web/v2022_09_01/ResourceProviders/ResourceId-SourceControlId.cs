using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.ResourceProviders;

internal class SourceControlId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/providers/Microsoft.Web/sourceControls/{sourceControlName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftWeb", "Microsoft.Web"),
        ResourceIDSegment.Static("staticSourceControls", "sourceControls"),
        ResourceIDSegment.UserSpecified("sourceControlName"),
    };
}
