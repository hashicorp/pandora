using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2021_11_01.Encodings;

internal class TransformsCreateOrUpdateOperation : Operations.PutOperation
{
    public override Type? RequestObject() => typeof(TransformModel);

    public override ResourceID? ResourceId() => new TransformId();

    public override Type? ResponseObject() => typeof(TransformModel);


}
