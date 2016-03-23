using Autofac;
using Stripe.Client.Sdk.Configuration;

namespace Stripe.Client.Autofac.Modules
{
    public class StripeAppSettingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AppSettingsConfiguration>().As<IStripeConfiguration>();
        }
    }
}