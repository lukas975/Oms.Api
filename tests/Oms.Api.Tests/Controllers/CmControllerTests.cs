using Newtonsoft.Json;
using Oms.Domain.Entities;
using Oms.Domain.Requests.Cm;
using Oms.Fixtures;
using Shouldly;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Oms.Api.Tests.Controllers
{
    public class CmControllerTests : IClassFixture<InMemoryApplicationFactory<Startup>>
    {
        private readonly InMemoryApplicationFactory<Startup> _factory;
        
        public CmControllerTests(InMemoryApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/api/cms/")]
        public async Task get_should_return_success(string url)
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync(url);

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task get_by_id_should_return_cm_data()
        {
            const string id = "1001";

            var client = _factory.CreateClient();
            
            var response = await client.GetAsync($"/api/cms/{id}");

            response.EnsureSuccessStatusCode();
            
            var responseContent = await response.Content.ReadAsStringAsync();
            
            var responseEntity = JsonConvert.DeserializeObject<Cm>(responseContent);
            responseEntity.ShouldNotBeNull();
        }

        [Fact]
        public async Task add_should_create_new_record()
        {
            var request = new AddCmRequest
            {
                CmsId = "1002",
                Products = new System.Collections.Generic.List<OrderProduct>()
                {
                    new OrderProduct()
                    {
                        Gtin = "2001",
                        Quantity = 3,
                        SerialNumberType = "SELF_MADE",
                        SerialNumbers = new System.Collections.Generic.List<string>()
                        {
                            "XT6c84e", "2kY39Om", "X4ebssJ"
                        },
                        TemplateId = "3"
                    }
                },
                FactoryId = "3001"
            };

            var client = _factory.CreateClient();

            var httpContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"/api/cms", httpContent);
            response.EnsureSuccessStatusCode();
            response.Headers.Location.ShouldNotBeNull();
        }

        [Fact]
        public async Task update_should_modify_existing_item()
        {
            var client = _factory.CreateClient();
            var request = new EditCmRequest
            {
                CmsId = "1007",
                Products = new System.Collections.Generic.List<OrderProduct>()
                {
                    new OrderProduct()
                    {
                        Gtin = "2001",
                        Quantity = 3,
                        SerialNumberType = "SELF_MADE",
                        SerialNumbers = new System.Collections.Generic.List<string>()
                        {
                            "XT6c84e", "2kY39Om", "X4ebssJ"
                        },
                        TemplateId = "3"
                    }
                },
                FactoryId = "3001"
            };

            var httpContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"/api/cms/{request.CmsId}", httpContent);
            response.EnsureSuccessStatusCode();
            
            var responseContent = await response.Content.ReadAsStringAsync();
            var responseEntity = JsonConvert.DeserializeObject<Cm>(responseContent);

            responseEntity.FactoryId.ShouldBe(request.FactoryId);
        }
    }
}
