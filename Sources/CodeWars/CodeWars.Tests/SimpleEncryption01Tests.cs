using CodeWars.ConsoleApp;
using NUnit.Framework;

namespace CodeWars.Tests
{
    public class SimpleEncryption01Tests
    {
        [Test]
        public void EncryptExampleTests()
        {
            Assert.AreEqual("This is a test!", SimpleEncryption01.Encrypt("This is a test!", 0));
            Assert.AreEqual("hsi  etTi sats!", SimpleEncryption01.Encrypt("This is a test!", 1));
            Assert.AreEqual("s eT ashi tist!", SimpleEncryption01.Encrypt("This is a test!", 2));
            Assert.AreEqual(" Tah itse sits!", SimpleEncryption01.Encrypt("This is a test!", 3));
            Assert.AreEqual("This is a test!", SimpleEncryption01.Encrypt("This is a test!", 4));
            Assert.AreEqual("This is a test!", SimpleEncryption01.Encrypt("This is a test!", -1));
            Assert.AreEqual("hskt svr neetn!Ti aai eyitrsig", SimpleEncryption01.Encrypt("This kata is very interesting!", 1));
            
        }
  
        [Test]
        public void DecryptExampleTests()
        {
            Assert.AreEqual("This is a test!", SimpleEncryption01.Decrypt("This is a test!", 0));
            Assert.AreEqual("This is a test!", SimpleEncryption01.Decrypt("hsi  etTi sats!", 1));
            Assert.AreEqual("This is a test!", SimpleEncryption01.Decrypt("s eT ashi tist!", 2));
            Assert.AreEqual("This is a test!", SimpleEncryption01.Decrypt(" Tah itse sits!", 3));
            Assert.AreEqual("This is a test!", SimpleEncryption01.Decrypt("This is a test!", 4));
            Assert.AreEqual("This is a test!", SimpleEncryption01.Decrypt("This is a test!", -1));
            Assert.AreEqual("This kata is very interesting!", SimpleEncryption01.Decrypt("hskt svr neetn!Ti aai eyitrsig", 1));
        }
  
        [Test]
        public void EmptyTests()
        {
            Assert.AreEqual("", SimpleEncryption01.Encrypt("", 0));
            Assert.AreEqual("", SimpleEncryption01.Decrypt("", 0));
        }
  
        [Test]
        public void NullTests()
        {
            Assert.AreEqual(null, SimpleEncryption01.Encrypt(null, 0));
            Assert.AreEqual(null, SimpleEncryption01.Decrypt(null, 0));
        }
    }
}