using Div2Numeros.Exceptions;

namespace DivTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Division2NumerosValidos()
        {
            var data = String.Join(Environment.NewLine, new[]
            {
              "2",
              "1",
            });

            Console.SetIn(new System.IO.StringReader(data));
            int resultado = DivExceptions.DivisionDosNum();
            Assert.AreEqual(2, resultado);
        }

        [Test]
        public void DivisionErroneaDividePorCero()
        {
            var data = String.Join(Environment.NewLine, new[]
            {
              "1",
              "0",
            });

            Console.SetIn(new System.IO.StringReader(data));
            Assert.Throws<DivideByZeroException>(() => DivExceptions.DivisionDosNum());
        }

        [Test]
        public void ErrorPorIngresarLetraEnDividendo()
        {
            var data = String.Join(Environment.NewLine, new[]
            {
              "s",
              "2",
            });

            Console.SetIn(new System.IO.StringReader(data));
            Assert.Throws<FormatException>(() => DivExceptions.DivisionDosNum());
        }

        [Test]
        public void ErrorPorIngresarLetraEnDivisor()
        {
            var data = String.Join(Environment.NewLine, new[]
            {
              "s",
              "2",
            });

            Console.SetIn(new System.IO.StringReader(data));
            Assert.Throws<FormatException>(() => DivExceptions.DivisionDosNum());
        }

        [Test]
        public void ErrorPorIngresarValorNullEnDividendo()
        {
            var data = String.Join(Environment.NewLine, new[]
            {
              "null",
              "2",
            });

            Console.SetIn(new System.IO.StringReader(data));
            Assert.Throws<FormatException>(() => DivExceptions.DivisionDosNum());
        }

        [Test]
        public void ErrorPorIngresarValorNullEnDivisor()
        {
            var data = String.Join(Environment.NewLine, new[]
            {
              "4",
              "null",
            });

            Console.SetIn(new System.IO.StringReader(data));
            Assert.Throws<FormatException>(() => DivExceptions.DivisionDosNum());
        }
    }
}