using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Attestation.v2021_06_01.AttestationProviders;

internal class GetDefaultByLocationOperation : Pandora.Definitions.Operations.GetOperation
{
    public override ResourceID? ResourceId() => new LocationId();

    public override Type? ResponseObject() => typeof(AttestationProvidersModel);

    public override string? UriSuffix() => "/defaultProvider";


}
