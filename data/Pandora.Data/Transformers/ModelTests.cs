using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using NUnit.Framework;
using Pandora.Data.Models;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Data.Transformers
{
    public static class ModelTests
    {
        [TestCase]
        public static void MappingABuiltInTypeShouldReturnNothing()
        {
            var builtInTypes = new List<Type>
            {
                typeof(bool),
                typeof(int),
                typeof(float),
                typeof(string),
                typeof(Csv<bool>),
                typeof(Csv<int>),
                typeof(Csv<float>),
                typeof(Csv<string>),
                typeof(Dictionary<string, bool>),
                typeof(Dictionary<string, int>),
                typeof(Dictionary<string, float>),
                typeof(Dictionary<string, string>),
                typeof(List<bool>),
                typeof(List<int>),
                typeof(List<float>),
                typeof(List<string>),
                typeof(List<List<bool>>),
                typeof(List<List<int>>),
                typeof(List<List<float>>),
                typeof(List<List<string>>),
                typeof(List<List<List<bool>>>),
                typeof(List<List<List<int>>>),
                typeof(List<List<List<float>>>),
                typeof(List<List<List<string>>>),
            };

            foreach (var type in builtInTypes)
            {
                var actual = Model.Map(type);
                Assert.AreEqual(0, actual.Count);
            }
        }

        [TestCase]
        public static void MappingACsvOfAModelShouldReturnJustTheModel()
        {
            // contents are verified below, as long as we have it we're good
            var actual = Model.Map(typeof(Csv<Example>));
            Assert.AreEqual(1, actual.Count);
        }

        [TestCase]
        public static void MappingADictionaryOfAModelShouldReturnJustTheModel()
        {
            // contents are verified below, as long as we have it we're good
            var actual = Model.Map(typeof(Dictionary<string, Example>));
            Assert.AreEqual(1, actual.Count);
        }

        [TestCase]
        public static void MappingAListOfAModelShouldReturnJustTheModel()
        {
            // contents are verified below, as long as we have it we're good
            var actual = Model.Map(typeof(List<Example>));
            Assert.AreEqual(1, actual.Count);
        }

        [TestCase]
        public static void MappingAListOfAListOfAModelShouldReturnJustTheModel()
        {
            // contents are verified below, as long as we have it we're good
            var actual = Model.Map(typeof(List<List<Example>>));
            Assert.AreEqual(1, actual.Count);
        }

        [TestCase]
        public static void MappingAListOfAListOfAListOfAModelShouldReturnJustTheModel()
        {
            // contents are verified below, as long as we have it we're good
            var actual = Model.Map(typeof(List<List<List<Example>>>));
            Assert.AreEqual(1, actual.Count);
        }

        [TestCase]
        public static void MappingAModelShouldRemoveSuffixes()
        {
            var actual = Model.Map(typeof(ExampleWithSuffixesModel));
            Assert.NotNull(actual);
            Assert.AreEqual(2, actual.Count);
            var model = actual.First(a => a.Name == "ExampleWithSuffixes");
            Assert.NotNull(actual.First(a => a.Name == "Second"));

            Assert.AreEqual("ExampleWithSuffixes", model.Name);
            Assert.AreEqual(4, model.Properties.Count);
            Assert.NotNull(model.Properties.First(p => p.Name == "Bool"));
            Assert.NotNull(model.Properties.First(p => p.Name == "Int"));
            Assert.NotNull(model.Properties.First(p => p.Name == "SecondProp"));
            Assert.NotNull(model.Properties.First(p => p.Name == "String"));

            var secondModel = model.Properties.First(p => p.Name == "SecondProp");
            Assert.AreEqual("Second", secondModel.ObjectDefinition.ReferenceName);
        }

        [TestCase]
        public static void MappingAModelContainingSelfReferences()
        {
            var actual = Model.Map(typeof(ExampleWithSelfReferences));
            Assert.NotNull(actual);
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual("ExampleWithSelfReferences", actual.First().Name);
            Assert.AreEqual(4, actual.First().Properties.Count);

            var selfReferenceProp = actual.First().Properties.First(f => f.Name == "SelfReference");
            Assert.NotNull(selfReferenceProp.Name);
            Assert.AreEqual(ObjectType.Reference, selfReferenceProp.ObjectDefinition.Type);
            Assert.AreEqual("ExampleWithSelfReferences", selfReferenceProp.ObjectDefinition.ReferenceName);

            var nilableSelfReferenceProp = actual.First().Properties.First(f => f.Name == "NilableSelfReference");
            Assert.NotNull(nilableSelfReferenceProp.Name);
            Assert.AreEqual(ObjectType.Reference, nilableSelfReferenceProp.ObjectDefinition.Type);
            Assert.True(nilableSelfReferenceProp.Optional);
            Assert.AreEqual("ExampleWithSelfReferences", nilableSelfReferenceProp.ObjectDefinition.ReferenceName);

            var listOfReferencesProp = actual.First().Properties.First(f => f.Name == "ListOfReferences");
            Assert.NotNull(listOfReferencesProp.Name);
            Assert.AreEqual(ObjectType.List, listOfReferencesProp.ObjectDefinition.Type);
            Assert.Null(listOfReferencesProp.ObjectDefinition.ReferenceName);
            Assert.AreEqual(ObjectType.Reference, listOfReferencesProp.ObjectDefinition.NestedItem.Type);
            Assert.AreEqual("ExampleWithSelfReferences", listOfReferencesProp.ObjectDefinition.NestedItem.ReferenceName);
            Assert.Null(listOfReferencesProp.ObjectDefinition.NestedItem.NestedItem);

            var nilableListOfReferencesProp = actual.First().Properties.First(f => f.Name == "NilableListOfReferences");
            Assert.NotNull(nilableSelfReferenceProp.Name);
            Assert.AreEqual(ObjectType.List, listOfReferencesProp.ObjectDefinition.Type);
            Assert.Null(listOfReferencesProp.ObjectDefinition.ReferenceName);
            Assert.AreEqual(ObjectType.Reference, listOfReferencesProp.ObjectDefinition.NestedItem.Type);
            Assert.AreEqual("ExampleWithSelfReferences", nilableListOfReferencesProp.ObjectDefinition.NestedItem.ReferenceName);
            Assert.Null(nilableListOfReferencesProp.ObjectDefinition.NestedItem.NestedItem);
            Assert.True(nilableListOfReferencesProp.Optional);
        }

        [TestCase]
        public static void MappingAModelContainingLists()
        {
            var actual = Model.Map(typeof(ExampleWithList));
            Assert.NotNull(actual);
            Assert.AreEqual(2, actual.Count);
            Assert.AreEqual("ExampleWithList", actual.First().Name);
            Assert.AreEqual("OtherType", actual.Skip(1).First().Name);
            Assert.AreEqual(1, actual.First().Properties.Count);

            var prop = actual.First().Properties.First();
            Assert.AreEqual("OtherTypes", prop.Name);
            Assert.AreEqual(ObjectType.List, prop.ObjectDefinition.Type);
            Assert.Null(prop.ObjectDefinition.ReferenceName);
            Assert.AreEqual(ObjectType.Reference, prop.ObjectDefinition.NestedItem.Type);
            Assert.AreEqual("OtherType", prop.ObjectDefinition.NestedItem.ReferenceName);
            Assert.Null(prop.ObjectDefinition.NestedItem.NestedItem);
        }

        [TestCase]
        public static void MappingAModelContainingNullableLists()
        {
            var actual = Model.Map(typeof(ExampleWithNullableList));
            Assert.NotNull(actual);
            Assert.AreEqual(2, actual.Count);
            Assert.AreEqual("ExampleWithNullableList", actual.First().Name);
            Assert.AreEqual("OtherType", actual.Skip(1).First().Name);
            Assert.AreEqual(1, actual.First().Properties.Count);

            var prop = actual.First().Properties.First();
            Assert.AreEqual("OtherTypes", prop.Name);
            Assert.AreEqual(ObjectType.List, prop.ObjectDefinition.Type);
            Assert.Null(prop.ObjectDefinition.ReferenceName);
            Assert.AreEqual(ObjectType.Reference, prop.ObjectDefinition.NestedItem.Type);
            Assert.AreEqual("OtherType", prop.ObjectDefinition.NestedItem.ReferenceName);
            Assert.Null(prop.ObjectDefinition.NestedItem.NestedItem);
        }

        [TestCase]
        public static void MappingAModelContainingAListOfLists()
        {
            var actual = Model.Map(typeof(ExampleWithListOfLists));
            Assert.NotNull(actual);
            Assert.AreEqual(2, actual.Count);
            Assert.AreEqual("ExampleWithListOfLists", actual.First().Name);
            Assert.AreEqual("OtherType", actual.Skip(1).First().Name);
            Assert.AreEqual(1, actual.First().Properties.Count);

            var prop = actual.First().Properties.First();
            Assert.AreEqual("OtherTypes", prop.Name);
            Assert.AreEqual(ObjectType.List, prop.ObjectDefinition.Type);
            Assert.Null(prop.ObjectDefinition.ReferenceName);
            Assert.AreEqual(ObjectType.List, prop.ObjectDefinition.NestedItem.Type);
            Assert.Null(prop.ObjectDefinition.NestedItem.ReferenceName);
            Assert.AreEqual(ObjectType.Reference, prop.ObjectDefinition.NestedItem.NestedItem.Type);
            Assert.AreEqual("OtherType", prop.ObjectDefinition.NestedItem.NestedItem.ReferenceName);
            Assert.Null(prop.ObjectDefinition.NestedItem.NestedItem.NestedItem);
        }

        [TestCase]
        public static void MappingAModelContainingNullableListOfLists()
        {
            var actual = Model.Map(typeof(ExampleWithNullableListOfLists));
            Assert.NotNull(actual);
            Assert.AreEqual(2, actual.Count);
            Assert.AreEqual("ExampleWithNullableListOfLists", actual.First().Name);
            Assert.AreEqual("OtherType", actual.Skip(1).First().Name);
            Assert.AreEqual(1, actual.First().Properties.Count);

            var prop = actual.First().Properties.First();
            Assert.AreEqual("OtherTypes", prop.Name);
            Assert.AreEqual(ObjectType.List, prop.ObjectDefinition.Type);
            Assert.Null(prop.ObjectDefinition.ReferenceName);
            Assert.AreEqual(ObjectType.List, prop.ObjectDefinition.NestedItem.Type);
            Assert.Null(prop.ObjectDefinition.NestedItem.ReferenceName);
            Assert.AreEqual(ObjectType.Reference, prop.ObjectDefinition.NestedItem.NestedItem.Type);
            Assert.AreEqual("OtherType", prop.ObjectDefinition.NestedItem.NestedItem.ReferenceName);
            Assert.Null(prop.ObjectDefinition.NestedItem.NestedItem.NestedItem);
        }

        [TestCase]
        public static void MappingAModelContainingAListOfListsOfLists()
        {
            var actual = Model.Map(typeof(ExampleWithListOfListsOfLists));
            Assert.NotNull(actual);
            Assert.AreEqual(2, actual.Count);
            Assert.AreEqual("ExampleWithListOfListsOfLists", actual.First().Name);
            Assert.AreEqual("OtherType", actual.Skip(1).First().Name);
            Assert.AreEqual(1, actual.First().Properties.Count);

            var prop = actual.First().Properties.First();
            Assert.AreEqual("OtherTypes", prop.Name);
            Assert.AreEqual(ObjectType.List, prop.ObjectDefinition.Type);
            Assert.Null(prop.ObjectDefinition.ReferenceName);
            Assert.AreEqual(ObjectType.List, prop.ObjectDefinition.NestedItem.Type);
            Assert.Null(prop.ObjectDefinition.NestedItem.ReferenceName);

            Assert.AreEqual(ObjectType.List, prop.ObjectDefinition.NestedItem.NestedItem.Type);
            Assert.Null(prop.ObjectDefinition.NestedItem.NestedItem.ReferenceName);

            Assert.AreEqual(ObjectType.Reference, prop.ObjectDefinition.NestedItem.NestedItem.NestedItem.Type);
            Assert.AreEqual("OtherType", prop.ObjectDefinition.NestedItem.NestedItem.NestedItem.ReferenceName);
            Assert.Null(prop.ObjectDefinition.NestedItem.NestedItem.NestedItem.NestedItem);
        }

        [TestCase]
        public static void MappingAModelContainingNullableListOfListsOfLists()
        {
            var actual = Model.Map(typeof(ExampleWithNullableListOfListsOfLists));
            Assert.NotNull(actual);
            Assert.AreEqual(2, actual.Count);
            Assert.AreEqual("ExampleWithNullableListOfListsOfLists", actual.First().Name);
            Assert.AreEqual("OtherType", actual.Skip(1).First().Name);
            Assert.AreEqual(1, actual.First().Properties.Count);

            var prop = actual.First().Properties.First();
            Assert.AreEqual("OtherTypes", prop.Name);
            Assert.AreEqual(ObjectType.List, prop.ObjectDefinition.Type);
            Assert.Null(prop.ObjectDefinition.ReferenceName);
            Assert.AreEqual(ObjectType.List, prop.ObjectDefinition.NestedItem.Type);
            Assert.Null(prop.ObjectDefinition.NestedItem.ReferenceName);

            Assert.AreEqual(ObjectType.List, prop.ObjectDefinition.NestedItem.NestedItem.Type);
            Assert.Null(prop.ObjectDefinition.NestedItem.NestedItem.ReferenceName);

            Assert.AreEqual(ObjectType.Reference, prop.ObjectDefinition.NestedItem.NestedItem.NestedItem.Type);
            Assert.AreEqual("OtherType", prop.ObjectDefinition.NestedItem.NestedItem.NestedItem.ReferenceName);
            Assert.Null(prop.ObjectDefinition.NestedItem.NestedItem.NestedItem.NestedItem);
        }

        [TestCase]
        public static void TestMapModel()
        {
            var actual = Model.Map(typeof(Example));
            Assert.NotNull(actual);
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual("Example", actual.First().Name);
            Assert.AreEqual(3, actual.First().Properties.Count);

            foreach (var property in actual.First().Properties)
            {
                switch (property.Name)
                {
                    case "First":
                        {
                            Assert.AreEqual("first", property.JsonName);
                            Assert.AreEqual(ObjectType.Boolean, property.ObjectDefinition.Type);
                            Assert.AreEqual(true, property.Required);
                            continue;
                        }

                    case "Second":
                        {
                            Assert.AreEqual("second", property.JsonName);
                            Assert.AreEqual(ObjectType.String, property.ObjectDefinition.Type);
                            Assert.AreEqual(true, property.Optional);
                            continue;
                        }

                    case "Random":
                        {
                            Assert.AreEqual("barrelRoll", property.JsonName);
                            Assert.AreEqual(ObjectType.String, property.ObjectDefinition.Type);
                            Assert.AreEqual(true, property.Optional);
                            Assert.AreEqual("do a", property.Default);
                            continue;
                        }

                    default:
                        {
                            Assert.Fail($"unexpected property {property.Name}");
                            return;
                        }
                }
            }
        }

        [TestCase]
        public static void TestMappingAModelContainingANullableConstant()
        {
            var actual = Model.Map(typeof(QuotaModel));
            Assert.NotNull(actual);
            Assert.AreEqual(1, actual.Count);

            var quota = actual.FirstOrDefault(m => m.Name == "Quota");
            Assert.AreEqual(2, quota.Properties.Count);
        }

        [TestCase]
        public static void TestMapNestedModels()
        {
            var actual = Model.Map(typeof(NestedWrapper));
            Assert.NotNull(actual);
            Assert.AreEqual(3, actual.Count);

            // First
            Assert.AreEqual("First", actual.First().Name);
            Assert.AreEqual(1, actual.First().Properties.Count);
            Assert.AreEqual("Field", actual.First().Properties.First().Name);

            // NestedWrapper
            Assert.AreEqual("NestedWrapper", actual.Skip(1).First().Name);
            Assert.AreEqual(2, actual.Skip(1).First().Properties.Count);
            Assert.AreEqual("First", actual.Skip(1).First().Properties.First().Name);
            Assert.AreEqual(ObjectType.Reference, actual.Skip(1).First().Properties.First().ObjectDefinition.Type);
            Assert.AreEqual("First", actual.Skip(1).First().Properties.First().ObjectDefinition.ReferenceName);
            Assert.AreEqual("Second", actual.Skip(1).First().Properties.Skip(1).First().Name);
            Assert.AreEqual(ObjectType.Reference, actual.Skip(1).First().Properties.Skip(1).First().ObjectDefinition.Type);
            Assert.AreEqual("Second", actual.Skip(1).First().Properties.Skip(1).First().ObjectDefinition.ReferenceName);

            // Second
            Assert.AreEqual("Second", actual.Skip(2).First().Name);
            Assert.AreEqual(1, actual.Skip(2).First().Properties.Count);
        }

        [TestCase]
        public static void TestMapDuplicateModels()
        {
            var actual = Model.Map(typeof(DuplicateWrapper));
            Assert.NotNull(actual);
            Assert.AreEqual(2, actual.Count);

            // DuplicateWrapper
            Assert.AreEqual("DuplicateWrapper", actual.First().Name);
            Assert.AreEqual(2, actual.First().Properties.Count);

            var firstProp = actual.First().Properties.First();
            Assert.AreEqual("First", firstProp.Name);
            Assert.AreEqual(ObjectType.Reference, firstProp.ObjectDefinition.Type);
            Assert.AreEqual("First", firstProp.ObjectDefinition.ReferenceName);
            var secondProp = actual.First().Properties.Skip(1).First();
            Assert.AreEqual("Second", secondProp.Name);
            Assert.AreEqual(ObjectType.Reference, secondProp.ObjectDefinition.Type);
            Assert.AreEqual("First", secondProp.ObjectDefinition.ReferenceName);

            // First
            Assert.AreEqual("First", actual.Skip(1).First().Name);
            Assert.AreEqual(1, actual.Skip(1).First().Properties.Count);
            Assert.AreEqual("Field", actual.Skip(1).First().Properties.First().Name);
        }

        [Test]
        public static void TestMappingDiscriminatedTypes()
        {
            var actual = Model.Map(typeof(AnimalsWrapper));
            Assert.NotNull(actual);
            Assert.AreEqual(4, actual.Count);

            var wrapper = actual.FirstOrDefault(t => t.Name == "AnimalsWrapper");
            Assert.NotNull(wrapper);
            Assert.AreEqual(2, wrapper.Properties.Count);
            Assert.Null(wrapper.ParentTypeName);
            Assert.Null(wrapper.TypeHintIn);
            Assert.Null(wrapper.TypeHintValue);

            var animal = actual.FirstOrDefault(t => t.Name == "Animal");
            Assert.NotNull(animal);
            Assert.AreEqual(1, animal.Properties.Count);
            Assert.Null(animal.ParentTypeName);
            Assert.AreEqual("ObjectType", animal.TypeHintIn);
            Assert.Null(animal.TypeHintValue);

            var cat = actual.FirstOrDefault(t => t.Name == "Cat");
            Assert.NotNull(cat);
            Assert.AreEqual(2, cat.Properties.Count);
            Assert.AreEqual("Animal", cat.ParentTypeName);
            Assert.AreEqual("ObjectType", cat.TypeHintIn);
            Assert.AreEqual("cat", cat.TypeHintValue);

            var dog = actual.FirstOrDefault(t => t.Name == "Dog");
            Assert.NotNull(dog);
            Assert.AreEqual(1, dog.Properties.Count);
            Assert.AreEqual("Animal", dog.ParentTypeName);
            Assert.AreEqual("ObjectType", dog.TypeHintIn);
            Assert.AreEqual("dog", dog.TypeHintValue);
        }

        [Test]
        public static void TestMappingDiscriminatedTypesContainingAnotherType()
        {
            // This asserts that when we pull out the discriminated type, that only the discriminated
            // types contain a reference to the parent type
            var actual = Model.Map(typeof(AnimalsWithBoneWrapper));
            Assert.NotNull(actual);
            Assert.AreEqual(5, actual.Count);

            var wrapper = actual.FirstOrDefault(t => t.Name == "AnimalsWithBoneWrapper");
            Assert.NotNull(wrapper);
            Assert.AreEqual(2, wrapper.Properties.Count);
            Assert.Null(wrapper.ParentTypeName);
            Assert.Null(wrapper.TypeHintIn);
            Assert.Null(wrapper.TypeHintValue);

            var animal = actual.FirstOrDefault(t => t.Name == "Animal2");
            Assert.NotNull(animal);
            Assert.AreEqual(1, animal.Properties.Count);
            Assert.Null(animal.ParentTypeName);
            Assert.AreEqual("ObjectType", animal.TypeHintIn);
            Assert.Null(animal.TypeHintValue);

            var cat = actual.FirstOrDefault(t => t.Name == "Cat2");
            Assert.NotNull(cat);
            Assert.AreEqual(2, cat.Properties.Count);
            Assert.AreEqual("Animal2", cat.ParentTypeName);
            Assert.AreEqual("ObjectType", cat.TypeHintIn);
            Assert.AreEqual("cat", cat.TypeHintValue);

            var dog = actual.FirstOrDefault(t => t.Name == "Dog2");
            Assert.NotNull(dog);
            Assert.AreEqual(2, dog.Properties.Count);
            Assert.AreEqual("Animal2", dog.ParentTypeName);
            Assert.AreEqual("ObjectType", dog.TypeHintIn);
            Assert.AreEqual("dog", dog.TypeHintValue);

            var bone = actual.FirstOrDefault(t => t.Name == "Bone");
            Assert.NotNull(bone);
            Assert.AreEqual(1, bone.Properties.Count);
            Assert.Null(bone.ParentTypeName);
            Assert.Null(bone.TypeHintIn);
            Assert.Null(bone.TypeHintValue);
        }

        [Test]
        public static void TestMappingAModelContainingACircularReference()
        {
            var actual = Model.Map(typeof(HumanWithCircularReference));
            Assert.NotNull(actual);
            Assert.AreEqual(2, actual.Count);

            var human = actual.FirstOrDefault(t => t.Name == "HumanWithCircularReference");
            Assert.NotNull(human);
            Assert.AreEqual(2, human.Properties.Count);
            Assert.Null(human.ParentTypeName);
            Assert.Null(human.TypeHintIn);
            Assert.Null(human.TypeHintValue);
            var nameField = human.Properties.FirstOrDefault(p => p.Name == "Name");
            Assert.NotNull(nameField);
            Assert.AreEqual(ObjectType.String, nameField.ObjectDefinition.Type);
            var animalField = human.Properties.FirstOrDefault(p => p.Name == "FavouriteAnimal");
            Assert.NotNull(animalField);
            Assert.AreEqual(ObjectType.Reference, animalField.ObjectDefinition.Type);
            Assert.AreEqual("AnimalWithCircularReference", animalField.ObjectDefinition.ReferenceName);

            var animal = actual.FirstOrDefault(t => t.Name == "AnimalWithCircularReference");
            Assert.NotNull(animal);
            Assert.AreEqual(2, animal.Properties.Count);
            Assert.Null(animal.ParentTypeName);
            Assert.Null(animal.TypeHintIn);
            Assert.Null(animal.TypeHintValue);
            nameField = animal.Properties.FirstOrDefault(p => p.Name == "Name");
            Assert.NotNull(nameField);
            Assert.AreEqual(ObjectType.String, nameField.ObjectDefinition.Type);
            var humanField = animal.Properties.FirstOrDefault(p => p.Name == "FavouriteHuman");
            Assert.NotNull(humanField);
            Assert.AreEqual(ObjectType.Reference, humanField.ObjectDefinition.Type);
            Assert.AreEqual("HumanWithCircularReference", humanField.ObjectDefinition.ReferenceName);
        }

        private class Example
        {
            [JsonPropertyName("first")]
            [Required]
            public bool First { get; set; }

            [JsonPropertyName("second")]
            [Optional]
            public string Second { get; set; }

            [JsonPropertyName("barrelRoll")]
            [Optional(DefaultValue = "do a")]
            public string Random { get; set; }
        }

        private class ExampleWithList
        {
            [JsonPropertyName("otherTypes")]
            public List<OtherType> OtherTypes { get; set; }
        }

        private class ExampleWithNullableList
        {
            [JsonPropertyName("otherTypes")]
            public List<OtherType>? OtherTypes { get; set; }
        }

        private class ExampleWithListOfLists
        {
            [JsonPropertyName("otherTypes")]
            public List<List<OtherType>> OtherTypes { get; set; }
        }

        private class ExampleWithNullableListOfLists
        {
            [JsonPropertyName("otherTypes")]
            public List<List<OtherType>>? OtherTypes { get; set; }
        }

        private class ExampleWithListOfListsOfLists
        {
            [JsonPropertyName("otherTypes")]
            public List<List<List<OtherType>>> OtherTypes { get; set; }
        }

        private class ExampleWithNullableListOfListsOfLists
        {
            [JsonPropertyName("otherTypes")]
            public List<List<List<OtherType>>>? OtherTypes { get; set; }
        }

        private class OtherType
        {
            [JsonPropertyName("hello")]
            public bool Hello { get; set; }
        }

        private class DuplicateWrapper
        {
            [JsonPropertyName("first")]
            public First First { get; set; }

            [JsonPropertyName("second")]
            public First Second { get; set; }
        }

        private class NestedWrapper
        {
            [JsonPropertyName("first")]
            public First First { get; set; }

            [JsonPropertyName("second")]
            public Second Second { get; set; }
        }

        private class First
        {
            [JsonPropertyName("field")]
            [Optional]
            public bool Field { get; set; }
        }

        private class Second
        {
            [JsonPropertyName("field")]
            [Optional]
            public bool Field { get; set; }
        }

        private class AnimalsWrapper
        {
            [JsonPropertyName("animal")]
            public Animal Animal { get; set; }

            [JsonPropertyName("animals")]
            public List<Animal> Animals { get; set; }
        }

        private abstract class Animal
        {
            [JsonPropertyName("objectType")]
            [ProvidesTypeHint]
            public string ObjectType { get; set; }
        }

        [ValueForType("cat")]
        private class Cat : Animal
        {
            [JsonPropertyName("jumps")]
            public bool Jumps { get; set; }
        }

        [ValueForType("dog")]
        private class Dog : Animal
        {
        }

        public class AnimalsWithBoneWrapper
        {
            [JsonPropertyName("animal")]
            public Animal2 Animal { get; set; }

            [JsonPropertyName("animals")]
            public List<Animal2> Animals { get; set; }
        }

        public abstract class Animal2
        {
            [JsonPropertyName("objectType")]
            [ProvidesTypeHint]
            public string ObjectType { get; set; }
        }

        [ValueForType("cat")]
        public class Cat2 : Animal2
        {
            [JsonPropertyName("jumps")]
            public bool Jumps { get; set; }
        }

        [ValueForType("dog")]
        public class Dog2 : Animal2
        {
            [JsonPropertyName("bone")]
            public Bone Bone { get; set; }
        }

        public class Bone
        {
            [JsonPropertyName("location")]
            public string Location { get; set; }
        }

        public class HumanWithCircularReference
        {
            [JsonPropertyName("favouriteAnimal")]
            public AnimalWithCircularReference FavouriteAnimal { get; set; }

            [JsonPropertyName("name")]
            public string Name { get; set; }
        }

        public class AnimalWithCircularReference
        {
            [JsonPropertyName("favouriteHuman")]
            public HumanWithCircularReference FavouriteHuman { get; set; }

            [JsonPropertyName("name")]
            public string Name { get; set; }
        }

        internal class QuotaModel
        {
            [JsonPropertyName("hostsRemaining")]
            public Dictionary<string, int>? HostsRemaining { get; set; }

            [JsonPropertyName("quotaEnabled")]
            public QuotaEnabledConstant? QuotaEnabled { get; set; }
        }

        [ConstantType(ConstantTypeAttribute.ConstantType.String)]
        internal enum QuotaEnabledConstant
        {
            [System.ComponentModel.Description("Disabled")]
            Disabled,

            [System.ComponentModel.Description("Enabled")]
            Enabled,
        }
    }

    public class ExampleWithSuffixesModel
    {
        [JsonPropertyName("bool")]
        public bool Bool { get; set; }

        [JsonPropertyName("int")]
        public int Int { get; set; }

        [JsonPropertyName("secondProp")]
        public SecondModel SecondProp { get; set; }

        [JsonPropertyName("string")]
        public string String { get; set; }
    }

    public class SecondModel
    {
        [JsonPropertyName("field")]
        [Optional]
        public bool Field { get; set; }
    }

    public class ExampleWithSelfReferences
    {
        [JsonPropertyName("listOfReferences")]
        public List<ExampleWithSelfReferences> ListOfReferences { get; set; }

        [JsonPropertyName("nilableListOfReferences")]
        public List<ExampleWithSelfReferences>? NilableListOfReferences { get; set; }

        [JsonPropertyName("nilableSelfReference")]
        public ExampleWithSelfReferences? NilableSelfReference { get; set; }

        [JsonPropertyName("selfReference")]
        public ExampleWithSelfReferences SelfReference { get; set; }
    }
}