using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTest.App;

namespace unitTest.Test
{
    public class CalculaterTest
    {

        public Calculater calculater { get; set; }
        public Mock<ICalculaterService> mymock { get; set; }
        public CalculaterTest()
        {

            mymock = new Mock<ICalculaterService>();
            this.calculater = new Calculater(mymock.Object);
        }
        //[Fact]
        //public void AddTest()
        //{
        //    //Arrange

        //    int a = 5;
        //    int b = 20;



        //    //Act

        //    var total = calculater.add(a, b);
        //    Assert.Equal(25, total);


        //    ////Assert

        //    ////doğrılama evresidir.
        //    //Assert.Equal<int>(25, total);
        //    ////ilk satıra bekledğimiz sonraki satıra ise metodumzudan gelen değeri yazdık.

        //    //Assert.Contains("emre", "Fatih Çakıroğlu");
        //    ////ilk değer ikinci değerin içinde olup olmadııpın bajar
        //    ////ilk değer beklenen değerdir ikinci değer ise gerçek değerdir.

        //    //var names = new List<string>() { "Fatih", "Emre", "Hasan" };
        //    //Assert.Contains(names, x => x.Contains("Emreeee"));

        //    // Assert.True(5 > 2);//Testimin başarılı olmasını beklerim çünkü doğrı 
        //    //Assert.False(5 < 2);//:Testimin doğru olmasını beklerim çünkü 5 2 den küçük değil yani false zaten ben de false yazdım.

        //    // Assert.StartsWith("Numan", "Numan Gündüz"); //numan fündüzün başında numan olduğu için tesimin sonucu true döner

        //    // Assert.Empty(new List<string>()); // dizi boş bşr dşzş ıkduğu için sonuç true döndğ
        //    //Assert.Empty(new List<string> { "Numan" }); // dizi dolu oldupu için sonuc false döndüğ

        //    //fact metodu parametre almaz 



        //}

        [Theory]
        [InlineData(2, 5, 7)]
        [InlineData(10, 5, 15)]
        public void Add_simpleValues_ReturnTotalValue(int a, int b, int Expectedtotal)
        {


            mymock.Setup(x => x.add(a, b)).Returns(Expectedtotal);

            var actualTotal = calculater.add(a, b);
            Assert.Equal(Expectedtotal, actualTotal);

        }


        [Theory]
        [InlineData(0, 5, 0)]
        [InlineData(10, 0, 0)]
        public void Add_zeroValues_ReturnZeroValue(int a, int b, int Expectedtotal)
        {
            var actualTotal = calculater.add(a, b);
            Assert.Equal(Expectedtotal, actualTotal);

        }
        [Theory]
        [InlineData(2, 5, 10)]

        public void Multip_simpleValue_ReturnMultipValue(int a, int b, int ExpectedValue)
        {
            int actualMul=0;
            mymock.Setup(x => x.Mul(It.IsAny<int>(), It.IsAny<int>())).Callback<int, int>((x, y) => actualMul = x * y);
            calculater.Mul(a, b);
            Assert.Equal(ExpectedValue, actualMul);
            calculater.Mul(5, 20);
            Assert.Equal(100,actualMul);

           // mymock.Verify(x => x.Mul(a, b), Times.Once);//testin hiç çalışmamış olmasını kontrol et .





        }

        [Theory]
        [InlineData(0,5)]

        public void Multip_Zero_ReturnException(int a, int b)
        {
            mymock.Setup(x => x.Mul(a, b)).Throws(new Exception("a=0 olamaz"));
            var exception = Assert.Throws<Exception>(() => calculater.Mul(a, b));
            Assert.Equal("a=0 olamaz",exception.Message);
        }
    }
}
