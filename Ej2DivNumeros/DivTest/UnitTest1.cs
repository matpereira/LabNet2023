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
            //Arange
            var data = String.Join(Environment.NewLine, new[]
            {
              "1","2",
            });
            Console.SetIn(new System.IO.StringReader(data));
            
            //act
            double resultado = DivExceptions.DivisionDosNum();
            
            //assert
            Assert.AreEqual(0.5, resultado);
        }

        [Test]
        public void DivisionErroneaDividePorCero()
        {
            //Arange
            var data = String.Join(Environment.NewLine, new[]
            {
              "1","0",
            });
            Console.SetIn(new System.IO.StringReader(data));
            
            //Act | Assert
            Assert.Throws<DivideByZeroException>(() => DivExceptions.DivisionDosNum());
        }

        [Test]
        public void ErrorPorIngresarLetraEnDividendo()
        {
            //Arange
            var data = String.Join(Environment.NewLine, new[]
            {
              "s","2",
            });
            Console.SetIn(new System.IO.StringReader(data));

            //Act | Assert
            Assert.Throws<FormatException>(() => DivExceptions.DivisionDosNum());
        }

        [Test]
        public void ErrorPorIngresarLetraEnDivisor()
        {
            //Arange
            var data = String.Join(Environment.NewLine, new[]
            {
              "s","2",
            });
            Console.SetIn(new System.IO.StringReader(data));

            //Act | Assert
            Assert.Throws<FormatException>(() => DivExceptions.DivisionDosNum());
        }

        [Test]
        public void ErrorPorIngresarValorNullEnDividendo()
        {
            //Arrange
            var data = String.Join(Environment.NewLine, new[]
            {
              "null","2",
            });
            Console.SetIn(new System.IO.StringReader(data));

            //Act | Assert
            Assert.Throws<FormatException>(() => DivExceptions.DivisionDosNum());
        }

        [Test]
        public void ErrorPorIngresarValorNullEnDivisor()
        {
            //Arrange
            var data = String.Join(Environment.NewLine, new[]
            {
              "4","null",
            });
            Console.SetIn(new System.IO.StringReader(data));

            //Act | Assert
            Assert.Throws<FormatException>(() => DivExceptions.DivisionDosNum());
        }
    }
}