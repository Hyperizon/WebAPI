using Business.Abstracts;
using Business.Contants;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes;

public class ProductManager : IProductService
{
    private IProductDal _productDal;
    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
    }

    public IResult Add(Product product)
    {
        _productDal.Add(product);
        return new SuccsessResult(Messages.ProductAdded);
    }

    public IResult Delete(Product product)
    {
        _productDal.Delete(product);
        return new SuccsessResult(Messages.ProductDeleted);
    }

    public IResult Update(Product product)
    {
        _productDal.Update(product);
        return new SuccsessResult(Messages.ProductUpdated);
    }

    public IDataResult<Product> GetById(int productId)
    {
        return new SuccsessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
    }

    public IDataResult<List<Product>> GetList()
    {
        return new SuccsessDataResult<List<Product>>(_productDal.GetList().ToList());
    }

    public IDataResult<List<Product>> GetListByCategory(int categoryId)
    {
        return new SuccsessDataResult<List<Product>>(_productDal.GetList(p => p.CategoryId == categoryId).ToList());
    }
}
