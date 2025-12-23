using System;
using System.Xml.Serialization;

namespace AnimalLibrary
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum |
                   AttributeTargets.Struct | AttributeTargets.Method |
                   AttributeTargets.Property
                   )]

    public class CommentAttribute : Attribute
    {
        public string Comment { get; }

        public CommentAttribute(string comment)
        {
            Comment = comment;
        }
    }

    [Comment("Classification animals by nutrition")]
    public enum eClassificationAnimal
    {
        Herbivores,
        Carnivores,
        Omnivores
    }

    [Comment("Classification by favorite food")]
    public enum eFavoriteFood
    {
        Meat,
        Plants,
        Everything
    }

    [Serializable]
    [XmlInclude(typeof(Cow))]
    [XmlInclude(typeof(Lion))]
    [XmlInclude(typeof(Pig))]
    [Comment("Abstract class of animals")]
    public abstract class Animal
    {
        [Comment("Animal country")]
        public string Country { get; set; }

        [Comment("Animal name")]
        public string Name { get; set; }

        [Comment("Hiding or not")]
        public bool HideFromOtherAnimals { get; set; }

        [Comment("Animal classification")]
        public eClassificationAnimal WhatAnimal { get; set; }

        public Animal()
        {
            Country = "";
            Name = "";
            HideFromOtherAnimals = false;
        }

        public Animal(string country = "", string name = "", bool hideFromOtherAnimals = false)
        {
            Country = country;
            Name = name;
            HideFromOtherAnimals = hideFromOtherAnimals;
        }

        public void Deconstruct(out string country, out string name, out bool hideFromOtherAnimals, out eClassificationAnimal whatAnimal)
        {
            country = Country;
            name = Name;
            hideFromOtherAnimals = HideFromOtherAnimals;
            whatAnimal = WhatAnimal;
        }

        public eClassificationAnimal GetClassificationAnimal()
        {
            return WhatAnimal;
        }
        public abstract eFavoriteFood GetFavoriteFood();

        public abstract void SayHello();
    }

    [Comment("Cow class")]
    public class Cow : Animal
    {
        public Cow() : this("", "", false) { }

        public Cow(string country = "", string name = "", bool hideFromOtherAnimals = false) : base(country, name, hideFromOtherAnimals)
        {
            WhatAnimal = eClassificationAnimal.Herbivores;
        }

        [Comment("Get favirite food")]
        public override eFavoriteFood GetFavoriteFood()
        {
            return eFavoriteFood.Plants;
        }

        [Comment("'Say Hello' method")]
        public override void SayHello()
        {
            Console.WriteLine("Муууу");
        }
    }

    [Comment("Lion class")]
    public class Lion : Animal
    {
        public Lion() : this("", "", false) { }
        public Lion(string country = "", string name = "", bool hideFromOtherAnimals = false) : base(country, name, hideFromOtherAnimals)
        {
            WhatAnimal = eClassificationAnimal.Carnivores;
        }

        [Comment("Get favirite food")]
        public override eFavoriteFood GetFavoriteFood()
        {
            return eFavoriteFood.Meat;
        }

        [Comment("'Say Hello' method")]
        public override void SayHello()
        {
            Console.WriteLine("Ррррр");
        }
    }

    [Comment("Pig class")]
    public class Pig : Animal
    {
        public Pig() : this("", "", false) { }

        public Pig(string country = "", string name = "", bool hideFromOtherAnimals = false) : base(country, name, hideFromOtherAnimals)
        {
            WhatAnimal = eClassificationAnimal.Omnivores;
        }

        [Comment("Get favirite food")]
        public override eFavoriteFood GetFavoriteFood()
        {
            return eFavoriteFood.Everything;
        }

        [Comment("'Say Hello' method")]
        public override void SayHello()
        {
            Console.WriteLine("Хрю хрю");
        }
    }
}