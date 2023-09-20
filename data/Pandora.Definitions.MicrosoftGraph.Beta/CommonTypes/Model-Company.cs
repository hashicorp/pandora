// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


namespace Pandora.Definitions.MicrosoftGraph.Beta.CommonTypes;

internal class CompanyModel
{
    [JsonPropertyName("accounts")]
    public List<AccountModel>? Accounts { get; set; }

    [JsonPropertyName("agedAccountsPayable")]
    public List<AgedAccountsPayableModel>? AgedAccountsPayable { get; set; }

    [JsonPropertyName("agedAccountsReceivable")]
    public List<AgedAccountsReceivableModel>? AgedAccountsReceivable { get; set; }

    [JsonPropertyName("businessProfileId")]
    public string? BusinessProfileId { get; set; }

    [JsonPropertyName("companyInformation")]
    public List<CompanyInformationModel>? CompanyInformation { get; set; }

    [JsonPropertyName("countriesRegions")]
    public List<CountryRegionModel>? CountriesRegions { get; set; }

    [JsonPropertyName("currencies")]
    public List<CurrencyModel>? Currencies { get; set; }

    [JsonPropertyName("customerPaymentJournals")]
    public List<CustomerPaymentJournalModel>? CustomerPaymentJournals { get; set; }

    [JsonPropertyName("customerPayments")]
    public List<CustomerPaymentModel>? CustomerPayments { get; set; }

    [JsonPropertyName("customers")]
    public List<CustomerModel>? Customers { get; set; }

    [JsonPropertyName("dimensionValues")]
    public List<DimensionValueModel>? DimensionValues { get; set; }

    [JsonPropertyName("dimensions")]
    public List<DimensionModel>? Dimensions { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("employees")]
    public List<EmployeeModel>? Employees { get; set; }

    [JsonPropertyName("generalLedgerEntries")]
    public List<GeneralLedgerEntryModel>? GeneralLedgerEntries { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("itemCategories")]
    public List<ItemCategoryModel>? ItemCategories { get; set; }

    [JsonPropertyName("items")]
    public List<ItemModel>? Items { get; set; }

    [JsonPropertyName("journalLines")]
    public List<JournalLineModel>? JournalLines { get; set; }

    [JsonPropertyName("journals")]
    public List<JournalModel>? Journals { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("@odata.type")]
    public string? ODataType { get; set; }

    [JsonPropertyName("paymentMethods")]
    public List<PaymentMethodModel>? PaymentMethods { get; set; }

    [JsonPropertyName("paymentTerms")]
    public List<PaymentTermModel>? PaymentTerms { get; set; }

    [JsonPropertyName("picture")]
    public List<PictureModel>? Picture { get; set; }

    [JsonPropertyName("purchaseInvoiceLines")]
    public List<PurchaseInvoiceLineModel>? PurchaseInvoiceLines { get; set; }

    [JsonPropertyName("purchaseInvoices")]
    public List<PurchaseInvoiceModel>? PurchaseInvoices { get; set; }

    [JsonPropertyName("salesCreditMemoLines")]
    public List<SalesCreditMemoLineModel>? SalesCreditMemoLines { get; set; }

    [JsonPropertyName("salesCreditMemos")]
    public List<SalesCreditMemoModel>? SalesCreditMemos { get; set; }

    [JsonPropertyName("salesInvoiceLines")]
    public List<SalesInvoiceLineModel>? SalesInvoiceLines { get; set; }

    [JsonPropertyName("salesInvoices")]
    public List<SalesInvoiceModel>? SalesInvoices { get; set; }

    [JsonPropertyName("salesOrderLines")]
    public List<SalesOrderLineModel>? SalesOrderLines { get; set; }

    [JsonPropertyName("salesOrders")]
    public List<SalesOrderModel>? SalesOrders { get; set; }

    [JsonPropertyName("salesQuoteLines")]
    public List<SalesQuoteLineModel>? SalesQuoteLines { get; set; }

    [JsonPropertyName("salesQuotes")]
    public List<SalesQuoteModel>? SalesQuotes { get; set; }

    [JsonPropertyName("shipmentMethods")]
    public List<ShipmentMethodModel>? ShipmentMethods { get; set; }

    [JsonPropertyName("systemVersion")]
    public string? SystemVersion { get; set; }

    [JsonPropertyName("taxAreas")]
    public List<TaxAreaModel>? TaxAreas { get; set; }

    [JsonPropertyName("taxGroups")]
    public List<TaxGroupModel>? TaxGroups { get; set; }

    [JsonPropertyName("unitsOfMeasure")]
    public List<UnitOfMeasureModel>? UnitsOfMeasure { get; set; }

    [JsonPropertyName("vendors")]
    public List<VendorModel>? Vendors { get; set; }
}
