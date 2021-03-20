using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDAL _productDAL;
        ICategoryService _categoryService;

        public ProductManager(IProductDAL productDAL, ICategoryService categoryService)
        {
            _productDAL = productDAL;
            _categoryService = categoryService;
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            //REFACTORY

            //ValidationTool.Validate(new ProductValidator(), product);

            //List<Product> listOfProduct = new List<Product>();
            //var res = _productDAL.GetAll(p => p.CategoryID == product.CategoryID).Count;


            //foreach (var item in listOfProduct)
            //{
            //if (res > 10)
            //{
            //    return new ErrorResult(Messages.ProductCountOfCategoryError);
            //}
            //}

            //if (product.ProductName.Length < 2)
            //{
            //    return new ErrorResult(Messages.ProductNameInvalid);
            //}


            ////business codes 
            //_productDAL.Add(product);
            //return new SuccessResult(Messages.ProductAdded);//set vermediğim için ctor da eklemem lazım
            IResult result = BusinessRules.Run(CheckIfProductNameExist(product.ProductName), CheckIfProductCountOfCategoryCorrect(product.CategoryID),CheckIfCategoryCountCorrect());

            if (result!=null)
            {
                return result;
            }

            _productDAL.Add(product);
            return new SuccessResult(Messages.ProductAdded);//set vermediğim için ctor da eklemem lazım

            //if (CheckIfProductCountOfCategoryCorrect(product.ProductID).Success && CheckIfProductNameExist(product.ProductName).Success)
            //{
            //    _productDAL.Add(product);
            //    return new SuccessResult(Messages.ProductAdded);//set vermediğim için ctor da eklemem lazım
            //}
            //return new ErrorResult();
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Update(Product product)
        {
            if (CheckIfProductCountOfCategoryCorrect(product.ProductID).Success)
            {
                _productDAL.Add(product);
                return new SuccessResult(Messages.ProductAdded);//set vermediğim için ctor da eklemem lazım
            }
            return new ErrorResult();
        }

        //İş kuralı parçacığı olduğuiçin categoryID
        private IResult CheckIfProductCountOfCategoryCorrect(int categoryID)
        {
            var res = _productDAL.GetAll(p => p.CategoryID == categoryID).Count;

            if (res > 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }

            return new SuccessResult();
        }

        private IResult CheckIfCategoryCountCorrect()
        {
            var res = _categoryService.GetAll();
            if (res.Data.Count>15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductNameExist(string name)
        {
            var res = _productDAL.GetAll(p => p.ProductName == name).Any();
            if (res)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExist);
            }
            return new SuccessResult();
        }

        public IDataResult<List<Product>> GetAll()
        {
            //if (DateTime.Now.Hour == 16)
            //{
            //    return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            //}
            return new DataResult<List<Product>>(_productDAL.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryID(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDAL.GetAll(p => p.CategoryID == id));
        }

        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDAL.Get(p => p.ProductID == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDAL.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDTO>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDTO>>(_productDAL.GetProductDetails());
        }
    }
}
