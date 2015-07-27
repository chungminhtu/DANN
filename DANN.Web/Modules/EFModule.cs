using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Autofac;
using DANN.Model;

namespace DANN.Web.Modules
{
    public class EFModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType(typeof(DANNContext)).As(typeof(IContext)).InstancePerLifetimeScope();

        }

    }
}