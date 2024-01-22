// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.HandDefined.AADB2C.v2021_04_01_preview.Tenants;

internal class Definition : ResourceDefinition
{
    // https://docs.microsoft.com/en-us/rest/api/activedirectory/b2c-tenants
    public string Name => "Tenants";
    public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
    {
        new CheckNameAvailabilityOperation(),
        new Create(),
        new Delete(),
        new Get(),
        new ListByResourceGroup(),
        new ListBySubscription(),
        new Update(),
    };

    public IEnumerable<Type> Constants => new List<Type>
    {
        typeof(BillingType),
        typeof(Location),
        typeof(SkuName),
        typeof(SkuTier),
    };
    public IEnumerable<Type> Models => new List<Type>
    {
        typeof(BillingConfigModel),
        typeof(CheckNameAvailabilityRequestModel),
        typeof(CheckNameAvailabilityResultModel),
        typeof(CreateTenantModel),
        typeof(CreateTenantPropertiesModel),
        typeof(SkuModel),
        typeof(TenantModel),
        typeof(TenantPropertiesModel),
        typeof(TenantPropertiesForCreate),
        typeof(UpdateTenantModel),
        typeof(UpdateTenantPropertiesModel),
    };
}