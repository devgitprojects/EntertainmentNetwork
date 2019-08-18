package dev.git.ua.EntertainmentNetworkServer;

import javax.xml.ws.Endpoint;

import org.springframework.boot.web.support.SpringBootServletInitializer;
import org.springframework.context.annotation.AnnotationConfigApplicationContext;
import org.springframework.web.WebApplicationInitializer;

import dev.git.ua.EntertainmentNetworkServer.Services.CinemaServices.CinemaService;
import dev.git.ua.EntertainmentNetworkServer.Services.CityServices.CityService;
import dev.git.ua.EntertainmentNetworkServer.Services.OrderService.OrderService;
import dev.git.ua.EntertainmentNetworkServer.Services.SchedulerServices.SchedulerService;
import dev.git.ua.EntertainmentNetworkServer.Services.ShowServices.ShowService;
import dev.git.ua.EntertainmentNetworkServer.Services.TicketServices.TicketService;

public class App extends SpringBootServletInitializer implements WebApplicationInitializer
{	
	public static void main( String[] args )
    {
    	@SuppressWarnings("resource")
    	AnnotationConfigApplicationContext context = new AnnotationConfigApplicationContext(AppConfiguration.class);   
    	
    	Endpoint.publish("http://PC-TEST:8081/CinemaService", context.getBean(CinemaService.class));
    	Endpoint.publish("http://PC-TEST:8081/CityService", context.getBean(CityService.class));
    	Endpoint.publish("http://PC-TEST:8081/SchedulerService", context.getBean(SchedulerService.class));
    	Endpoint.publish("http://PC-TEST:8081/ShowService", context.getBean(ShowService.class));
    	Endpoint.publish("http://PC-TEST:8081/TicketService", context.getBean(TicketService.class));
    	Endpoint.publish("http://PC-TEST:8081/OrdersService", context.getBean(OrderService.class));
    }
}
