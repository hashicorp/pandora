using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ContainerService.v2023_10_15.FleetMembers;

internal class CreateOperation : Pandora.Definitions.Operations.PutOperation
{
    public override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(FleetMemberModel);

    public override ResourceID? ResourceId() => new MemberId();

    public override Type? ResponseObject() => typeof(FleetMemberModel);

    public override Type? OptionsObject() => typeof(CreateOperation.CreateOptions);

    internal class CreateOptions
    {
        [HeaderName("If-Match")]
        [Optional]
        public string IfMatch { get; set; }

        [HeaderName("If-None-Match")]
        [Optional]
        public string IfNoneMatch { get; set; }
    }
}
