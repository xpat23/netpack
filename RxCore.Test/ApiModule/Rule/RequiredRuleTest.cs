using RxCore.ApiModule.Rule;
using Xunit;

namespace RxCore.Test.ApiModule.Rule
{
    public class RequiredRuleTest
    {
        [Theory]
        [InlineData("text")]
        [InlineData("tx")]
        public void TestIsValid(string value)
        {
            //Arrange
            var testObject = new RuleTestClass {Id = value};

            //Act
            var rule = new RequiredRule<RuleTestClass>("id", x => x.Id);
            var validate = rule.Validate(testObject);

            //Assert
            Assert.True(validate);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void TestIsNotValid(string id)
        {
            //Arrange
            var testObject = new RuleTestClass()
            {
                Id = id
            };

            //Act
            var rule = new RequiredRule<RuleTestClass>("id", x => x.Id);
            var validate = rule.Validate(testObject);

            //Assert
            Assert.False(validate);
            Assert.Equal(RequiredRule<string>.MessageDescription, rule.Message());
            Assert.Equal("id", rule.MessageId());
        }
    }
}