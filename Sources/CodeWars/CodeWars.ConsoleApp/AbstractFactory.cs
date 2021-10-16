using System;

namespace CodeWars.ConsoleApp
{
    public class AnimalWorld
    {
        private readonly Herbivore _herbivore;
        private readonly Carnivore _carnivore;

        public AnimalWorld(ContinentFactory continentFactory)
        {
            _herbivore = continentFactory.CreateHerbivore();
            _carnivore = continentFactory.CreateCarnivore();
        }
        
        public void RunFoodChain()
        {
            _carnivore.Eat(_herbivore);
        }
    }

    public class AfricaFactory : ContinentFactory
    {
        public override Herbivore CreateHerbivore()
        {
            return new Wildebeest();
        }
        public override Carnivore CreateCarnivore()
        {
            return new Lion();
        }
    }
 
    /// <summary>
    /// The 'ConcreteFactory2' class
    /// </summary>
    public class AmericaFactory : ContinentFactory
    {
        public override Herbivore CreateHerbivore()
        {
            return new Bison();
        }
        public override Carnivore CreateCarnivore()
        {
            return new Wolf();
        }
    }
 
    /// <summary>
    /// The 'AbstractProductA' abstract class
    /// </summary>
    public abstract class Herbivore
    {
    }
 
    /// <summary>
    /// The 'AbstractProductB' abstract class
    /// </summary>
    public abstract class Carnivore
    {
        public abstract void Eat(Herbivore h);
    }
 
    /// <summary>
    /// The 'ProductA1' class
    /// </summary>
    public class Wildebeest : Herbivore
    {
    }
 
    /// <summary>
    /// The 'ProductB1' class
    /// </summary>
    public class Lion : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            // Eat Wildebeest
            Console.WriteLine(this.GetType().Name +
                              " eats " + h.GetType().Name);
        }
    }
 
    /// <summary>
    /// The 'ProductA2' class
    /// </summary>
    public class Bison : Herbivore
    {
    }
 
    /// <summary>
    /// The 'ProductB2' class
    /// </summary>
    public class Wolf : Carnivore
    {
        public override void Eat(Herbivore h)
        {
            // Eat Bison
            Console.WriteLine(this.GetType().Name +
                              " eats " + h.GetType().Name);
        }
    }

    public abstract class ContinentFactory
    {
        public abstract Herbivore CreateHerbivore();
        public abstract Carnivore CreateCarnivore();
    }
}