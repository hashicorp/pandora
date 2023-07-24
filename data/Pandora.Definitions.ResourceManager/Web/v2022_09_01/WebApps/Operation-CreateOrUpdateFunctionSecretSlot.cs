using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.WebApps;

internal class CreateOrUpdateFunctionSecretSlotOperation : Pandora.Definitions.Operations.PutOperation
{
    public override Type? RequestObject() => typeof(KeyInfoModel);

    public override ResourceID? ResourceId() => new FunctionKeyId();

    public override Type? ResponseObject() => typeof(KeyInfoModel);


}
