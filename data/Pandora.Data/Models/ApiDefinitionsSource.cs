using System.ComponentModel;

namespace Pandora.Data.Models;

public enum ApiDefinitionsSource
{
    Unknown = 0,

    [Description("ResourceManagerRestApiSpecs")]
    ResourceManagerRestApiSpecs,

    [Description("HandWritten")]
    HandWritten
}