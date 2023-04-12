using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Redis.v2022_06_01.PatchSchedules;

internal class CreateOrUpdateOperation : Pandora.Definitions.Operations.PutOperation
{
    public override Type? RequestObject() => typeof(RedisPatchScheduleModel);

    public override ResourceID? ResourceId() => new RediId();

    public override Type? ResponseObject() => typeof(RedisPatchScheduleModel);

    public override string? UriSuffix() => "/patchSchedules/default";


}
