using WebStore.DomainNew.Entities.Base;
using WebStore.DomainNew.Entities.Base.Interfaces;

namespace WebStore.DomainNew.Dto
{
    public class ProductDto:NamedEntity,IOrderedEntity
    {
        public int Order { get; set; }

        public string ImageUrl { get; set; }

        public decimal Price { get; set; }

        public BrandDto Brand { get; set; }
    }
}