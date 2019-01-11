using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebStore.DAL.Context;
using WebStore.DomainNew.Dto;
using WebStore.DomainNew.Entities;
using WebStore.DomainNew.Filters;
using WebStore.Interfaces;

namespace WebStore.Services.Sql
{
    public class SqlProductData : IProductData
    {
        private readonly WebStoreContext _context;

        public SqlProductData(WebStoreContext context)
        {
            _context = context;
        }

        public IEnumerable<SectionDto> GetSections()
        {
            return _context.Sections.ToList().Select(s=>new SectionDto
            {
                Order = s.Order,
                Name = s.Name,
                ParentId = s.ParentId,
                Id = s.Id
            });
        }
        public SectionDto GetSectionById(int id)
        {
            Section sec = _context.Sections.FirstOrDefault(s => s.Id.Equals(id));
                          if (sec == null) return null;
            
            return new SectionDto
            {
                Name = sec.Name,
                Order = sec.Order,
                Id = sec.Id,
                ParentId = sec.ParentId
            };
        }
        

        public IEnumerable<BrandDto> GetBrands()
        {
            return _context.Brands.ToList().Select((b=>new BrandDto
            {
                Order =b.Order,
                Name = b.Name,
                Id = b.Id
            }));
        }

        public Brand GetBrandById(int id)
        {
            return _context.Brands.FirstOrDefault(s => s.Id == id);
        }

        public PagedProductDto GetProducts(ProductFilter filter)
        {
            var query =
                _context.Products.Include("Brand").Include("Section").AsQueryable();
            if (filter.BrandId.HasValue)
                query = query.Where(c => c.BrandId.HasValue &&
                                         c.BrandId.Value.Equals(filter.BrandId.Value));
            if (filter.SectionId.HasValue)
                query = query.Where(c =>
                    c.SectionId.Equals(filter.SectionId.Value));
            var model = new PagedProductDto
            {
                TotalCount = query.Count()
            };
            if (filter.PageSize.HasValue)
            {
                model.Products = query.OrderBy(c => c.Order).Skip((filter.Page -1) * filter.PageSize.Value).Take(filter.PageSize.Value)
                    .Select(p =>
                        new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Order = p.Order,
                    Price = p.Price,
                    ImageUrl = p.ImageUrl,
                    Brand = p.BrandId.HasValue ? new BrandDto()
                    {
                        Id =
                            p.Brand.Id,
                        Name = p.Brand.Name
                    } : null,
                    Section = new SectionDto()
                    {
                        Id = p.SectionId,
                        Name
                            = p.Section.Name
                    }
                }).ToList();
            }
            else
            {
                model.Products = query.OrderBy(c => c.Order).Select(p =>
                    new ProductDto
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Order = p.Order,
                        Price = p.Price,
                        ImageUrl = p.ImageUrl,
                        Brand = p.BrandId.HasValue ? new BrandDto()
                        {
                            Id =
                                p.Brand.Id,
                            Name = p.Brand.Name
                        } : null,
                        Section = new SectionDto()
                        {
                            Id = p.SectionId,
                            Name
                                = p.Section.Name
                        }
                    }).ToList();
            }
            return model;
        }


        public ProductDto GetProductById(int id)
        {
            var product =
                    _context.Products.Include("Brand").Include("Section").FirstOrDefault(p =>
                        p.Id.Equals(id));
            if (product == null) return null;
            var dto = new ProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                ImageUrl = product.ImageUrl,
                Order = product.Order,
                Price = product.Price,
                Section = new SectionDto()
                {
                    Id = product.SectionId,
                    Name =product.Section.Name,
                    ParentId = product.Section.ParentId,
                    Order = product.Section.Order
                }
            };
            if (product.Brand != null)
                dto.Brand = new BrandDto()
                {
                    Id = product.Brand.Id,
                    Name = product.Brand.Name
                };
            return dto;
        }

    }
}

