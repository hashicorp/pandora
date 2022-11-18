using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServices.v2022_03_01.GetPrivateLinkResources;

internal class PrivateLinkResourcesGetOperation : Operations.GetOperation
{
\t\tpublic override ResourceID? ResourceId() => new PrivateLinkResourceId();

\t\tpublic override Type? ResponseObject() => typeof(PrivateLinkResourceModel);


}
