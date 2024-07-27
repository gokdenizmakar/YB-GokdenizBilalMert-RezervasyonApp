using Autofac;

namespace YB.Business.DependicyInjection.AutoFac
{
    public class InstanceFactory
    {
        public static T GetInstance<T>()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<AutofacBusinessModule>();
            IContainer container = builder.Build();
            using (var scope = container.BeginLifetimeScope())
            {
                return scope.Resolve<T>();
            }
        }
    }
}
