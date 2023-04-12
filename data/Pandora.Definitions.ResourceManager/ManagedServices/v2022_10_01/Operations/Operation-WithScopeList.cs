using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ManagedServices.v2022_10_01.Operations;

internal class WithScopeListOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new ScopeId();

    public override Type? ResponseObject() => typeof(OperationListModel);

    public override string? UriSuffix() => "/providers/Microsoft.ManagedServices/operations";


}
