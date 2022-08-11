using System;

namespace Pandora.Definitions.Attributes;

public class DocumentationAttribute : Attribute
{
    public string Markdown { get; }

    public DocumentationAttribute(string markdown)
    {
        Markdown = markdown;
    }
}