using RxCore.ApiModule.Rule;
using Xunit;

namespace RxCore.Test.ApiModule.Rule
{
    public class MaxLengthRuleTest
    {
        [Theory]
        [InlineData("123", 3)]
        [InlineData("1234", 4)]
        [InlineData(null, 1)]
        [InlineData("1234567", 9)]
        public void TestIsValid(string value, int length)
        {
            //Arrange
            var testObject = new RuleTestClass {Email = value};

            //Act
            var rule = new MaxLengthRule<RuleTestClass>("id", x => x.Email, length);
            var validate = rule.Validate(testObject);

            //Assert
            Assert.True(validate);
        }

        [Theory]
        [InlineData("234", 2)]
        [InlineData("text", 3)]
        public void TestIsNotValid(string email, int length)
        {
            //Arrange
            var testObject = new RuleTestClass()
            {
                Email = email
            };

            //Act
            var rule = new MaxLengthRule<RuleTestClass>("id", x => x.Email, length);
            var validate = rule.Validate(testObject);

            //Assert
            Assert.False(validate);
            Assert.Equal("Длина должна быть меньше " + length, rule.Message());
            Assert.Equal("id", rule.MessageId());
        }

    }
}