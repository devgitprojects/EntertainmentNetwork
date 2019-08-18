package dev.git.ua.EntertainmentNetworkServer.Services.CinemaServices;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.List;

import javax.jws.*;
import javax.xml.bind.annotation.XmlElement;

import org.apache.commons.lang3.tuple.ImmutableTriple;
import org.springframework.beans.factory.annotation.Autowired;

import dev.git.ua.EntertainmentNetworkServer.Dao.*;
import dev.git.ua.EntertainmentNetworkServer.Logger.*;
import dev.git.ua.EntertainmentNetworkServer.Models.*;
import dev.git.ua.EntertainmentNetworkServer.Services.BaseModelService;

@WebService
public class CinemaService extends BaseModelService<Cinema, CinemaDao> implements ICinemaService
{
	@Autowired
	public CinemaService(CinemaDao cinemaOperations)
	{
		super(cinemaOperations);
	}
	
	@Log
	@Override
	@WebMethod(operationName="generateSeats")
	public List<Seat> generateSeats(BigDecimal secId, int seatRows, int seatColumns) 
	{
		List<Seat> seats = new ArrayList<Seat>();
		Section section = this.daoOperations.load(Section.class, secId);

		int seatNum = 1;
		for(int row = 0; row < seatRows; row++)
		{
			for(int column = 0; column < seatColumns; column++)
			{
				Seat seat = new Seat();
				seat.setSection(section);
				seat.setSeatNum(seatNum++);
				seat.setSeatRow(row);
				seat.setSeatColumn(column);
				seat.setSeatType(0);
				seat.setSeatIsactive(true);
				seats.add(seat);
	        }
        }
		
		return this.daoOperations.addSeats(seats);		
	}
	
	@Log
	@Override
	@WebMethod(operationName="getCinemas")
	public List<Cinema> get() 
	{
		return super.get();
	}
	
	@Log
	@Override
	@WebMethod(operationName="getSimplifiedCinemasByCityIdShowId")
	public List<ImmutableTriple<BigDecimal, String, BigDecimal>> getSimplifiedCinemasByCityIdShowId(
			@WebParam(name = "cityId")@XmlElement(required=false, nillable=true)BigDecimal cityId, 
			@WebParam(name = "showId")@XmlElement(required=false, nillable=true)BigDecimal showId)
	{		
		return this.daoOperations.getSimplifiedCinemasByCityIdShowId(cityId, showId);
	}
	
	@Log
	@Override
	@WebMethod(operationName="findCinemaById")
	public List<Cinema> findById(BigDecimal id) 
	{
		return super.findById(id);
	}
	
	@Log
	@Override
	@WebMethod(operationName="removeCinema")
	public void remove(BigDecimal id) throws ServiceException
	{
		super.remove(id);
	}
		
	@Log
	@Override
	@WebMethod(operationName="saveCinemas")
	public List<Cinema> save(List<Cinema> entities)
	{		
		return super.save(entities);			
	}
}
