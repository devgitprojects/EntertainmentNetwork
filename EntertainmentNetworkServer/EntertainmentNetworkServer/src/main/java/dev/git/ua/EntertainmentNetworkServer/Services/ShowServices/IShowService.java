package dev.git.ua.EntertainmentNetworkServer.Services.ShowServices;

import java.math.BigDecimal;
import java.util.Date;
import java.util.List;

import org.apache.commons.lang3.tuple.ImmutablePair;

import dev.git.ua.EntertainmentNetworkServer.Models.Show;
import dev.git.ua.EntertainmentNetworkServer.Services.IBaseService;

public interface IShowService extends IBaseService<Show>
{
	/**
	 * Returns simplified collection of Shows filtered by data range and represented as pair of ID and Name
	 * @return
	 */
	List<ImmutablePair<BigDecimal, String>> getSimplifiedShowsByDates(Date startDt, Date endDt);
}
