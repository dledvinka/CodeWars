using CodeWars.ConsoleApp;
using NUnit.Framework;

namespace CodeWars.Tests
{
    [TestFixture]
    public class CanYouGetTheLoopTests {
        [Test]
        public  void FourNodesWithLoopSize3(){
            var n1 = LoopFactory.CreateNode(0);
            var n2 = LoopFactory.CreateNode(1);
            var n3 = LoopFactory.CreateNode(2);
            var n4 = LoopFactory.CreateNode(3);
            n1.Next = n2;
            n2.Next = n3;
            n3.Next = n4;
            n4.Next = n2;
            Assert.AreEqual(3,CanYouGetTheLoop.GetLoopSize(n1));
        }
        
        [Test]
        public  void RandomChainNodesWithLoopSize3(){
            var n1 = LoopFactory.CreateChain(1,3);
            Assert.AreEqual(3,CanYouGetTheLoop.GetLoopSize(n1));
        }
  
        [Test]
        public  void RandomChainNodesWithLoopSize30(){
            var n1 = LoopFactory.CreateChain(3,30);
            Assert.AreEqual(30,CanYouGetTheLoop.GetLoopSize(n1));
        }
  
        [Test]
        public  void RandomLongChainNodesWithLoopSize1087(){
            var n1 = LoopFactory.CreateChain(3904,1087);
            Assert.AreEqual(1087,CanYouGetTheLoop.GetLoopSize(n1));
        }
    }
}