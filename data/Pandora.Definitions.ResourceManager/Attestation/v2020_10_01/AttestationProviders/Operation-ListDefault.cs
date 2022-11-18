using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Attestation.v2020_10_01.AttestationProviders;

internal class ListDefaultOperation : Operations.GetOperation
{
\t\tpublic override ResourceID? ResourceId() => new SubscriptionId();

\t\tpublic override Type? ResponseObject() => typeof(AttestationProviderListResultModel);

\t\tpublic override string? UriSuffix() => "/providers/Microsoft.Attestation/defaultProviders";


}
