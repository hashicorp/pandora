using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2023_01_01.WebApps;

internal class GetInstanceProcessModuleOperation : Pandora.Definitions.Operations.GetOperation
{
    public override ResourceID? ResourceId() => new InstanceProcessModuleId();

    public override Type? ResponseObject() => typeof(ProcessModuleInfoModel);


}
