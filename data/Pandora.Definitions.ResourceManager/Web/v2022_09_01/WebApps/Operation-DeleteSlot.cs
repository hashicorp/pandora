using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.WebApps;

internal class DeleteSlotOperation : Pandora.Definitions.Operations.DeleteOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.NoContent,
                HttpStatusCode.OK,
        };

    public override ResourceID? ResourceId() => new SlotId();

    public override Type? OptionsObject() => typeof(DeleteSlotOperation.DeleteSlotOptions);

    internal class DeleteSlotOptions
    {
        [QueryStringName("deleteEmptyServerFarm")]
        [Optional]
        public bool DeleteEmptyServerFarm { get; set; }

        [QueryStringName("deleteMetrics")]
        [Optional]
        public bool DeleteMetrics { get; set; }
    }
}
