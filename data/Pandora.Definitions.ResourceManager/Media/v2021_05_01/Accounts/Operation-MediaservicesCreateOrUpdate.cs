using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Media.v2021_05_01.Accounts;

internal class MediaservicesCreateOrUpdateOperation : Operations.PutOperation
{
    public override Type? RequestObject() => typeof(MediaServiceModel);

\t\tpublic override ResourceID? ResourceId() => new MediaServiceId();

\t\tpublic override Type? ResponseObject() => typeof(MediaServiceModel);


}
