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
            var result = await _sut.GetAsync(Guid.NewGuid());

            result.ShouldBeNull();
        }

        [Theory]
        [InlineData("b5b05534-9263-448c-a69e-0bbd8b3eb90e")]
        public async Task should_return_record_by_id(string guid)
        {
            var result = await _sut.GetAsync(new Guid(guid));
            
            result.CmsId.ShouldBe(new Guid(guid));
        }

        [Fact]
        public async Task should_add_new_cm()
        {
            var testCm = new Cm
            {
                Products = new System.Collections.Generic.List<OrderProduct>()
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
                CmsId = new Guid("b5b05534-9263-448c-a69e-0bbd8b3eb90e"),
                Products = new System.Collections.Generic.List<OrderProduct>()
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

            _sut.Update(testCm);
            await _sut.UnitOfWork.SaveEntitiesAsync();

            _context.Cms
                .FirstOrDefault(x => x.CmsId == testCm.CmsId)
                ?.FactoryId.ShouldBe(new Guid("c04f05c0-f6ad-44d1-a400-3375bfb5dfd6"));
        }

    }
}
