using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.ApiRelease;

internal class WorkspaceApiReleaseCreateOrUpdateOperation : Pandora.Definitions.Operations.PutOperation
{
    public override Type? RequestObject() => typeof(ApiReleaseContractModel);

    public override ResourceID? ResourceId() => new ApiReleaseId();

    public override Type? ResponseObject() => typeof(ApiReleaseContractModel);

    public override Type? OptionsObject() => typeof(WorkspaceApiReleaseCreateOrUpdateOperation.WorkspaceApiReleaseCreateOrUpdateOptions);

    internal class WorkspaceApiReleaseCreateOrUpdateOptions
    {
        [HeaderName("If-Match")]
        [Optional]
        public string IfMatch { get; set; }
    }
}
