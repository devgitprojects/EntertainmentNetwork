package dev.git.ua.EntertainmentNetworkServer.Services.SchedulerServices;

import java.math.BigDecimal;
import java.util.Date;
import java.util.List;

import dev.git.ua.EntertainmentNetworkServer.Models.*;
import dev.git.ua.EntertainmentNetworkServer.Services.IBaseService;

public interface ISchedulerService extends IBaseService<Scheduler>
{
	List<Scheduler> getSchedulersByCinemaHallShowDates(BigDecimal cinemaID, BigDecimal hallId, BigDecimal showID, Date startDt, Date endDt);
}
