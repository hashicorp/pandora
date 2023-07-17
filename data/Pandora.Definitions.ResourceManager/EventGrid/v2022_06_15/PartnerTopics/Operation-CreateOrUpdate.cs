using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.EventGrid.v2022_06_15.PartnerTopics;

internal class CreateOrUpdateOperation : Pandora.Definitions.Operations.PutOperation
{
    public override Type? RequestObject() => typeof(PartnerTopicModel);

    public override ResourceID? ResourceId() => new PartnerTopicId();

    public override Type? ResponseObject() => typeof(PartnerTopicModel);


}
