using Microsoft.AspNetCore.Http;
using WebStore.DomainNew.Models.Cart;
using WebStore.Interfaces;

namespace WebStore.Services
{
    public class CoockiesCartStore:ICartStore
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly string _cartName;
        public Cart Cart { get; set; }

        public CoockiesCartStore(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
    }
}