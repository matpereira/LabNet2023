
namespace TelefonoTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void EsNumeroTelefonoValidoTest()
        {
            //Arrange
            string numero = "1122554477";

            //act
          //  bool resultado = EsNumeroTelefonoValido(numero);

            //Assert
            Assert.IsTrue(resultado);


        }
    }
}