using DienmayShop.ViewModel.Catalog.Products;
using DienmayShop.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DienmayShop.Application.ClientCatalog.Product
{
    public interface IProductClientService
    {
        Task<PagedResult<ProductVm>> GetListLates(GetProductLatesRequest request);
    }
}
