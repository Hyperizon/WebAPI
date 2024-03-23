using Autofac;
using Business.Concretes;
using Business.Abstracts;
using DataAccess.Concretes.EntityFramework;
using DataAccess.Abstracts;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;

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

        var assembly = System.Reflection.Assembly.GetExecutingAssembly();
        builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new ProxyGenerationOptions()
        {
            Selector = new AspectInterceptorSelector()
        }).SingleInstance();

    }
}
