using Autofac;
using Business.Concretes;
using Business.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Concretes.EntityFramework;
using DataAccess.Abstracts;

namespace Business.DependencyResolvers.Autofac;

public class AutofocBusinessModule:Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<ProductManager>().As<IProductService>();
        builder.RegisterType<EfProductDal>().As<IProductDal>();

        builder.RegisterType<CategoryManager>().As<ICategoryService>();
        builder.RegisterType<EfCategoryDal>().As<ICategoryDal>();

        builder.RegisterType<UserManager>().As<IUserService>();
        builder.RegisterType<EfUserDal>().As<IUserDal>();
    }
}
