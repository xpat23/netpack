using System.Linq;
using RxCore.ApiModule;
using Xunit;

namespace RxCore.Test.ApiModule
{
    public class CreateApiResponseTest
    {
        [Fact]
        public void TestCreateInvalidResponse()
        {
            //Arrange
            var validateResult = new ValidateResult();
            validateResult.Messages.Add(new Message("May not be empty", "id"));
            
            //Act
            var response =
                RxApiResponse<string>.CreateInvalidResponse(ResponseStatus.InvalidData, validateResult);
                
            //Assert
            Assert.Equal(validateResult.Messages, response.Messages);
            Assert.Equal( ResponseStatus.InvalidData, response.Status);
        }

        [Fact]
        public void TestCreateResponse()
        {
            //Arrange
            const string message = "test-message";

            //Act
            var response =
                RxApiResponse<string>.CreateResponse(ResponseStatus.Success, message);
                
            //Assert
            Assert.Equal(ResponseStatus.Success, response.Status);
            Assert.Equal(message, response.Messages.First().Text);
        }
    }
}