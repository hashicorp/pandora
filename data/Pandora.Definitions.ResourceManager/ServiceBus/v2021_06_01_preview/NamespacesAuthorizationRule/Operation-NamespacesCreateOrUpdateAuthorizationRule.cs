using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ServiceBus.v2021_06_01_preview.NamespacesAuthorizationRule;

internal class NamespacesCreateOrUpdateAuthorizationRuleOperation : Operations.PutOperation
{
\t\tpublic override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(SBAuthorizationRuleModel);

\t\tpublic override ResourceID? ResourceId() => new AuthorizationRuleId();

\t\tpublic override Type? ResponseObject() => typeof(SBAuthorizationRuleModel);


}
