using Microwave.Classes.Boundary;
using Microwave.Classes.Interfaces;
using Microwave.Classes.Boundary;
using NUnit.Framework;
using NSubstitute;

namespace Microwave.Test.Unit
{
    [TestFixture]
    public class BuzzerTest
    {
        private Buzzer uut;
        private IOutput output;

        [SetUp]
        public void Setup()
        {
            output = Substitute.For<IOutput>();

            uut = new Buzzer(output);
        }

        [Test]
        public void Buzz_IsCalled()
        {
            uut.Buzz();
            output.Received(1).OutputLine(Arg.Is<string>(str => str.Contains("Buzz")));
        }

    }
}