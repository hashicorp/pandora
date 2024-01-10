using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.ProductPolicy;

internal class WorkspaceProductPolicyCreateOrUpdateOperation : Pandora.Definitions.Operations.PutOperation
{
    public override Type? RequestObject() => typeof(PolicyContractModel);

    public override ResourceID? ResourceId() => new WorkspaceProductId();

    public override Type? ResponseObject() => typeof(PolicyContractModel);

    public override Type? OptionsObject() => typeof(WorkspaceProductPolicyCreateOrUpdateOperation.WorkspaceProductPolicyCreateOrUpdateOptions);

    public override string? UriSuffix() => "/policies/policy";

    internal class WorkspaceProductPolicyCreateOrUpdateOptions
    {
        [HeaderName("If-Match")]
        [Optional]
        public string IfMatch { get; set; }
    }
}
