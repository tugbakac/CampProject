using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllByCategoryID(int id);
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);

        IDataResult<List<ProductDetailDTO>> GetProductDetails();
        IDataResult<Product> GetById(int productId);//işlem sonucu vs. dönmek için IDataResult
        IResult Add(Product product);
        IResult Update(Product product);
        IResult AddTransactionalTest(Product product);//tutarlılığı korumak için kullanılan bir yöntem
    }
}
