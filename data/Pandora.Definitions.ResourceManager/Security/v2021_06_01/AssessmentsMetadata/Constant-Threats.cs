// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Security.v2021_06_01.AssessmentsMetadata;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ThreatsConstant
{
    [Description("accountBreach")]
    AccountBreach,

    [Description("dataExfiltration")]
    DataExfiltration,

    [Description("dataSpillage")]
    DataSpillage,

    [Description("denialOfService")]
    DenialOfService,

    [Description("elevationOfPrivilege")]
    ElevationOfPrivilege,

    [Description("maliciousInsider")]
    MaliciousInsider,

    [Description("missingCoverage")]
    MissingCoverage,

    [Description("threatResistance")]
    ThreatResistance,
}
