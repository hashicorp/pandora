using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.ApiOperationPolicy;

internal class WorkspaceApiOperationPolicyGetOperation : Pandora.Definitions.Operations.GetOperation
{
    public override ResourceID? ResourceId() => new ApiOperationId();

    public override Type? ResponseObject() => typeof(PolicyContractModel);

    public override Type? OptionsObject() => typeof(WorkspaceApiOperationPolicyGetOperation.WorkspaceApiOperationPolicyGetOptions);

    public override string? UriSuffix() => "/policies/policy";

    internal class WorkspaceApiOperationPolicyGetOptions
    {
        [QueryStringName("format")]
        [Optional]
        public PolicyExportFormatConstant Format { get; set; }
    }
}
