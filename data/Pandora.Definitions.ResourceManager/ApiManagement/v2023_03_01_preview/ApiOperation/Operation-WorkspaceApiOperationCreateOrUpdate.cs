using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.ApiOperation;

internal class WorkspaceApiOperationCreateOrUpdateOperation : Pandora.Definitions.Operations.PutOperation
{
    public override Type? RequestObject() => typeof(OperationContractModel);

    public override ResourceID? ResourceId() => new ApiOperationId();

    public override Type? ResponseObject() => typeof(OperationContractModel);

    public override Type? OptionsObject() => typeof(WorkspaceApiOperationCreateOrUpdateOperation.WorkspaceApiOperationCreateOrUpdateOptions);

    internal class WorkspaceApiOperationCreateOrUpdateOptions
    {
        [HeaderName("If-Match")]
        [Optional]
        public string IfMatch { get; set; }
    }
}
