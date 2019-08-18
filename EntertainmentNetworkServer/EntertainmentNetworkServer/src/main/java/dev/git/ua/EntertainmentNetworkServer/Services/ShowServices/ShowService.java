package dev.git.ua.EntertainmentNetworkServer.Services.ShowServices;

import java.math.BigDecimal;
import java.util.Date;
import java.util.List;

import javax.jws.*;

import org.apache.commons.lang3.tuple.ImmutablePair;
import org.springframework.beans.factory.annotation.Autowired;

import dev.git.ua.EntertainmentNetworkServer.Dao.*;
import dev.git.ua.EntertainmentNetworkServer.Logger.*;
import dev.git.ua.EntertainmentNetworkServer.Models.*;
import dev.git.ua.EntertainmentNetworkServer.Services.BaseModelService;

@WebService
public class ShowService extends BaseModelService<Show, ShowDao> implements IShowService
{
	@Autowired
	public ShowService(ShowDao showOperations)
	{
		super(showOperations);
	}

	@Log
	@Override
	@WebMethod(operationName="findShowById")
	public List<Show> findById(BigDecimal id)
	{
		return super.findById(id);
	}	

	@Log
	@Override
	@WebMethod(operationName="getShows")
	public List<Show> get() 
	{
		return super.get();
	}
	
	@Log
	@Override
	@WebMethod(operationName="getSimplifiedShowsByDates")
	public List<ImmutablePair<BigDecimal, String>> getSimplifiedShowsByDates(Date startDt, Date endDt) 
	{
		return this.daoOperations.getSimplifiedShowsByDates(startDt, endDt);
	}

	@Log
	@Override
	@WebMethod(operationName="removeShow")
	public void remove(BigDecimal id) throws ServiceException 
	{
		super.remove(id);	
	}

	@Log
	@Override
	@WebMethod(operationName="saveShows")
	public List<Show> save(List<Show> entities) 
	{
		return super.save(entities);	
	}
}
