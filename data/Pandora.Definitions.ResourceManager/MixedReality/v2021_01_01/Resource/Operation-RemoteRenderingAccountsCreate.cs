using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.MixedReality.v2021_01_01.Resource;

internal class RemoteRenderingAccountsCreateOperation : Operations.PutOperation
{
    public override Type? RequestObject() => typeof(RemoteRenderingAccountModel);

\t\tpublic override ResourceID? ResourceId() => new RemoteRenderingAccountId();

\t\tpublic override Type? ResponseObject() => typeof(RemoteRenderingAccountModel);


}
