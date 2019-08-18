using System;
using System.Reflection;
using Autofac;
using Autofac.Core;
using DevExpress.Mvvm.POCO;
using EntertainmentNetwork.BL.ViewModels;
using EntertainmentNetwork.DAL;
using EntertainmentNetwork.DAL.CinemaService;
using EntertainmentNetwork.DAL.CityService;
using EntertainmentNetwork.DAL.Models.Interfaces;
using EntertainmentNetwork.DAL.OrdersService;
using EntertainmentNetwork.DAL.SchedulerService;
using EntertainmentNetwork.DAL.ShowService;
using EntertainmentNetwork.DAL.TicketService;

namespace EntertainmentNetworkClient
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<CityRepository>().As<IBaseRepository<ICity>>().WithParameter("cityService", new CityServiceClient()).SingleInstance();
            builder.RegisterType<CinemaRepository>().As<ICinemaRepository>().WithParameter("cinemaService", new CinemaServiceClient()).SingleInstance();
            builder.RegisterType<ShowRepository>().As<IShowRepository>().WithParameter("showService", new ShowServiceClient()).SingleInstance();
            builder.RegisterType<SchedulerRepository>().As<ISchedulerRepository>().WithParameter("schedulerService", new SchedulerServiceClient()).SingleInstance();
            builder.RegisterType<TicketRepository>().As<ITicketRepository>().WithParameter("ticketService", new TicketServiceClient()).SingleInstance();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>().WithParameter("orderService", new OrderServiceClient()).SingleInstance();

            Func<ParameterInfo, IComponentContext, bool> paramName = (prop, context) => prop.Name == "dataSource";
            ResolvedParameter cityParam = new ResolvedParameter(
                (param, context) => param.Name == "cityViewModel", 
                (prop, context) => context.Resolve<CitiesViewModel>());
            ResolvedParameter cinemaEditParam = new ResolvedParameter(
                (param, context) => param.Name == "cinemaEditViewModel", 
                (prop, context) => context.Resolve<CinemaEditViewModel>());
            ResolvedParameter schedulerRepoParam = new ResolvedParameter(paramName, (prop, context) => context.Resolve<ISchedulerRepository>());
            ResolvedParameter cinemaSearchParam = new ResolvedParameter(
                (param, context) => param.Name == "cinemaSearchViewModel", 
                (prop, context) => context.Resolve<CinemasSearchViewModel>());

            builder.RegisterType(ViewModelSource.GetPOCOType(typeof(CitiesViewModel))).As<CitiesViewModel>()
                .WithParameter(paramName, (prop, context) => context.Resolve<IBaseRepository<ICity>>()).SingleInstance();

            builder.RegisterType(ViewModelSource.GetPOCOType(typeof(CinemasSearchViewModel))).As<CinemasSearchViewModel>()
                .WithParameters(new[] 
                {
                    new ResolvedParameter(paramName, (prop, context) => context.Resolve<ICinemaRepository>()),
                    cityParam,
                }).SingleInstance();

            builder.RegisterType(ViewModelSource.GetPOCOType(typeof(ShowSearchViewModel))).As<ShowSearchViewModel>()
                .WithParameter(paramName, (prop, context) => context.Resolve<IShowRepository>());

            builder.RegisterType(ViewModelSource.GetPOCOType(typeof(SchedulerSearchViewModel))).As<SchedulerSearchViewModel>()
                .WithParameter(cinemaSearchParam);           

            builder.RegisterType(ViewModelSource.GetPOCOType(typeof(CinemaEditViewModel))).As<CinemaEditViewModel>()
                .WithParameters(new[] 
                {
                    new ResolvedParameter(paramName, (prop, context) => context.Resolve<ICinemaRepository>()),
                    cityParam,
                }).SingleInstance();

            builder.RegisterType(ViewModelSource.GetPOCOType(typeof(SeatsMapGenerationViewModel))).As<SeatsMapGenerationViewModel>()
                .WithParameter(cinemaEditParam);

            builder.RegisterType(ViewModelSource.GetPOCOType(typeof(ShowEditViewModel))).As<ShowEditViewModel>()
                .WithParameter(paramName, (prop, context) => context.Resolve<IShowRepository>()).SingleInstance();

            builder.RegisterType(ViewModelSource.GetPOCOType(typeof(SchedulerViewModel))).As<SchedulerViewModel>()
                .WithParameters(new[] 
                {
                    new ResolvedParameter(paramName, (prop, context) => context.Resolve<ISchedulerRepository>()),
                    new ResolvedParameter((param, context) => param.Name == "showSearchViewModel", (prop, context) => context.Resolve<ShowSearchViewModel>()),
                    cinemaEditParam,
                });

            builder.RegisterType(ViewModelSource.GetPOCOType(typeof(SchedulerEventEditViewModel))).As<SchedulerEventEditViewModel>()
                .WithParameters(new[] 
                { 
                    new ResolvedParameter(paramName, (prop, context) => context.Resolve<ISchedulerRepository>()),
                    cinemaEditParam,
                });

            builder.RegisterType(ViewModelSource.GetPOCOType(typeof(OrderViewModel))).As<OrderViewModel>()
                .WithParameter(paramName, (prop, context) => context.Resolve<IOrderRepository>());

            builder.RegisterType(ViewModelSource.GetPOCOType(typeof(TicketsViewModel))).As<TicketsViewModel>()
                .WithParameters(new[] 
                { 
                    new ResolvedParameter(paramName, (prop, context) => context.Resolve<ITicketRepository>()),
                    cinemaEditParam,
                    new ResolvedParameter((param, context) => param.Name == "schedulerViewModel", (prop, context) => context.Resolve<SchedulerViewModel>()),
                });
               
            IoC = builder.Build();            
        }

        public static IContainer IoC { get; private set; }
    }
}
