// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class AdminModel
{
    [JsonPropertyName("appsAndServices")]
    public AdminAppsAndServicesModel? AppsAndServices { get; set; }

    [JsonPropertyName("dynamics")]
    public AdminDynamicsModel? Dynamics { get; set; }

    [JsonPropertyName("edge")]
    public EdgeModel? Edge { get; set; }

    [JsonPropertyName("forms")]
    public AdminFormsModel? Forms { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("people")]
    public PeopleAdminSettingsModel? People { get; set; }

    [JsonPropertyName("reportSettings")]
    public AdminReportSettingsModel? ReportSettings { get; set; }

    [JsonPropertyName("serviceAnnouncement")]
    public ServiceAnnouncementModel? ServiceAnnouncement { get; set; }

    [JsonPropertyName("sharepoint")]
    public SharepointModel? Sharepoint { get; set; }

    [JsonPropertyName("todo")]
    public AdminTodoModel? Todo { get; set; }

    [JsonPropertyName("windows")]
    public AdminWindowsModel? Windows { get; set; }
}
