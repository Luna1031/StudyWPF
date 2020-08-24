using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using SubModule.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubModule
{
    public class ModuleLoader : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(SubViewA));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry) { }

    }
}
