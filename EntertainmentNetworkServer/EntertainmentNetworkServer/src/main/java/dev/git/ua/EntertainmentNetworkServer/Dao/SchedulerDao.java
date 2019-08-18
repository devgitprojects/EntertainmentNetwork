package dev.git.ua.EntertainmentNetworkServer.Dao;
// Generated Feb 9, 2018 5:32:55 PM by Hibernate Tools 3.5.0.Final

import java.math.BigDecimal;
import java.util.Date;
import java.util.List;

import org.hibernate.Criteria;
import org.hibernate.criterion.*;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

import dev.git.ua.EntertainmentNetworkServer.Logger.Log;
import dev.git.ua.EntertainmentNetworkServer.Models.*;

/**
 * Home object for domain model class Hall.
 * @see dev.git.ua.EntertainmentNetworkServer.Models.Hall
 * @author Hibernate Tools
 */
@Repository
@Transactional
public class SchedulerDao extends HibernateDaoOperations<Scheduler>
{
	public SchedulerDao()
	{
		super(Scheduler.class);
	}
	
	@Log
	public List<Scheduler> getSchedulersByCinemaHallShowDates(BigDecimal cinemaID, BigDecimal hallId,  BigDecimal showId, Date startDt, Date endDt)
	{
		Criteria query = this.getSeession().createCriteria(Scheduler.class, "sch");
		
		if(cinemaID != null)
		{
			Cinema cin = this.load(Cinema.class, cinemaID);
			query = query.createAlias("sch.hall", "hall").add(Restrictions.eq("hall.cinema", cin));
		}
		
		if(hallId != null)
		{
			Hall hall = this.load(Hall.class, hallId);
			query = query.add(Restrictions.eq("hall", hall));
		}
		
		if(showId != null)
		{
			Show show = this.load(Show.class, showId);
			query = query.add(Restrictions.eq("show", show));
		}
		
		query.add(Restrictions.ge("schTimeFrom", startDt))
			.add(Restrictions.le("schTimeTo", endDt))
			.addOrder(Order.asc("schTimeFrom"))
			.setResultTransformer(CriteriaSpecification.DISTINCT_ROOT_ENTITY);;
		
	    return ListCast(query);
	}
}
