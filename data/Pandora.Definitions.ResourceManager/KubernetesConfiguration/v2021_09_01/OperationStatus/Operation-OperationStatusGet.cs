using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.KubernetesConfiguration.v2021_09_01.OperationStatus;

internal class OperationStatusGetOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new OperationId();

    public override Type? ResponseObject() => typeof(OperationStatusResultModel);


}
