package dev.git.ua.EntertainmentNetworkServer.Services.SchedulerServices;

import java.math.BigDecimal;
import java.util.Date;
import java.util.List;

import javax.jws.WebMethod;
import javax.jws.WebParam;
import javax.jws.WebService;
import javax.xml.bind.annotation.XmlElement;

import org.springframework.beans.factory.annotation.Autowired;

import dev.git.ua.EntertainmentNetworkServer.Dao.*;
import dev.git.ua.EntertainmentNetworkServer.Logger.Log;
import dev.git.ua.EntertainmentNetworkServer.Logger.ServiceException;
import dev.git.ua.EntertainmentNetworkServer.Models.*;
import dev.git.ua.EntertainmentNetworkServer.Services.BaseModelService;

@Log
@WebService
public class SchedulerService extends BaseModelService<Scheduler, SchedulerDao> implements ISchedulerService
{
	@Autowired
	public SchedulerService(SchedulerDao schedulerOperations)
	{
		super(schedulerOperations);
	}

	@Log
	@Override
	@WebMethod(operationName="findSchedulerById")
	public List<Scheduler> findById(BigDecimal id) 
	{
		return super.findById(id);
	}
	
	@Log
	@Override
	@WebMethod(operationName="getSchedulers")
	public List<Scheduler> get() 
	{
		return super.get();
	}
	
	@Log
	@Override
	@WebMethod(operationName="getSchedulersByCinemaHallShowDates")
	public List<Scheduler> getSchedulersByCinemaHallShowDates(
			@WebParam(name = "cinemaID")@XmlElement(required=false, nillable=true)BigDecimal cinemaID, 
			@WebParam(name = "hallId")@XmlElement(required=false, nillable=true)BigDecimal hallId, 
			@WebParam(name = "showId")@XmlElement(required=false, nillable=true)BigDecimal showId,
			@WebParam(name = "startDt")@XmlElement(required=true, nillable=false)Date startDt, 
			@WebParam(name = "endDt")@XmlElement(required=true, nillable=false)Date endDt)
	{
		return this.daoOperations.getSchedulersByCinemaHallShowDates(cinemaID, hallId, showId, startDt, endDt);
	}

	@Log
	@Override
	@WebMethod(operationName="removeScheduler")
	public void remove(BigDecimal id) throws ServiceException
	{
		super.remove(id);
	}
	
	@Log
	@Override
	@WebMethod(operationName="saveSchedulers")
	public List<Scheduler> save(List<Scheduler> entities)
	{
		return super.save(entities);	
	}
}
