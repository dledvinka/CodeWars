using CodeWars.ConsoleApp;
using NUnit.Framework;

namespace CodeWars.Tests
{
    [TestFixture]
    public class AbstractFactoryTests
    {
        [Test]
        public void Test()
        {
            var africaFactory = new AfricaFactory();
            
            var animalWorld = new AnimalWorld(africaFactory);
            animalWorld.RunFoodChain();
        }
        
        [Test]
        public void TestAmerica()
        {
            var americaFactory = new AmericaFactory();
            
            var animalWorld = new AnimalWorld(americaFactory);
            animalWorld.RunFoodChain();
        }
    }
}