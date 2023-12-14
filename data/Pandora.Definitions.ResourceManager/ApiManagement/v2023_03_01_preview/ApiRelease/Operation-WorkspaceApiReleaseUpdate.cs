using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.ApiRelease;

internal class WorkspaceApiReleaseUpdateOperation : Pandora.Definitions.Operations.PatchOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(ApiReleaseContractModel);

    public override ResourceID? ResourceId() => new ApiReleaseId();

    public override Type? ResponseObject() => typeof(ApiReleaseContractModel);

    public override Type? OptionsObject() => typeof(WorkspaceApiReleaseUpdateOperation.WorkspaceApiReleaseUpdateOptions);

    internal class WorkspaceApiReleaseUpdateOptions
    {
        [HeaderName("If-Match")]
        public string IfMatch { get; set; }
    }
}
