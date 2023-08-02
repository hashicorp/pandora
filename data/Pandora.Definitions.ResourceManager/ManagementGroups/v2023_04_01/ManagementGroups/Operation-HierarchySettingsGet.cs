using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ManagementGroups.v2023_04_01.ManagementGroups;

internal class HierarchySettingsGetOperation : Pandora.Definitions.Operations.GetOperation
{
    public override ResourceID? ResourceId() => new ManagementGroupId();

    public override Type? ResponseObject() => typeof(HierarchySettingsModel);

    public override string? UriSuffix() => "/settings/default";


}
