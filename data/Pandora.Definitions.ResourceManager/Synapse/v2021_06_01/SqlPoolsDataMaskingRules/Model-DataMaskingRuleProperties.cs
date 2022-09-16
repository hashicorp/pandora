using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Synapse.v2021_06_01.SqlPoolsDataMaskingRules;


internal class DataMaskingRulePropertiesModel
{
    [JsonPropertyName("aliasName")]
    public string? AliasName { get; set; }

    [JsonPropertyName("columnName")]
    [Required]
    public string ColumnName { get; set; }

    [JsonPropertyName("id")]
    public string? Id { get; set; }

    [JsonPropertyName("maskingFunction")]
    [Required]
    public DataMaskingFunctionConstant MaskingFunction { get; set; }

    [JsonPropertyName("numberFrom")]
    public string? NumberFrom { get; set; }

    [JsonPropertyName("numberTo")]
    public string? NumberTo { get; set; }

    [JsonPropertyName("prefixSize")]
    public string? PrefixSize { get; set; }

    [JsonPropertyName("replacementString")]
    public string? ReplacementString { get; set; }

    [JsonPropertyName("ruleState")]
    public DataMaskingRuleStateConstant? RuleState { get; set; }

    [JsonPropertyName("schemaName")]
    [Required]
    public string SchemaName { get; set; }

    [JsonPropertyName("suffixSize")]
    public string? SuffixSize { get; set; }

    [JsonPropertyName("tableName")]
    [Required]
    public string TableName { get; set; }
}
