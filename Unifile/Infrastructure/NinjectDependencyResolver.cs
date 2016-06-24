using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer.Services;
using BusinessLogicLayerInterface.ServiceInterfaces;
using DataAccessLayer.SQLRepository;
using DataAccessLayerInterface.RepositoryInterfaces;
using EFModel;
using Ninject;

namespace Unifile.Infrastructure
{
    public class NinjectDependencyResolver: IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            kernel.Bind<DbContext>().To<EFModelContext>();

            kernel.Bind<IRoleRepository>().To<SqlRoleRepository>();
            kernel.Bind<IUserRepository>().To<SqlUserRepository>();
            kernel.Bind<ICategoryRepository>().To<SqlCategoryRepository>();
            kernel.Bind<ICardRepository>().To<SqlCardRepository>();
            kernel.Bind<IAudioFileRepository>().To<SqlAudioFileRepository>();
            kernel.Bind<IAudioGenreRepository>().To<SqlAudioGenreRepository>();
            kernel.Bind<IImageRepository>().To<SqlImageRepository>();
            kernel.Bind<ITextFileRepository>().To<SqlTextFileRepository>();

            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IRoleService>().To<RoleService>();
            kernel.Bind<ICategoryService>().To<CategoryService>();
            kernel.Bind<ICardService>().To<CardService>();
            kernel.Bind<IAudioFileService>().To<AudioFileService>();
            kernel.Bind<IAudioGenreService>().To<AudioGenreService>();
            kernel.Bind<IImageService>().To<ImageService>();
            kernel.Bind<ITextFileService>().To<TextFileService>();
        }

    }
}