using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2022_02_01.TemplateSpecVersions;

internal class BuiltInTemplateSpecId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/providers/Microsoft.Resources/builtInTemplateSpecs/{builtInTemplateSpecName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftResources", "Microsoft.Resources"),
        ResourceIDSegment.Static("staticBuiltInTemplateSpecs", "builtInTemplateSpecs"),
        ResourceIDSegment.UserSpecified("builtInTemplateSpecName"),
    };
}
