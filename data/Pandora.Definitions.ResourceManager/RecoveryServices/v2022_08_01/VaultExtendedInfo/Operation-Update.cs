using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.RecoveryServices.v2022_08_01.VaultExtendedInfo;

internal class UpdateOperation : Pandora.Definitions.Operations.PatchOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(VaultExtendedInfoResourceModel);

    public override ResourceID? ResourceId() => new VaultId();

    public override Type? ResponseObject() => typeof(VaultExtendedInfoResourceModel);

    public override string? UriSuffix() => "/extendedInformation/vaultExtendedInfo";


}
