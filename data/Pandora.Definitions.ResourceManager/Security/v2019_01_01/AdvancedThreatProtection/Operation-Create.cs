using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Security.v2019_01_01.AdvancedThreatProtection;

internal class CreateOperation : Pandora.Definitions.Operations.PutOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(AdvancedThreatProtectionSettingModel);

    public override ResourceID? ResourceId() => new ScopeId();

    public override Type? ResponseObject() => typeof(AdvancedThreatProtectionSettingModel);

    public override string? UriSuffix() => "/providers/Microsoft.Security/advancedThreatProtectionSettings/current";


}
