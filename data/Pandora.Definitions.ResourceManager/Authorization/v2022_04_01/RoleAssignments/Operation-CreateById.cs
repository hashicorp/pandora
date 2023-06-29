using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Authorization.v2022_04_01.RoleAssignments;

internal class CreateByIdOperation : Pandora.Definitions.Operations.PutOperation
{
    public override Type? RequestObject() => typeof(RoleAssignmentCreateParametersModel);

    public override ResourceID? ResourceId() => new RoleAssignmentIdId();

    public override Type? ResponseObject() => typeof(RoleAssignmentModel);


}
