using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.Group;

internal class WorkspaceGroupCreateOrUpdateOperation : Pandora.Definitions.Operations.PutOperation
{
    public override Type? RequestObject() => typeof(GroupCreateParametersModel);

    public override ResourceID? ResourceId() => new WorkspaceGroupId();

    public override Type? ResponseObject() => typeof(GroupContractModel);

    public override Type? OptionsObject() => typeof(WorkspaceGroupCreateOrUpdateOperation.WorkspaceGroupCreateOrUpdateOptions);

    internal class WorkspaceGroupCreateOrUpdateOptions
    {
        [HeaderName("If-Match")]
        [Optional]
        public string IfMatch { get; set; }
    }
}
