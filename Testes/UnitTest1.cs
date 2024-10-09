namespace Testes
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            int num1 = 5;
            int num2 = 10;

            int resultado = 10 + 5;

            Assert.Equal(15, resultado);
        }
    }
}