using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Helpers;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class ProductImageManager : IProductImageService
    {
        IProductImageDal _productImageDal;

        public ProductImageManager(IProductImageDal productImageDal)
        {
            _productImageDal = productImageDal;
            
        }

        //[ValidationAspect(typeof(ProductImageValidator))]
        public IResult Add(ProductImage productImage)
        {
            _productImageDal.Add(productImage);
            return new SuccessResult(Messages.ProductImageAdded);
        }

        [ValidationAspect(typeof(ProductImageValidator))]
        public IResult Delete(ProductImage productImage)
        {
            _productImageDal.Delete(productImage);
            return new SuccessResult(Messages.ProductImageDeleted);
        }

        [ValidationAspect(typeof(ProductImageValidator))]
        public IDataResult<List<ProductImage>> GetAll()
        {
            return new SuccessDataResult<List<ProductImage>>(_productImageDal.GetAll());
        }

        public IDataResult<List<ProductImage>> GetProductImageById(int id)
        {
            return new SuccessDataResult<List<ProductImage>>(_productImageDal.GetAll(p => p.Id == id).ToList());
        }

        [ValidationAspect(typeof(ProductImageValidator))]
        public IResult Update( ProductImage productImage)
        {
            _productImageDal.Update(productImage);
            return new SuccessResult(Messages.ProductImageUpdated);
        }
        //En fazla 5 tane ürün resmi eklenebilir.
        private IResult CheckIfProductImageLimit()
        {
            var result = _productImageDal.GetAll();
            if (result.Count > 5)
            {
                return new SuccessResult(Messages.ProductImageCountError);
            }
            else
            {
                return new SuccessResult();
            }
        }

    }
}
