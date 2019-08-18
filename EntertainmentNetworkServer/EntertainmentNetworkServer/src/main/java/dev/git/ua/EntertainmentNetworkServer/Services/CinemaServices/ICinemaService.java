package dev.git.ua.EntertainmentNetworkServer.Services.CinemaServices;

import java.math.BigDecimal;
import java.util.List;

import org.apache.commons.lang3.tuple.ImmutableTriple;

import dev.git.ua.EntertainmentNetworkServer.Models.*;
import dev.git.ua.EntertainmentNetworkServer.Services.IBaseService;

/**
 * Represents CinemaService class
 * @author test
 *
 */
public interface ICinemaService extends IBaseService<Cinema>
{	

	/**
	 * Generates seats table related to floor id
	 * @param flrId
	 * @param seatRows
	 * @param seatColumns
	 * @return
	 */
	List<Seat> generateSeats(BigDecimal flrId, int seatRows, int seatColumns);
	
	/**
	 * Returns simplified collection of Cinemas represented as pair of ID and Name
	 * @return
	 */
	List<ImmutableTriple<BigDecimal, String, BigDecimal>> getSimplifiedCinemasByCityIdShowId(BigDecimal cityId, BigDecimal showId);
}
