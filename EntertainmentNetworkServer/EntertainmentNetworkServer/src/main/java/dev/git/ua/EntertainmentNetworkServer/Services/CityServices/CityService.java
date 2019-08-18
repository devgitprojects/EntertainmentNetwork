package dev.git.ua.EntertainmentNetworkServer.Services.CityServices;

import java.math.BigDecimal;
import java.util.List;

import javax.jws.WebMethod;
import javax.jws.WebService;

import org.springframework.beans.factory.annotation.Autowired;

import dev.git.ua.EntertainmentNetworkServer.Dao.ICrudOperations;
import dev.git.ua.EntertainmentNetworkServer.Logger.*;
import dev.git.ua.EntertainmentNetworkServer.Models.*;
import dev.git.ua.EntertainmentNetworkServer.Services.BaseModelService;

@Log
@WebService
public class CityService extends BaseModelService<City, ICrudOperations<City>>
{	
	@Autowired
	public CityService(ICrudOperations<City> cityOperations)
	{
		super(cityOperations);
	}

	@Log
	@Override
	@WebMethod(operationName="findCityById")
	public List<City> findById(BigDecimal id)
	{
		return super.findById(id);
	}	

	@Log
	@Override
	@WebMethod(operationName="getCities")
	public List<City> get() 
	{
		return super.get();
	}

	@Log
	@Override
	@WebMethod(operationName="removeCity")
	public void remove(BigDecimal id) throws ServiceException 
	{
		super.remove(id);	
	}

	@Log
	@Override
	@WebMethod(operationName="saveCities")
	public List<City> save(List<City> entities) 
	{
		return super.save(entities);	
	}
}
