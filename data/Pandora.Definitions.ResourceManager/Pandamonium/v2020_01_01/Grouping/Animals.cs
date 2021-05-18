using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Operations;

namespace Pandora.Definitions.ResourceManager.Pandamonium.v2020_01_01.Grouping
{
    public abstract class Animal
    {
        [JsonPropertyName("type")]
        [ProvidesTypeHint]
        public string Type { get; set; }
    }

    [ValueForType("cat")]
    public class Cat : Animal
    {
    }

    [ValueForType("dog")]
    public class Dog : Animal
    {
    }

    public class GetAnimalModel
    {
        [JsonPropertyName("animals")]
        public List<Animal> Animals { get; set; }
    }

    public class GetAnimals : GetOperation
    {
        public override object? ResponseObject()
        {
            return new GetAnimalModel();
        }
    }
}