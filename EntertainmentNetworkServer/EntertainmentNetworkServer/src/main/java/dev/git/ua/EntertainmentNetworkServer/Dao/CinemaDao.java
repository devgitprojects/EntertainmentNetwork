package dev.git.ua.EntertainmentNetworkServer.Dao;
// Generated Feb 9, 2018 5:32:55 PM by Hibernate Tools 3.5.0.Final


import java.math.BigDecimal;
import java.util.*;

import org.apache.commons.lang3.tuple.ImmutableTriple;
import org.hibernate.*;
import org.hibernate.criterion.*;
import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

import dev.git.ua.EntertainmentNetworkServer.Logger.Log;
import dev.git.ua.EntertainmentNetworkServer.Models.*;

/**
 * Home object for domain model class Cinema.
 * @see dev.git.ua.EntertainmentNetworkServer.Models.Cinema
 * @author Hibernate Tools
 */
@Repository
@Transactional
public class CinemaDao extends HibernateDaoOperations<Cinema>
{	
	public CinemaDao()
	{
		super(Cinema.class);
	}
	
	@Log
	@Override	
	public Cinema save(Cinema cinema)
	{
		if(cinema.getCinId() != null)	
		{
			Cinema loaded = this.load(Cinema.class, cinema.getCinId());

			this.DeleteHalls(loaded.getHalls(), cinema.getHalls());
			
			for(Hall hall : cinema.getHalls())
			{
				for(Hall loadedHall : loaded.getHalls())
				{
					this.DeleteSection(loadedHall.getSections(), hall.getSections());
					
					for(Section section : hall.getSections())
					{
						for(Section loadedSection : loadedHall.getSections())
						{
							this.DeleteSeats(loadedSection.getSeats(), section.getSeats());						
						}
					}
				}
			}			
		}
		
		return super.save(cinema);			
	}
	
	@Log
	public List<ImmutableTriple<BigDecimal, String, BigDecimal>> getSimplifiedCinemasByCityIdShowId(BigDecimal cityId, BigDecimal showId)
	{	
		List<ImmutableTriple<BigDecimal, String, BigDecimal>> pairs = new ArrayList<ImmutableTriple<BigDecimal, String, BigDecimal>>();
		Criteria query = this.getSeession().createCriteria(this.getModel(), "cinema");
		
	    if(cityId != null)
		{
			City city = this.load(City.class, cityId);
			query = query.add(Restrictions.eq("city", city));
		}
		
	    if(showId != null)
		{
			Show show = this.load(Show.class, showId);
			query = query
					.createAlias("cinema.halls", "halls")
					.createAlias("halls.schedulers", "schedulers")
						.add(Restrictions.eq("schedulers.show", show));
		}
	    
	    @SuppressWarnings("unchecked")
		List<Object[]> cinemas = query.setProjection(Projections.projectionList()
	    		.add(Projections.groupProperty("cinId"))
	    		.add(Projections.groupProperty("cinName"))
	    		.add(Projections.groupProperty("city"))).list();
	    			    	 
	    for(Object[] cinema : cinemas)
	    {
	    	pairs.add(new ImmutableTriple<BigDecimal, String, BigDecimal>(
	    			(BigDecimal)cinema[0], (String)cinema[1], ((City)cinema[2]).getCitId()));
	    }
	    
	    return pairs;
	}
	
	@Log
	public List<Cinema> findCinemaByName(String name)
	{
		Criteria query = this.getSeession().createCriteria(Cinema.class)
				.add(Restrictions.like("cinName", String.format("%%%s%%", name)))
				.setResultTransformer(CriteriaSpecification.DISTINCT_ROOT_ENTITY);
	    return ListCast(query);
	}
	
	@Log
	public List<Cinema> findCinemaByAddress(String address)
	{
		Criteria query = this.getSeession().createCriteria(Cinema.class)
				.add(Restrictions.like("cinAddress", String.format("%%%s%%", address)))
				.setResultTransformer(CriteriaSpecification.DISTINCT_ROOT_ENTITY);
	    return ListCast(query);
	}
	
	@Log
	public List<Seat> addSeats(List<Seat> seats)
	{	
		List<Seat> merged = new ArrayList<Seat>();
		Session session = this.getSeession();
		int batchSize = Integer.parseInt(getSessionConfig().getProperty("hibernate.jdbc.batch_size"));
		for (int i = 0; i < seats.size(); i++ ) 
		{		
			merged.add((Seat)session.merge(seats.get(i)));
			
		    if (i % batchSize == 0 ) 
		    { 
		        session.flush();
		        session.clear();
		    }
		}
		
		return merged;
	}
	
	private void DeleteHalls(Set<Hall> loaded, Set<Hall> input)
	{
		for(Hall hall : loaded)
		{
			if(!input.contains(hall))
			{
				hall.setCinema(null);
			}
		}
	}
	
	private void DeleteSection(Set<Section> loaded, Set<Section> input)
	{
		for(Section loadedSection : loaded)
		{
			if(!input.contains(loadedSection))
			{
				loadedSection.setHall(null);								
			}
		}
	}
	
	private void DeleteSeats(Set<Seat> loaded, Set<Seat> input)
	{
		for(Seat loadedSeat : loaded)
		{
			if(!input.contains(loadedSeat))
			{
				loadedSeat.setSection(null);								
			}
		}
	}
}
