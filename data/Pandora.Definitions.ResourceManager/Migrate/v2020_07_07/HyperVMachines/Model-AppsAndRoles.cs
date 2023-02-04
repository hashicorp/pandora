using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Migrate.v2020_07_07.HyperVMachines;


internal class AppsAndRolesModel
{
    [JsonPropertyName("applications")]
    public List<ApplicationModel>? Applications { get; set; }

    [JsonPropertyName("bizTalkServers")]
    public List<BizTalkServerModel>? BizTalkServers { get; set; }

    [JsonPropertyName("exchangeServers")]
    public List<ExchangeServerModel>? ExchangeServers { get; set; }

    [JsonPropertyName("features")]
    public List<FeatureModel>? Features { get; set; }

    [JsonPropertyName("otherDatabases")]
    public List<OtherDatabaseModel>? OtherDatabases { get; set; }

    [JsonPropertyName("sharePointServers")]
    public List<SharePointServerModel>? SharePointServers { get; set; }

    [JsonPropertyName("sqlServers")]
    public List<SQLServerModel>? SqlServers { get; set; }

    [JsonPropertyName("systemCenters")]
    public List<SystemCenterModel>? SystemCenters { get; set; }

    [JsonPropertyName("webApplications")]
    public List<WebApplicationModel>? WebApplications { get; set; }
}
