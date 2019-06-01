using NUnit.Framework;
using Ion.Tests.Wrappers;

namespace Ion.Tests.CodeGeneration
{
    [TestFixture]
    internal sealed class PrototypeTests : ConstructTest
    {
        [Test]
        public void Complex()
        {
            this.Wrapper.Bootstrap("ComplexPrototype");
        }
    }
}
