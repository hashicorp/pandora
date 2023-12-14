using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Sql.v2023_02_01_preview.ManagedInstanceDtcs;


internal class ManagedInstanceDtcSecuritySettingsModel
{
    [JsonPropertyName("snaLu6point2TransactionsEnabled")]
    public bool? SnaLu6point2TransactionsEnabled { get; set; }

    [JsonPropertyName("transactionManagerCommunicationSettings")]
    public ManagedInstanceDtcTransactionManagerCommunicationSettingsModel? TransactionManagerCommunicationSettings { get; set; }

    [JsonPropertyName("xaTransactionsDefaultTimeout")]
    public int? XaTransactionsDefaultTimeout { get; set; }

    [JsonPropertyName("xaTransactionsEnabled")]
    public bool? XaTransactionsEnabled { get; set; }

    [JsonPropertyName("xaTransactionsMaximumTimeout")]
    public int? XaTransactionsMaximumTimeout { get; set; }
}
