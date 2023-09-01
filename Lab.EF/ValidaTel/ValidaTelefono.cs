using Lab.EF.UI;

namespace ValidaTel
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void NumeroTelefono_Valido12Digitos()
        {
            //Arrange   
            string numero = "1122554477";

            //Act
            UIFunctions uiFunctions = new UIFunctions();
            bool resultado = uiFunctions.EsNumeroTelefonoValido(numero);

            //Assert
            Assert.IsTrue(resultado);
        }

        [Test]
        public void NumeroTelefono_ValidoConParentesis()
        {
            //Arrange   
            string numero = "(+54)1122335544";

            //Act
            UIFunctions uiFunctions = new UIFunctions();
            bool resultado = uiFunctions.EsNumeroTelefonoValido(numero);

            //Assert
            Assert.IsTrue(resultado);
        }

        [Test]
        public void NumeroTelefono_NoValidoConLetras()
        {
            //Arrange   
            string numero = "SS1122335544";

            //Act
            UIFunctions uiFunctions = new UIFunctions();
            bool resultado = uiFunctions.EsNumeroTelefonoValido(numero);

            //Assert
            Assert.IsFalse(resultado);
        }


        [Test]
        public void NumeroTelefono_NoValido_MuchosDigitos()
        {
            //Arrange   
            string numero = "11231231231231241231231231231231231231231231231122335544";

            //Act
            UIFunctions uiFunctions = new UIFunctions();
            bool resultado = uiFunctions.EsNumeroTelefonoValido(numero);

            //Assert
            Assert.IsFalse(resultado);
        }

    }
}