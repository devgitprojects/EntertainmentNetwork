package dev.git.ua.EntertainmentNetworkServer.Services.TicketServices;

import java.math.BigDecimal;
import java.util.List;

import dev.git.ua.EntertainmentNetworkServer.Logger.TicketSoldException;
import dev.git.ua.EntertainmentNetworkServer.Models.Tickets;
import dev.git.ua.EntertainmentNetworkServer.Services.IBaseService;

public interface ITicketService extends IBaseService<Tickets>
{
	List<Tickets> getTicketsByScheduleID(BigDecimal scheduleID);
	Tickets generateTicket(BigDecimal schedulerID, BigDecimal seatID, BigDecimal sectionID, BigDecimal showID, BigDecimal orderID) throws TicketSoldException;
}
