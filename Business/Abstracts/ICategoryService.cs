﻿using Core.Utilities.Results;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts;

public interface ICategoryService
{
    IDataResult<Category> GetById(int categoryId);
    IDataResult<List<Category>> GetList();
    IResult Add(Category category);
    IResult Delete(Category category);
    IResult Update(Category category);
}
