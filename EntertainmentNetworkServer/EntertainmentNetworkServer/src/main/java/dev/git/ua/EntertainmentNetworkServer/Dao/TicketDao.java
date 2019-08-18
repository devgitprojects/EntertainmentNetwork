package dev.git.ua.EntertainmentNetworkServer.Dao;
// Generated Feb 9, 2018 5:32:55 PM by Hibernate Tools 3.5.0.Final

import java.math.BigDecimal;
import java.util.Collections;
import java.util.List;

import org.hibernate.criterion.CriteriaSpecification;
import org.hibernate.criterion.Order;
import org.hibernate.criterion.Restrictions;
import org.hibernate.exception.ConstraintViolationException;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

import dev.git.ua.EntertainmentNetworkServer.Logger.Log;
import dev.git.ua.EntertainmentNetworkServer.Logger.TicketSoldException;
import dev.git.ua.EntertainmentNetworkServer.Models.Scheduler;
import dev.git.ua.EntertainmentNetworkServer.Models.Seat;
import dev.git.ua.EntertainmentNetworkServer.Models.Section;
import dev.git.ua.EntertainmentNetworkServer.Models.Show;
import dev.git.ua.EntertainmentNetworkServer.Models.Tickets;

/**
 * Home object for domain model class Hall.
 * @see dev.git.ua.EntertainmentNetworkServer.Models.Hall
 * @author Hibernate Tools
 */
@Repository
@Transactional
public class TicketDao extends HibernateDaoOperations<Tickets>
{
	public TicketDao()
	{
		super(Tickets.class);
	}
	
	public Tickets generateTicket(BigDecimal schedulerID, BigDecimal seatID, BigDecimal sectionID, BigDecimal showID, BigDecimal orderID) throws TicketSoldException
	{		
		Scheduler scheduler = this.load(Scheduler.class, schedulerID);
		Section section = this.load(Section.class, sectionID);
		Show show = this.load(Show.class, showID);
		Seat seat = this.load(Seat.class, seatID);
		
		Tickets ticket = new Tickets();
		ticket.setScheduler(scheduler);
		ticket.setSeat(seat);
		ticket.setOrdersId(orderID);
		ticket.setTctPrice(show.getShwPrice().multiply(section.getSecCoef()).multiply(scheduler.getSchCoef()));

		try 
		{
			ticket = super.save(ticket);
			this.flush();
		} catch (ConstraintViolationException e) 
		{			
			if (e.getConstraintName().contains("TCT_UNIQ")) 
			{
				throw new TicketSoldException("Sorry. Ticket has been already sold.");
		    }
			else
			{
				throw e;
			}
		}
		
		return ticket;
	}
	
	@Log
	public List<Tickets> getTicketsByScheduleID(BigDecimal scheduleID)
	{	
		List<Tickets> tickets;
	    if(scheduleID == null)
		{
	    	tickets = Collections.emptyList();	    	
		}
	    else
	    {
	    	Scheduler schedule = this.load(Scheduler.class, scheduleID);    
			tickets = ListCast(this.getSeession().createCriteria(this.getModel())
					.add(Restrictions.eq("scheduler", schedule))
					.addOrder(Order.asc("seat"))
					.setResultTransformer(CriteriaSpecification.DISTINCT_ROOT_ENTITY));		
	    }
	    
	    return tickets;
	}
}
