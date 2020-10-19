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
        [InlineData("b5b05534-9263-448c-a69e-0bbd8b3eb90e")]
        public async Task getcm_should_return_right_data(string guid)
        {
            CmService sut = new CmService(_cmRepository, _mapper);

            var result = await sut.GetCmAsync(new GetCmRequest
            {
                CmsId = new Guid(guid)
            });

            result.CmsId.ShouldBe(new Guid(guid));
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
                Products = new List<OrderProduct>()
                {
                    new OrderProduct()
                    {
                        Gtin = new Guid("86bff4f7-05a7-46b6-ba73-d43e2c45840f"),
                        Quantity = 3,
                        SerialNumberType = "SELF_MADE",
                        SerialNumbers = new System.Collections.Generic.List<string>()
                        {
                            "XT6c84e", "2kY39Om", "X4ebssJ"
                        },
                        TemplateId = "3"
                    }
                },
                FactoryId = new Guid("c04f05c0-f6ad-44d1-a400-3375bfb5dfd6")
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
                CmsId = new Guid("b5b05534-9263-448c-a69e-0bbd8b3eb90e"),
                Products = new List<OrderProduct>()
                {
                    new OrderProduct()
                    {
                        Gtin = new Guid("86bff4f7-05a7-46b6-ba73-d43e2c45840f"),
                        Quantity = 3,
                        SerialNumberType = "SELF_MADE",
                        SerialNumbers = new System.Collections.Generic.List<string>()
                        {
                            "XT6c84e", "2kY39Om", "X4ebssJ"
                        },
                        TemplateId = "3"
                    }
                },
                FactoryId = new Guid("c04f05c0-f6ad-44d1-a400-3375bfb5dfd6")
            };

            ICmService sut = new CmService(_cmRepository, _mapper);

            var result = await sut.EditCmAsync(testCm);
            result.CmsId.ShouldBe(testCm.CmsId);
            result.FactoryId.ShouldBe(testCm.FactoryId);
        }
    }
}
