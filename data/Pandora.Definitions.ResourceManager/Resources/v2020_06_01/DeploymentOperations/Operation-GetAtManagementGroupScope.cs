using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Resources.v2020_06_01.DeploymentOperations;

internal class GetAtManagementGroupScopeOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new Providers2DeploymentOperationId();

    public override Type? ResponseObject() => typeof(DeploymentOperationModel);


}
