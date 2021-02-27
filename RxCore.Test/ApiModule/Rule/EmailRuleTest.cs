using RxCore.ApiModule.Rule;
using Xunit;

namespace RxCore.Test.ApiModule.Rule
{
    public class EmailRuleTest
    {
        [Theory]
        [InlineData("text@mail.ru")]
        [InlineData("777@t.ti")]
        [InlineData(null)]
        public void TestIsValid(string value)
        {
            //Arrange
            var testObject = new RuleTestClass {Email = value};

            //Act
            var rule = new EmailRule<RuleTestClass>("id", x => x.Email);
            var validate = rule.Validate(testObject);

            //Assert
            Assert.True(validate);
        }

        [Theory]
        [InlineData("")]
        [InlineData("only-text")]
        public void TestIsNotValid(string email)
        {
            //Arrange
            var testObject = new RuleTestClass()
            {
                Email = email
            };

            //Act
            var rule = new EmailRule<RuleTestClass>("id", x => x.Email);
            var validate = rule.Validate(testObject);

            //Assert
            Assert.False(validate);
            Assert.Equal(EmailRule<string>.MessageDescription, rule.Message());
            Assert.Equal("id", rule.MessageId());
        }

    }
}