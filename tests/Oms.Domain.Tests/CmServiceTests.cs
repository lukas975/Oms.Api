using Oms.Domain.Entities;
using Oms.Domain.Mappers;
using Oms.Domain.Requests.Cm;
using Oms.Domain.Services;
using Oms.Fixtures;
using Oms.Infrastructure.Repositories;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Oms.Domain.Tests
{
    public class CmServiceTests : IClassFixture<OmsContextFactory>
    {
        private readonly CmRepository _cmRepository;
        private readonly ICmMapper _mapper;

        public CmServiceTests(OmsContextFactory omsContextFactory)
        {
            _cmRepository = new CmRepository(omsContextFactory.ContextInstance);
            _mapper = omsContextFactory.CmMapper;
        }

        [Fact]
        public async Task getcms_should_return_right_data()
        {
            CmService sut = new CmService(_cmRepository, _mapper);

            var result = await sut.GetCmsAsync();

            result.ShouldNotBeNull();
        }
        [Theory]
        [InlineData("1001")]
        public async Task getcm_should_return_right_data(string id)
        {
            CmService sut = new CmService(_cmRepository, _mapper);

            var result = await sut.GetCmAsync(new GetCmRequest
            {
                CmsId = id
            });

            result.CmsId.ShouldBe(id);
        }

        [Fact]
        public void getcm_should_thrown_exception_with_null_id()
        {
            CmService sut = new CmService(_cmRepository, _mapper);

            sut.GetCmAsync(null).ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public async Task addcm_should_add_right_entity()
        {
            var testCm = new AddCmRequest
            {
                CmsId = "1002",
                Products = new List<OrderProduct>()
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

            ICmService sut = new CmService(_cmRepository, _mapper);

            var result = await sut.AddCmAsync(testCm);
            result.FactoryId.ShouldBe(testCm.FactoryId);
        }

        [Fact]
        public async Task editcm_should_add_right_entity()
        {
            var testCm = new EditCmRequest
            {
                CmsId = "1001",
                Products = new List<OrderProduct>()
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

            ICmService sut = new CmService(_cmRepository, _mapper);

            var result = await sut.EditCmAsync(testCm);
            result.CmsId.ShouldBe(testCm.CmsId);
            result.FactoryId.ShouldBe(testCm.FactoryId);
        }
    }
}
