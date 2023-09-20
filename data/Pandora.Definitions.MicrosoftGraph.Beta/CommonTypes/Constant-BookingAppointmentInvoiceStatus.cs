// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum BookingAppointmentInvoiceStatusConstant
{
    [Description("Draft")]
    @draft,

    [Description("Reviewing")]
    @reviewing,

    [Description("Open")]
    @open,

    [Description("Canceled")]
    @canceled,

    [Description("Paid")]
    @paid,

    [Description("Corrective")]
    @corrective,
}
