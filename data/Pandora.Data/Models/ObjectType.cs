namespace Pandora.Data.Models
{
    public enum ObjectType
    {
        Unknown,
        Boolean,
        Csv, // TODO: thread through
        DateTime, // TODO: thread through
        Dictionary,
        Integer,
        Float,
        List,
        RawFile, // TODO: thread through
        RawObject, // TODO: thread through
        Reference,
        String
    }
}