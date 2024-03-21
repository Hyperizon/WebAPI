using Business.Abstracts;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes;

public class CategoryManager : ICategoryService
{
    private ICategoryDal _categoryDal;
    public CategoryManager(ICategoryDal categoryDal)
    {
        _categoryDal = categoryDal;
    }

    public IResult Add(Category category)
    {
        _categoryDal.Add(category);
        return new SuccsessResult(Messages.CategoryAdded);
    }

    public IResult Delete(Category category)
    {
        _categoryDal.Delete(category);
        return new SuccsessResult(Messages.CategoryDeleted);
    }

    public IResult Update(Category category)
    {
        _categoryDal.Update(category);
        return new SuccsessResult(Messages.CategoryUpdated);
    }

    public IDataResult<Category> GetById(int categoryId)
    {
        return new SuccsessDataResult<Category>(_categoryDal.Get(p => p.CategoryId == categoryId));
    }

    public IDataResult<List<Category>> GetList()
    {
        return new SuccsessDataResult<List<Category>>(_categoryDal.GetList().ToList());
    }
}
