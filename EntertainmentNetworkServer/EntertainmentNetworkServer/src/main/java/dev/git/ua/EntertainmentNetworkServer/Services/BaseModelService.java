package dev.git.ua.EntertainmentNetworkServer.Services;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.List;

import javax.jws.*;

import dev.git.ua.EntertainmentNetworkServer.Dao.ICrudOperations;
import dev.git.ua.EntertainmentNetworkServer.Logger.Log;
import dev.git.ua.EntertainmentNetworkServer.Logger.ServiceException;
import dev.git.ua.EntertainmentNetworkServer.Models.BaseModel;

/**
 * @author test
 * Represents base implementation for service that uses dao implementation for model of type T
 * 
 * @param <T>
 * @param <Dao>
 */
@WebService
public abstract class BaseModelService<T extends BaseModel, Dao extends ICrudOperations<T>> implements IBaseService<T>
{ 	 
	public BaseModelService(Dao daoOperations)
	{
		this.daoOperations = daoOperations;
	}
	
	@Log
    @Override
	public List<T> findById(BigDecimal id)
	{
		List<T> list = new ArrayList<T>();
		list.add(this.daoOperations.findById(id));
		return list;
	}	

	@Log
	@Override
	public List<T> get() 
	{
		return this.daoOperations.getAll();
	}

	@Log
	@Override
	public void remove(BigDecimal id) throws ServiceException 
	{	
		T entity = null;
		try 
		{
			entity = this.daoOperations.getModel().getDeclaredConstructor(BigDecimal.class).newInstance(id);
		}
		catch (Exception e) 
		{
			throw new ServiceException(String.format("Entity of type T with *.ctor arguemnt %s could not be created", id), e);
		}
		
		if(entity != null)
		{
			this.daoOperations.remove(entity);
		}		
	}

	@Log
	@Override
	public List<T> save(List<T> entities) 
	{
		List<T> merged = new ArrayList<T>();
		for(T entity : entities)
		{	
			merged.add(this.daoOperations.save(entity));			
		}
		
		return merged;	
	}
	
	/**
	 * Represents dao operation for model of type T
	 */
	protected Dao daoOperations;
}
