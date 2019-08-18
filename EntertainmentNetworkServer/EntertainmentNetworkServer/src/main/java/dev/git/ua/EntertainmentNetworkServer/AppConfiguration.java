package dev.git.ua.EntertainmentNetworkServer;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.context.annotation.*;

import dev.git.ua.EntertainmentNetworkServer.Dao.*;
import dev.git.ua.EntertainmentNetworkServer.Models.*;
import dev.git.ua.EntertainmentNetworkServer.Services.CinemaServices.CinemaService;
import dev.git.ua.EntertainmentNetworkServer.Services.CityServices.CityService;
import dev.git.ua.EntertainmentNetworkServer.Services.OrderService.OrderService;
import dev.git.ua.EntertainmentNetworkServer.Services.SchedulerServices.SchedulerService;
import dev.git.ua.EntertainmentNetworkServer.Services.ShowServices.ShowService;
import dev.git.ua.EntertainmentNetworkServer.Services.TicketServices.TicketService;

@Configuration
@ComponentScan(value=
{
		"dev.git.ua.EntertainmentNetworkServer",
		"dev.git.ua.EntertainmentNetworkServer.Dao",
		"dev.git.ua.EntertainmentNetworkServer.Services",
		"dev.git.ua.EntertainmentNetworkServer.Services.CinemaServices",
		"dev.git.ua.EntertainmentNetworkServer.Services.CityServices",
		"dev.git.ua.EntertainmentNetworkServer.Services.SchedulerServices",
		"dev.git.ua.EntertainmentNetworkServer.Logger",
		"dev.git.ua.EntertainmentNetworkServer.Models"})
@EnableAspectJAutoProxy(proxyTargetClass = true)
public class AppConfiguration
{		
	@Bean
	public HibernateDaoOperations<City> cityDao()
	{
		return new HibernateDaoOperations<City>(City.class);
	}
	
	@Bean
	public ShowDao showDao()
	{
		return new ShowDao();
	}
	
	@Bean
	public CinemaDao cinemaDao()
	{
		return new CinemaDao();
	}
	
	@Bean
	public SchedulerDao schedulerDao()
	{
		return new SchedulerDao();
	}
	
	@Bean
	public TicketDao ticketDao()
	{
		return new TicketDao();
	}
	
	@Bean
	public OrderDao orderDao()
	{
		return new OrderDao();
	}
	
	@Bean
	@Autowired
	public CityService cityService(HibernateDaoOperations<City> cityDao)
	{
		return new CityService(cityDao);
	}
	
	@Bean
	@Autowired
	public CinemaService cinemaService(CinemaDao cinemaDao)
	{
		return new CinemaService(cinemaDao);
	}
	
	@Bean
	@Autowired
	public SchedulerService schedulerService(SchedulerDao schedulerDao)
	{
		return new SchedulerService(schedulerDao);
	}
	
	@Bean
	@Autowired
	public ShowService showService(ShowDao showDao)
	{
		return new ShowService(showDao);
	}
	
	@Bean
	@Autowired
	public TicketService ticketService(TicketDao ticketDao)
	{
		return new TicketService(ticketDao);
	}
	
	@Bean
	@Autowired
	public OrderService orderService(OrderDao orderDao)
	{
		return new OrderService(orderDao);
	}
}




