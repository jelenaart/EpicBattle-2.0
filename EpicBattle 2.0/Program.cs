using System;
using System.IO;

namespace epicBattle
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] heroes = { "Harry Poter", "Superman", "Luke Skywalker", "Lara Croft" };
            //string[] villains = { "Voldemort", "Joker", "Venom ", "Darth Vader", "Cruela" };

            string folderPath = @"C:\Users\opilane\samples\";
            string[] heroes = GetDataFromFile(folderPath + "heroes.txt");
            string[] villains = GetDataFromFile(folderPath + "villains.txt");
            string[] weapon = GetDataFromFile(folderPath + "weapons.txt");
            string[] armor = GetDataFromFile(folderPath + "armor.txt");

            string randomHero = GetRandomElement(heroes);
            string randomVillain = GetRandomElement(villains);
            string heroWeapon = GetRandomElement(weapon);
            string villainWeapon = GetRandomElement(weapon);
            string heroArmor = GetRandomElement(armor);
            string villainArmor = GetRandomElement(armor);
            Console.WriteLine($"Your random hero is:{randomHero} in {heroArmor}");
            Console.WriteLine($"Your random villian is:{randomVillain} in {villainArmor}");
            Console.WriteLine($"heroes random weapon is:{heroWeapon}");
            Console.WriteLine($"villians random weapon is:{villainWeapon}");
           

            int heroHP = GenerateHP(heroArmor);
            int villainHP = GenerateHP(heroArmor);
            Console.WriteLine($":{randomHero} HP:{heroHP}");
            Console.WriteLine($":{randomVillain} HP:{villainHP}");

            while (heroHP >=0 && villainHP >=0)
            {
                heroHP = heroHP - Hit(randomVillain, villainWeapon);
                villainHP = villainHP - Hit(randomHero, heroWeapon);
            }

            if (heroHP > villainHP)
            {
                Console.WriteLine($"{randomHero} saves the day!");
            } else if(heroHP<villainHP)
            {
                Console.WriteLine($"Dark side wins!");
            } else
            {
                Console.WriteLine($"Someday {randomHero} shall fight {randomVillain} again!");
            }

        }

        public static string GetRandomElement(string[] someArray)
        {
            Random rnd = new Random();
            int randomIndex = rnd.Next(0, someArray.Length);
            string randomCharacter = someArray[randomIndex];
            return randomCharacter;
        }

        public static string[] GetDataFromFile(string filePath)
        {
            string[] dataFromFile = File.ReadAllLines(filePath);
            return dataFromFile;
        }

        public static int GenerateHP(string armor)
        
        {
            int characterHP = armor.Length;
            return characterHP;
        }

        public static int Hit(string character, string weapon)
        {
            Random rnd = new Random();
            int strike = rnd.Next(0, weapon.Length - 2);
            Console.WriteLine($"{character} hit {strike}");
            
            if(strike == weapon.Length - 2)
            {
                Console.WriteLine($"Awesome! {character} made a critical hit!");
            } else if (strike == 0)
            {
                Console.WriteLine($"Bad luck! {character} missed the target!");
            }


            return strike;
            //weaponLength - 2
        }



    }
}