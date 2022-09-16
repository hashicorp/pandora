using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Synapse.v2021_06_01.SqlPoolsTables;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum ColumnDataTypeConstant
{
    [Description("bigint")]
    Bigint,

    [Description("binary")]
    Binary,

    [Description("bit")]
    Bit,

    [Description("char")]
    Char,

    [Description("date")]
    Date,

    [Description("datetime")]
    Datetime,

    [Description("datetime2")]
    DatetimeTwo,

    [Description("datetimeoffset")]
    Datetimeoffset,

    [Description("decimal")]
    Decimal,

    [Description("float")]
    Float,

    [Description("geography")]
    Geography,

    [Description("geometry")]
    Geometry,

    [Description("hierarchyid")]
    Hierarchyid,

    [Description("image")]
    Image,

    [Description("int")]
    Int,

    [Description("money")]
    Money,

    [Description("nchar")]
    Nchar,

    [Description("ntext")]
    Ntext,

    [Description("numeric")]
    Numeric,

    [Description("nvarchar")]
    Nvarchar,

    [Description("real")]
    Real,

    [Description("smalldatetime")]
    Smalldatetime,

    [Description("smallint")]
    Smallint,

    [Description("smallmoney")]
    Smallmoney,

    [Description("sql_variant")]
    SqlVariant,

    [Description("sysname")]
    Sysname,

    [Description("text")]
    Text,

    [Description("time")]
    Time,

    [Description("timestamp")]
    Timestamp,

    [Description("tinyint")]
    Tinyint,

    [Description("uniqueidentifier")]
    Uniqueidentifier,

    [Description("varbinary")]
    Varbinary,

    [Description("varchar")]
    Varchar,

    [Description("xml")]
    Xml,
}
