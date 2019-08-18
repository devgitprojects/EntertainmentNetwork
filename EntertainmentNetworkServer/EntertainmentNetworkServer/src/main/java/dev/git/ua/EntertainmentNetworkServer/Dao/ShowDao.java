package dev.git.ua.EntertainmentNetworkServer.Dao;
// Generated Feb 9, 2018 5:32:55 PM by Hibernate Tools 3.5.0.Final

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import org.apache.commons.lang3.tuple.ImmutablePair;
import org.hibernate.criterion.Order;
import org.hibernate.criterion.Projections;
import org.hibernate.criterion.Restrictions;
import org.hibernate.transform.Transformers;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

import dev.git.ua.EntertainmentNetworkServer.Logger.Log;
import dev.git.ua.EntertainmentNetworkServer.Models.Show;

/**
 * Home object for domain model class Hall.
 * @see dev.git.ua.EntertainmentNetworkServer.Models.Hall
 * @author Hibernate Tools
 */
@Repository
@Transactional
public class ShowDao extends HibernateDaoOperations<Show>
{
	public ShowDao()
	{
		super(Show.class);
	}	
	
	@Log
	public List<ImmutablePair<BigDecimal, String>> getSimplifiedShowsByDates(Date startDt, Date endDt)
	{
		List<ImmutablePair<BigDecimal, String>> pairs = new ArrayList<ImmutablePair<BigDecimal, String>>();
		List<Show> shows = ListCast(this.getSeession().createCriteria(Show.class)
			.add(Restrictions.ge("shwStartDt", startDt))
			.add(Restrictions.le("shwEndDt", endDt))
			.addOrder(Order.asc("shwStartDt")).setProjection(Projections.projectionList()
  			      .add(Projections.property("shwId"), "shwId")
  			      .add(Projections.property("shwName"), "shwName"))
			.setResultTransformer(Transformers.aliasToBean(Show.class)));
		
	    for(Show show : shows)
	    {
	    	pairs.add(new ImmutablePair<BigDecimal, String>(show.getShwId(), show.getShwName()));
	    }
	    
	    return pairs;
	}
}
