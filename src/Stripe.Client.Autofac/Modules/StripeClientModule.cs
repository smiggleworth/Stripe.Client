using System.Net.Http;
using System.Reflection;
using Autofac;
using Stripe.Client.Sdk.Clients;
using Module = Autofac.Module;

namespace Stripe.Client.Autofac.Modules
{
    public class StripeClientModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var sdk = typeof(IStripeClient).GetTypeInfo().Assembly;

            builder.RegisterType<HttpClient>().AsSelf().InstancePerDependency();

            builder.RegisterAssemblyTypes(sdk)
                .Where(t => t.Name.EndsWith("Client"))
                .AsImplementedInterfaces().InstancePerDependency();
        }
    }
}