using System.IO;
using System.Linq;
using Moq;
using RxCore.ApiModule;
using Xunit;

namespace RxCore.Test.ApiModule
{
    
    public class DataValidatorTest
    {
        private const string Data = "Test-Data";

        [Fact]
        public void TestValidateWhenRulesIsValid()
        {
            var rule1Mock = new Mock<IValidateRule<string>>();
            rule1Mock
                .Setup(x => x.Validate(Data))
                .Returns(true);

            var rule2Mock = new Mock<IValidateRule<string>>();
            rule2Mock
                .Setup(x => x.Validate(Data))
                .Returns(true);

            var validator = new DataValidator<string>();
            validator.AddRule(rule1Mock.Object);
            validator.AddRule(rule2Mock.Object);

            var result = validator.Validate(Data);

            Assert.Empty(result.Messages);
            Assert.True(result.IsValid);
        }

        [Fact]
        public void TestValidateWhenOneRuleIsNotValid()
        {

            const string invalidMessage = "Ошибка валидации";
            const string messageId = "test-id";
            var rule1Mock = new Mock<IValidateRule<string>>();
            
            rule1Mock
                .Setup(x => x.Validate(Data))
                .Returns(false);
            
            rule1Mock
                .Setup(x => x.Message())
                .Returns(invalidMessage);
            
            rule1Mock
                .Setup(x => x.MessageId())
                .Returns(messageId);


            var rule2Mock = new Mock<IValidateRule<string>>();
            rule2Mock
                .Setup(x => x.Validate(Data))
                .Returns(true);

            var validator = new DataValidator<string>();
            validator.AddRule(rule1Mock.Object);
            validator.AddRule(rule2Mock.Object);

            var result = validator.Validate(Data);

            Assert.Single(result.Messages);
            Assert.False(result.IsValid);
            Assert.Equal(invalidMessage, result.Messages.First().Text);
            Assert.Equal(messageId, result.Messages.First().Id);
        }
    }
}