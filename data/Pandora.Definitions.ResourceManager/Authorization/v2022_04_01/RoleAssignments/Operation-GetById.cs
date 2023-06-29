using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Authorization.v2022_04_01.RoleAssignments;

internal class GetByIdOperation : Pandora.Definitions.Operations.GetOperation
{
    public override ResourceID? ResourceId() => new RoleAssignmentIdId();

    public override Type? ResponseObject() => typeof(RoleAssignmentModel);

    public override Type? OptionsObject() => typeof(GetByIdOperation.GetByIdOptions);

    internal class GetByIdOptions
    {
        [QueryStringName("tenantId")]
        [Optional]
        public string TenantId { get; set; }
    }
}
