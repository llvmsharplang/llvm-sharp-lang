using NUnit.Framework;
using Ion.Tests.Wrappers;

namespace Ion.Tests.CodeGeneration
{
    [TestFixture]
    internal sealed class StructTests : ConstructTest
    {
        [Test]
        public void Struct()
        {
            // Prepare the wrapper.
            this.Wrapper.Prepare("Struct");

            // Invoke the driver.
            this.Wrapper.InvokeDriver(2);

            // Compare results.
            this.Wrapper.Compare();
        }

        [Test]
        public void StructMultipleProps()
        {
            // Prepare the wrapper.
            this.Wrapper.Prepare("StructMultipleProps");

            // Invoke the driver.
            this.Wrapper.InvokeDriver(2);

            // Compare results.
            this.Wrapper.Compare();
        }

        [Test]
        public void StructPropAccess()
        {
            // Prepare the wrapper.
            this.Wrapper.Prepare("StructPropAccess");

            // Invoke the driver.
            this.Wrapper.InvokeDriver(2);

            // Compare results.
            this.Wrapper.Compare();
        }
    }
}
