using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Synapse.v2021_06_01.SqlPoolsMaintenanceWindowOptions;

internal class SqlPoolMaintenanceWindowOptionsGetOperation : Operations.GetOperation
{
    public override ResourceID? ResourceId() => new SqlPoolId();

    public override Type? ResponseObject() => typeof(MaintenanceWindowOptionsModel);

    public override Type? OptionsObject() => typeof(SqlPoolMaintenanceWindowOptionsGetOperation.SqlPoolMaintenanceWindowOptionsGetOptions);

    public override string? UriSuffix() => "/maintenanceWindowOptions/current";

    internal class SqlPoolMaintenanceWindowOptionsGetOptions
    {
        [QueryStringName("maintenanceWindowOptionsName")]
        public string MaintenanceWindowOptionsName { get; set; }
    }
}
