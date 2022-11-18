using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Automation.v2019_06_01.Usages;

internal class ListByAutomationAccountOperation : Operations.GetOperation
{
\t\tpublic override ResourceID? ResourceId() => new AutomationAccountId();

\t\tpublic override Type? ResponseObject() => typeof(UsageListResultModel);

\t\tpublic override string? UriSuffix() => "/usages";


}
