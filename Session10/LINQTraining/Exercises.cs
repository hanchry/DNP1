using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using DataGenerator.Generator;
using LINQTraining.DataAccess;
using LINQTraining.Generator;
using Microsoft.EntityFrameworkCore;
using Models;
using NUnit.Framework;
using static LINQTraining.PrintUtil.Printer;

namespace LINQTraining
{
    [TestFixture]
    public class Exercises
    {
        /**
         * Intro text
         * In this exercise you are supposed to solve all questions using only the ctx.Families entry point to the database.
         * That means if you use e.g. ctx.Set<Child>()... you are taking an unintended shortcut.
         *
         * All questions can be answered with one statement. Though, if you're stuck you may find it easier to break it down
         * into multiple consecutive statements.
         *
         * Again, you have access to the PrettyPrint method. In this case however, it's a bit limited, because it cannot print
         * out nested objects. E.g. a Family have Adults, but that will not be printed out in a neat way.
         *
         * All questions have the correct answer above them in a comment
         */
        protected FamilyContext ctx;

        [SetUp]
        public virtual void Setup()
        {
            ctx = new FamilyContext();
        }

        /*
         [Test]
          public virtual void CreateAndSeed()
          {
              IList<Family> families = new FamilyGenerator().GenerateFamilies(500);
              string famSerialized = JsonSerializer.Serialize(families, new JsonSerializerOptions
              {
                  WriteIndented = true
              });
              DBSeeder.Seed(families);
          }*/

        // example
        [Test]
        public virtual void NumberOfAdults()
        {
            List<Adult> adults = ctx.Families.SelectMany(family => family.Adults).ToList();
            int numOfAdults = adults.Count();
            Console.WriteLine(numOfAdults);
            //PrettyPrint(adults);
        }

        // example
        [Test]
        public virtual void DisplayRedHairedAdultsBetween37And53()
        {
            List<Adult> adults = ctx.Families.SelectMany(family => family.Adults).Where(adult =>
                adult.HairColor.Equals("Red") &&
                adult.Age >= 37 &&
                adult.Age <= 53
            ).ToList();
            PrettyPrint(adults);
        }


        // answer: 5
        [Test]
        public virtual void HowManyFamiliesLiveAt()
        {
            List<Family> families = ctx.Families.Where(c => c.StreetName.Equals("Abby Park Street")).ToList();
            Console.WriteLine(families.Count);
            PrettyPrint(families);
            // street "Abby Park Street"
        }


        // answer 151
        [Test]
        public virtual void HowManyFamiliesHaveOneParent()
        {
            // we are looking for the number families, which have exactly one parent.
            List<Family> families = ctx.Families.Where(c => c.Adults.Count == 1).ToList();
            Console.WriteLine(families.Count);
            PrettyPrint(families);
        }

        // answer: 123
        [Test]
        public virtual void HowManyFamiliesLiveInNumberThreeOrFive()
        {
            List<Family> families = ctx.Families.Where(c => c.HouseNumber == 3 || c.HouseNumber == 5).ToList();
            Console.WriteLine(families.Count);
            PrettyPrint(families);
        }


        // answer: 94
        [Test]
        public virtual void HowManyFamiliesHaveADog()
        {
            // one or more dogs
            List<Family> families = ctx.Families.Where(c => c.Pets.Where(x => x.Species.Equals("Dog")).Count() > 0)
                .ToList();
            Console.WriteLine(families.Count);
            PrettyPrint(families);
        }

        // answer: 18
        [Test]
        public virtual void HowManyFamiliesHaveCatAndDog()
        {
            List<Family> families = ctx.Families.Where(c =>
                c.Pets.Any(d => d.Species.Equals("Dog")) && c.Pets.Any(d => d.Species.Equals("Cat"))).ToList();
            Console.WriteLine(families.Count);
            PrettyPrint(families);
        }


        // answer 125
        [Test]
        public virtual void HowManyFamiliesHave3Children()
        {
            List<Family> families = ctx.Families.Where(x => x.Children.Count == 3).ToList();
            Console.WriteLine(families.Count);
            PrettyPrint(families);
        }

        // answer: 175
        [Test]
        public virtual void How_Many_Families_Have_Gay_Parents()
        {
            List<Family> families = ctx.Families.Where(x => x.Adults.Count == 2).Where(f =>
                f.Adults.Count(adult => adult.Sex.Equals("F")) == 2 ||
                f.Adults.Count(adult => adult.Sex.Equals("M")) == 2).ToList();
            Console.WriteLine(families.Count);
            PrettyPrint(families);
        }


        // answer 21
        [Test]
        public virtual void How_Many_Families_Have_An_Adult_With_Red_Hair()
        {
            List<Family> families =
                ctx.Families.Where(x => x.Adults.Any(adult => adult.HairColor.Equals("Red"))).ToList();
            Console.WriteLine(families.Count);
            PrettyPrint(families);
        }


        // answer: 26
        [Test]
        public virtual void How_Many_Families_Have_2_Pets()
        {
            List<Family> families = ctx.Families.Where(x => x.Pets.Count == 2).ToList();
            Console.WriteLine(families.Count);
            PrettyPrint(families);
        }


        // answer: 81
        [Test]
        public virtual void How_Many_Families_Have_A_Child_Playing_Soccer()
        {
            List<Family> families = ctx.Families
                .Where(x => x.Children.Any(child => child.Interests.Any(i => i.Type.Equals("Soccer")))).ToList();
            Console.WriteLine(families.Count);
            PrettyPrint(families);
        }

        // answer: 355
        [Test]
        public virtual void How_Many_Families_Have_Adult_And_Child_With_Black_Hair()
        {
            List<Family> families = ctx.Families.Where(x =>
                    x.Adults.Any(a => a.HairColor.Equals("Black")) &&
                    x.Children.Any(ch => ch.HairColor.Equals("Black")))
                .ToList();
            Console.WriteLine(families.Count);
            PrettyPrint(families);
        }


        // answer: 47
        [Test]
        public virtual void How_Many_Families_Have_A_Child_With_Black_Hair_Playing_Ultimate()
        {
            List<Family> families = ctx.Families.Where(x =>
                    x.Children.Any(ch =>
                        ch.HairColor.Equals("Black") && ch.Interests.Any(i => i.Type.Equals("Ultimate"))))
                .ToList();
            Console.WriteLine(families.Count);
            PrettyPrint(families);
        }


        // answer: 172
        [Test]
        public virtual void HowManyFamiliesHaveTwoAdultsWithSameHairColor()
        {
            List<Family> families = ctx.Families.Where(family =>
                family.Adults.Count == 2 &&
                family.Adults.Count(adult => adult.HairColor.Equals(family.Adults.First().HairColor)) == 2).ToList();
            Console.WriteLine(families.Count);
            PrettyPrint(families);
        }

        // answer: 90
        [Test]
        public virtual void HowManyFamiliesHaveAChildWithAHamster()
        {
            List<Family> families = ctx.Families.Where(family =>
                family.Children.Any(child => child.Pets.Any(pet => pet.Species.Equals("Hamster")))).ToList();
            Console.WriteLine(families.Count);
            PrettyPrint(families);
        }


        // Answer: 5
        [Test]
        public virtual void HowManyChildrenAreInterestedInBothSoccerAndBarbies()
        {
            List<Family> families = ctx.Families.Where(f => f.Children.Any(ch =>
                    ch.Interests.Any(i => i.Type.Equals("Barbie")) && ch.Interests.Any(i => i.Type.Equals("Soccer"))))
                .ToList();
            Console.WriteLine(families.Count);
            PrettyPrint(families);
        }


        // answer 157
        [Test]
        public virtual void HowManyChildrenAreOfHeightBetween95And112()
        {
            List<Child> families = ctx.Families.SelectMany(f => f.Children.Where(ch =>
                    ch.Height > 94 && ch.Height < 113))
                .ToList();
            Console.WriteLine(families.Count);
            PrettyPrint(families);
        }
    }
}