using Microsoft.EntityFrameworkCore;
using Oms.Domain.Entities;
using Oms.Fixtures;
using Oms.Infrastructure.Repositories;
using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Oms.Infrastructure.Tests
{
    public class CmRepositoryTests : IClassFixture<OmsContextFactory>
    {
        private readonly CmRepository _sut;
        private readonly TestOmsContext _context;

        public CmRepositoryTests(OmsContextFactory omsContextFactory)
        {
            _context = omsContextFactory.ContextInstance;
            _sut = new CmRepository(_context);
        }


        [Fact]
        public async Task should_get_data()
        {
            var result = await _sut.GetAsync();
            
            result.ShouldNotBeNull();
        }

        [Fact]
        public async Task should_returns_null_with_id_not_present()
        {
            var result = await _sut.GetAsync("");

            result.ShouldBeNull();
        }

        [Theory]
        [InlineData("1001")]
        public async Task should_return_record_by_id(string id)
        {
            var result = await _sut.GetAsync(id);
            
            result.CmsId.ShouldBe(id);
        }

        [Fact]
        public async Task should_add_new_cm()
        {
            var testCm = new Cm
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
            
            _sut.Add(testCm);
            await _sut.UnitOfWork.SaveEntitiesAsync();
            
            _context.Cms
                .FirstOrDefault(_ => _.CmsId == testCm.CmsId)
                .ShouldNotBeNull();
        }

        [Fact]
        public async Task should_update_cm()
        {
            var testCm = new Cm
            {
                CmsId = "1001",
                Products = new System.Collections.Generic.List<OrderProduct>()
                {
                    new OrderProduct()
                    {
                        Gtin = "2002",
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

            _sut.Update(testCm);
            await _sut.UnitOfWork.SaveEntitiesAsync();

            _context.Cms
                .FirstOrDefault(x => x.CmsId == testCm.CmsId)
                ?.FactoryId.ShouldBe("3001");
        }

    }
}
