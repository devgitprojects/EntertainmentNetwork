package dev.git.ua.EntertainmentNetworkServer.Services.TicketServices;

import java.math.BigDecimal;
import java.util.List;

import javax.jws.WebMethod;
import javax.jws.WebParam;
import javax.jws.WebService;
import javax.xml.bind.annotation.XmlElement;

import org.springframework.beans.factory.annotation.Autowired;

import dev.git.ua.EntertainmentNetworkServer.Dao.TicketDao;
import dev.git.ua.EntertainmentNetworkServer.Logger.Log;
import dev.git.ua.EntertainmentNetworkServer.Logger.ServiceException;
import dev.git.ua.EntertainmentNetworkServer.Logger.TicketSoldException;
import dev.git.ua.EntertainmentNetworkServer.Models.*;
import dev.git.ua.EntertainmentNetworkServer.Services.BaseModelService;

@WebService
public class TicketService extends BaseModelService<Tickets, TicketDao> implements ITicketService
{
	@Autowired
	public TicketService(TicketDao ticketOperations)
	{
		super(ticketOperations);
	}
	
	@Log
	@Override
	@WebMethod(operationName="findTicketById")
	public List<Tickets> findById(BigDecimal id)
	{
		return super.findById(id);
	}	
	
	@Log
	@Override
	@WebMethod(operationName="generateTicket")
	public Tickets generateTicket(
			@WebParam(name = "schedulerID")@XmlElement(required=true, nillable=false)BigDecimal schedulerID, 
			@WebParam(name = "seatID")@XmlElement(required=true, nillable=false)BigDecimal seatID, 
			@WebParam(name = "sectionID")@XmlElement(required=true, nillable=false)BigDecimal sectionID, 
			@WebParam(name = "showID")@XmlElement(required=true, nillable=false)BigDecimal showID,
			@WebParam(name = "orderID")@XmlElement(required=true, nillable=false)BigDecimal orderID) throws TicketSoldException 
	{
		return this.daoOperations.generateTicket(schedulerID, seatID, sectionID, showID, orderID);
	}
	
	@Log
	@Override
	@WebMethod(operationName="getTickets")
	public List<Tickets> get() 
	{
		return super.get();
	}
	
	@Log
	@Override
	@WebMethod(operationName="getTicketsByScheduleID")
	public List<Tickets> getTicketsByScheduleID(BigDecimal scheduleID) 
	{
		return this.daoOperations.getTicketsByScheduleID(scheduleID);
	}

	@Log
	@Override
	@WebMethod(operationName="removeTicket")
	public void remove(BigDecimal id) throws ServiceException 
	{
		super.remove(id);	
	}

	@Log
	@Override
	@WebMethod(operationName="saveTickets")
	public List<Tickets> save(List<Tickets> entities) 
	{
		return super.save(entities);	
	}
}
