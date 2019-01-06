using WebStore.DomainNew.Entities.Base;
using WebStore.DomainNew.Entities.Base.Interfaces;

namespace WebStore.DomainNew.Dto
{
    public class SectionDto:NamedEntity,IOrderedEntity
    {
        public int Order { get; set; }

        public int? ParentId { get; set; }
    }
}