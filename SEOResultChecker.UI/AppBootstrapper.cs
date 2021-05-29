using Caliburn.Micro;
using SEOResultChecker.Service;
using SEOResultChecker.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows;

namespace SEOResultChecker.UI
{
    /// <summary>
    /// Caliburn.Micro bootstrapper
    /// </summary>
    public class AppBootstrapper : BootstrapperBase
    {
        // simple DI container bundled with Caliburn.Micro
        private SimpleContainer _container;

        public AppBootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            _container = new SimpleContainer();

            _container.Singleton<IWindowManager, WindowManager>();

            _container.PerRequest<ShellViewModel>();

            _container.RegisterSingleton(typeof(ISearchService), "GoogleSearchService", typeof(GoogleSearchService));
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
}