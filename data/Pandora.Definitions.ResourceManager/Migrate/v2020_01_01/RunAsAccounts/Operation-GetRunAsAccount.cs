using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2020_01_01.RunAsAccounts;

internal class GetRunAsAccountOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new VMwareSiteRunAsAccountId();

    public override Type? ResponseObject() => typeof(VMwareRunAsAccountModel);


}
