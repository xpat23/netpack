using RxCore.ApiModule.Rule;
using Xunit;

namespace RxCore.Test.ApiModule.Rule
{
    public class RegexRuleTest
    {
        [Theory]
        [InlineData("73934", @"^\d+$")]
        [InlineData("", @"^\d+$")]
        public void TestIsValid(string value, string pattern)
        {
            //Arrange
            var testObject = new RuleTestClass {Email = value};

            //Act
            var rule = new RegexRule<RuleTestClass>("id", x => x.Email, pattern);
            var validate = rule.Validate(testObject);

            //Assert
            Assert.True(validate);
        }

        [Theory]
        [InlineData("test",  @"^\d+$")]
        [InlineData("1kkd",  @"^\d+$")]
        public void TestIsNotValid(string email, string pattern)
        {
            //Arrange
            var testObject = new RuleTestClass()
            {
                Email = email
            };

            //Act
            var rule = new RegexRule<RuleTestClass>("id", x => x.Email, pattern);
            var validate = rule.Validate(testObject);

            //Assert
            Assert.False(validate);
            Assert.Equal(RegexRule<string>.MessageDescription, rule.Message());
            Assert.Equal("id", rule.MessageId());
        }

    }
}