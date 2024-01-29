// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Web.v2022_09_01.AppServicePlans;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ConnectionStringTypeConstant
{
    [Description("ApiHub")]
    ApiHub,

    [Description("Custom")]
    Custom,

    [Description("DocDb")]
    DocDb,

    [Description("EventHub")]
    EventHub,

    [Description("MySql")]
    MySql,

    [Description("NotificationHub")]
    NotificationHub,

    [Description("PostgreSQL")]
    PostgreSQL,

    [Description("RedisCache")]
    RedisCache,

    [Description("SQLAzure")]
    SQLAzure,

    [Description("SQLServer")]
    SQLServer,

    [Description("ServiceBus")]
    ServiceBus,
}
