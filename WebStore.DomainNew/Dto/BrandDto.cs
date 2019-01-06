using WebStore.DomainNew.Entities.Base;
using WebStore.DomainNew.Entities.Base.Interfaces;

namespace WebStore.DomainNew.Dto
{
    public class BrandDto:NamedEntity,IOrderedEntity
    {
        public int Order { get; set; }
    }
}