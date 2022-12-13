using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ManagementGroups.v2021_04_01.ManagementGroups;

internal class HierarchySettingsUpdateOperation : Operations.PatchOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(CreateOrUpdateSettingsRequestModel);

    public override ResourceID? ResourceId() => new ManagementGroupId();

    public override Type? ResponseObject() => typeof(HierarchySettingsModel);

    public override string? UriSuffix() => "/settings/default";


}
