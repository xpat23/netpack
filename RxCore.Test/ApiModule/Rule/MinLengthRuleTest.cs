using RxCore.ApiModule.Rule;
using Xunit;

namespace RxCore.Test.ApiModule.Rule
{
    public class MinLengthRuleTest
    {
        [Theory]
        [InlineData("123", 3)]
        [InlineData("1234", 3)]
        [InlineData("1234567", 5)]
        public void TestIsValid(string value, int length)
        {
            //Arrange
            var testObject = new RuleTestClass {Email = value};

            //Act
            var rule = new MinLengthRule<RuleTestClass>("id", x => x.Email, length);
            var validate = rule.Validate(testObject);

            //Assert
            Assert.True(validate);
        }

        [Theory]
        [InlineData("", 2)]
        [InlineData(null, 1)]
        [InlineData("text", 5)]
        public void TestIsNotValid(string email, int length)
        {
            //Arrange
            var testObject = new RuleTestClass()
            {
                Email = email
            };

            //Act
            var rule = new MinLengthRule<RuleTestClass>("id", x => x.Email, length);
            var validate = rule.Validate(testObject);

            //Assert
            Assert.False(validate);
            Assert.Equal("Длина должна быть больше " + length, rule.Message());
            Assert.Equal("id", rule.MessageId());
        }

    }
}