using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AzureActiveDirectory.v2017_04_01.DiagnosticSettings;

internal class DiagnosticSettingId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/providers/Microsoft.AADIAM/diagnosticSettings/{diagnosticSettingName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftAADIAM", "Microsoft.AADIAM"),
        ResourceIDSegment.Static("staticDiagnosticSettings", "diagnosticSettings"),
        ResourceIDSegment.UserSpecified("diagnosticSettingName"),
    };
}
