using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2021_11_01.MaintenanceWindows;

internal class CreateOrUpdateOperation : Pandora.Definitions.Operations.PutOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.OK,
        };

    public override Type? RequestObject() => typeof(MaintenanceWindowsModel);

    public override ResourceID? ResourceId() => new DatabaseId();

    public override Type? OptionsObject() => typeof(CreateOrUpdateOperation.CreateOrUpdateOptions);

    public override string? UriSuffix() => "/maintenanceWindows/current";

    internal class CreateOrUpdateOptions
    {
        [QueryStringName("maintenanceWindowName")]
        public string MaintenanceWindowName { get; set; }
    }
}
