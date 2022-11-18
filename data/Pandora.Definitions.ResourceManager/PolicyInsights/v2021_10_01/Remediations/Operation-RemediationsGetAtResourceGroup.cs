using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.PolicyInsights.v2021_10_01.Remediations;

internal class RemediationsGetAtResourceGroupOperation : Operations.GetOperation
{
\t\tpublic override ResourceID? ResourceId() => new ProviderRemediationId();

\t\tpublic override Type? ResponseObject() => typeof(RemediationModel);


}
