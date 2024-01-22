// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

namespace Pandora.Data.Models;

public enum ResourceIdSegmentType
{
    Unknown,
    Constant,
    ResourceGroup,
    ResourceProvider,
    Scope,
    Static,
    SubscriptionId,
    UserSpecified
}