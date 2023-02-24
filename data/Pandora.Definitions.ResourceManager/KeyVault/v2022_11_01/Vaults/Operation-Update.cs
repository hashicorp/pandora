using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.KeyVault.v2022_11_01.Vaults;

internal class UpdateOperation : Operations.PatchOperation
{
    public override Type? RequestObject() => typeof(VaultPatchParametersModel);

    public override ResourceID? ResourceId() => new VaultId();

    public override Type? ResponseObject() => typeof(VaultModel);


}
