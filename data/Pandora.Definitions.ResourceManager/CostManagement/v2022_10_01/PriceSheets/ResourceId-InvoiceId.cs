using System.Collections.Generic;
using Pandora.Definitions.Interfaces;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.CostManagement.v2022_10_01.PriceSheets;

internal class InvoiceId : ResourceID
{
    public string? CommonAlias => null;

    public string ID => "/providers/Microsoft.Billing/billingAccounts/{billingAccountName}/billingProfiles/{billingProfileName}/invoices/{invoiceName}";

    public List<ResourceIDSegment> Segments => new List<ResourceIDSegment>
    {
        ResourceIDSegment.Static("staticProviders", "providers"),
        ResourceIDSegment.ResourceProvider("staticMicrosoftBilling", "Microsoft.Billing"),
        ResourceIDSegment.Static("staticBillingAccounts", "billingAccounts"),
        ResourceIDSegment.UserSpecified("billingAccountName"),
        ResourceIDSegment.Static("staticBillingProfiles", "billingProfiles"),
        ResourceIDSegment.UserSpecified("billingProfileName"),
        ResourceIDSegment.Static("staticInvoices", "invoices"),
        ResourceIDSegment.UserSpecified("invoiceName"),
    };
}
