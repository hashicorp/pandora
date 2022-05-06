using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Relay.v2017_04_01.Namespaces;

internal class UpdateOperation : Operations.PatchOperation
{
    public override Type? RequestObject() => typeof(RelayUpdateParametersModel);

    public override ResourceID? ResourceId() => new NamespaceId();

    public override Type? ResponseObject() => typeof(RelayNamespaceModel);


}
