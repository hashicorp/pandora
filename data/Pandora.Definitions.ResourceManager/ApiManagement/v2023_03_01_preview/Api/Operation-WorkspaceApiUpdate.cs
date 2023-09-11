using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.Api;

internal class WorkspaceApiUpdateOperation : Pandora.Definitions.Operations.PatchOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(ApiUpdateContractModel);

    public override ResourceID? ResourceId() => new WorkspaceApiId();

    public override Type? ResponseObject() => typeof(ApiContractModel);

    public override Type? OptionsObject() => typeof(WorkspaceApiUpdateOperation.WorkspaceApiUpdateOptions);

    internal class WorkspaceApiUpdateOptions
    {
        [HeaderName("If-Match")]
        public string IfMatch { get; set; }
    }
}
