using System.Threading.Tasks;
using B12Test.Models.TokenAuth;
using B12Test.Web.Controllers;
using Shouldly;
using Xunit;

namespace B12Test.Web.Tests.Controllers
{
    public class HomeController_Tests: B12TestWebTestBase
    {
        [Fact]
        public async Task Index_Test()
        {
            await AuthenticateAsync(null, new AuthenticateModel
            {
                UserNameOrEmailAddress = "admin",
                Password = "123qwe"
            });

            //Act
            var response = await GetResponseAsStringAsync(
                GetUrl<HomeController>(nameof(HomeController.Index))
            );

            //Assert
            response.ShouldNotBeNullOrEmpty();
        }
    }
}