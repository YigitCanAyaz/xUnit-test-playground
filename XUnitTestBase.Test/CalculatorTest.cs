using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using XUnitTestBase.APP;

namespace XUnitTestBase.Test
{
    public class CalculatorTest
    {
        public CalculatorService Calculator { get; set; }
        public Calculator DICalculator { get; set; }
        public Mock<ICalculatorService> Mock { get; set; }
        public CalculatorTest()
        {
            Calculator = new CalculatorService();

            Mock = new Mock<ICalculatorService>();
            DICalculator = new Calculator(Mock.Object);
        }

        [Fact]
        public void EqualInt()
        {
            // Arrange
            int a = 5;
            int b = 20;

            // Act
            var expectedTotal = Calculator.Add(a, b);

            // Assert
            Assert.Equal<int>(25, expectedTotal);
        }

        [Fact]
        public void NotEqualString()
        {
            // Arrange
            string a = "Hello World!";
            string b = "Hello  orld!";

            // Assert
            Assert.NotEqual<string>(a, b);
        }

        [Fact]
        public void ContainsSingle()
        {
            // Assert
            Assert.Contains("Yiğit", "Yiğit Can Ayaz");
        }

        [Fact]
        public void ContainsList()
        {
            // Arrange
            var names = new List<string>() { "Fatih", "Emre", "Hasan" };

            // Assert
            Assert.Contains(names, x => x == "Fatih");
        }

        [Fact]
        public void DoesNotContainSingle()
        {
            // Assert
            Assert.DoesNotContain("Emre", "Yiğit Can Ayaz");
        }

        [Fact]
        public void DoesNotContainList()
        {
            // Arrange
            var names = new List<string>() { "Fatih", "Emre", "Hasan" };

            // Assert
            Assert.DoesNotContain(names, x => x == "Yiğit");
        }

        [Fact]
        public void TrueCondition()
        {
            // Assert
            Assert.True("".GetType() == typeof(string));
        }

        [Fact]
        public void FalseCondition()
        {
            // Assert
            Assert.False(5 < 2);
        }

        [Fact]
        public void MatchesRegex()
        {
            // Arrange
            var regEx = "^dog";

            // Assert
            Assert.Matches(regEx, "dog cat");
        }

        [Fact]
        public void DoesNotMatchRegex()
        {
            // Arrange
            var regEx = "^dog";

            // Assert
            Assert.DoesNotMatch(regEx, "cat dog");
        }

        [Fact]
        public void StartsWith()
        {
            // Assert
            Assert.StartsWith("em", "emre");
        }

        [Fact]
        public void EndsWith()
        {
            // Assert
            Assert.EndsWith("re", "emre");
        }

        [Fact]
        public void Empty()
        {
            // Assert
            Assert.Empty(new List<string>());
        }

        [Fact]
        public void NotEmpty()
        {
            // Assert
            Assert.NotEmpty(new List<int>() { 1, 2, 3 });
        }

        [Fact]
        public void InRange()
        {
            // Assert
            Assert.InRange(2, 1, 10);
        }

        [Fact]
        public void NotInRange()
        {
            // Assert
            Assert.NotInRange(11, 1, 10);
        }

        [Fact]
        public void SingleList()
        {
            // Assert
            Assert.Single(new List<string>() { "fatih" });
        }

        [Fact]
        public void SingleGenericList()
        {
            // Assert
            Assert.Single<int>(new List<int>() { 1 });
        }

        [Fact]
        public void IsType()
        {
            // Assert
            Assert.IsType<string>("fatih");
        }

        [Fact]
        public void IsNotType()
        {
            // Assert
            Assert.IsNotType<int>(true);
        }

        [Fact]
        public void IsAssignableFrom()
        {
            // Assert
            Assert.IsAssignableFrom<IEnumerable<string>>(new List<string>());
        }

        [Fact]
        public void IsAssignableFrom2()
        {
            // Assert
            Assert.IsAssignableFrom<Object>(2);
        }

        [Fact]
        public void Null()
        {
            // Arrange
            string deger = null;

            // Assert
            Assert.Null(deger);
        }

        [Fact]
        public void NotNull()
        {
            // Arrange
            string deger = "asd";

            // Assert
            Assert.NotNull(deger);
        }

        [Theory]
        [InlineData(5, 20, 25)]
        [InlineData(5, 12, 17)]
        public void EqualIntParameter(int a, int b, int expectedTotal)
        {

            // Act
            var actualTotal = Calculator.Add(a, b);

            // Assert
            Assert.Equal<int>(expectedTotal, actualTotal);
        }

        // Yeni metod isimlendirmesi

        [Theory]
        [InlineData(5, 20, 25)]
        [InlineData(5, 12, 17)]
        public void Add_SimpleValues_ReturnTotalValue(int a, int b, int expectedTotal)
        {
            // Act
            var actualTotal = Calculator.Add(a, b);

            // Assert
            Assert.Equal<int>(expectedTotal, actualTotal);
        }

        [Theory]
        [InlineData(-5, -3, 0)]
        [InlineData(-6, 4, 0)]
        public void Add_NegativeValuesIncluded_ReturnZeroValue(int a, int b, int expectedTotal)
        {

            // Act
            var actualTotal = Calculator.Add(a, b);

            // Assert
            Assert.Equal<int>(expectedTotal, actualTotal);
        }

        [Theory]
        [InlineData(5, 20, 25)]
        [InlineData(5, 12, 17)]
        public void Add_SimpleValues_ReturnTotalValueMock(int a, int b, int expectedTotal)
        {
            // taklit etme olayı burada gerçekleşir
            Mock.Setup(x => x.Add(a, b)).Returns(expectedTotal);

            // Act
            var actualTotal = DICalculator.Add(a, b);

            // Assert
            Assert.Equal<int>(expectedTotal, actualTotal);
        }

        [Theory]
        [InlineData(3, 4, 12)]
        [InlineData(5, 0, 0)]
        public void Multiply_SimpleValues_ReturnTotalValueMock(int a, int b, int expectedTotal)
        {
            // taklit etme olayı burada gerçekleşir
            Mock.Setup(x => x.Mul(a, b)).Returns(expectedTotal);

            // Act
            var actualTotal = DICalculator.Mul(a, b);

            // Assert
            Assert.Equal<int>(expectedTotal, actualTotal);
        }

        [Theory]
        [InlineData(5, 20, 25)]
        [InlineData(5, 12, 17)]
        public void Add_SimpleValuesMockOneTime_ReturnTotalValue(int a, int b, int expectedTotal)
        {
            // taklit etme olayı burada gerçekleşir
            Mock.Setup(x => x.Add(a, b)).Returns(expectedTotal);

            // Act
            var actualTotal = DICalculator.Add(a, b);

            // Assert
            Assert.Equal<int>(expectedTotal, actualTotal);

            // Test'in sadece bir kere çalışıp çalışmadığını kontrol eder.
            Mock.Verify(x => x.Add(a, b), Times.Once);
        }

        [Theory]
        [InlineData(0, 5)]
        public void Multiply_ZeroValue_ReturnsException(int a, int b)
        {
            // Exception için sahte test yazdık
            Mock.Setup(x => x.Mul(a, b)).Throws(new Exception("a = 0 olamaz!"));

            // Döneceği tür Exception ise bu kısım başarılı olur ve aynı zamanda değişkene eşitleriz
            Exception exception = Assert.Throws<Exception>(() => DICalculator.Mul(a, b));

            // Hata mesajları birbirine aynıysa testin bu kısmı başarılı olur.
            Assert.Equal("a = 0 olamaz!", exception.Message);
        }

        [Theory]
        [InlineData(3, 5, 15)]
        public void xxxxx(int a, int b, int expectedValue)
        {
            int actualMultiply = 0;
            Mock.Setup(x => x.Mul(It.IsAny<int>(), It.IsAny<int>()))
                .Callback<int, int>((x, y) => actualMultiply = x * y);

            DICalculator.Mul(a, b);

            Assert.Equal(expectedValue, actualMultiply);

            DICalculator.Mul(5, 20);

            Assert.Equal(100, actualMultiply);
        }
    }
}
