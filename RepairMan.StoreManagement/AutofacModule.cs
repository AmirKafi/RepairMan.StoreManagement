using Autofac;
using RepairMan.StoreManagement.Data;

namespace RepairMan.StoreManagement
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            Bootstrapper.WireUp(builder);
        }
    }
}
