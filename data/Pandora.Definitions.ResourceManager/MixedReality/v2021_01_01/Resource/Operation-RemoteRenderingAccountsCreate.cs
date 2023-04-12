using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MixedReality.v2021_01_01.Resource;

internal class RemoteRenderingAccountsCreateOperation : Pandora.Definitions.Operations.PutOperation
{
    public override Type? RequestObject() => typeof(RemoteRenderingAccountModel);

    public override ResourceID? ResourceId() => new RemoteRenderingAccountId();

    public override Type? ResponseObject() => typeof(RemoteRenderingAccountModel);


}
