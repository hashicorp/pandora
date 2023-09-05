using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AutoManage.v2022_05_04.BestPractices;

internal class BestPracticeId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/providers/Microsoft.AutoManage/bestPractices/{bestPracticeName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftAutoManage", "Microsoft.AutoManage"),
        ResourceIDSegment.Static("staticBestPractices", "bestPractices"),
        ResourceIDSegment.UserSpecified("bestPracticeName"),
    };
}
