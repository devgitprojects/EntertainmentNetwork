package dev.git.ua.EntertainmentNetworkServerTests;

import java.math.BigDecimal;
import java.util.*;

import dev.git.ua.EntertainmentNetworkServer.Dao.ICrudOperations;
import dev.git.ua.EntertainmentNetworkServer.Logger.ServiceException;
import dev.git.ua.EntertainmentNetworkServer.Models.BaseModel;
import dev.git.ua.EntertainmentNetworkServer.Services.IBaseService;
import junit.framework.Assert;

import static org.mockito.Mockito.*;

@SuppressWarnings("unchecked")
public class TestBaseModelService
{	
	public <Model extends BaseModel, Dao extends ICrudOperations<Model>, Service extends IBaseService<Model>>  
	void getPositive(Dao tmockDao, Service tservice, List<Model> tresult) 
	{		
		/* Prepare mock result */
		when(tmockDao.getAll()).thenReturn(tresult);

		/* Check service result */
		Assert.assertEquals(2, tservice.get().size());
	}
	
	public <Model extends BaseModel, Dao extends ICrudOperations<Model>, Service extends IBaseService<Model>>
	void getNegative(Dao tmockDao, Service tservice) throws ServiceException 
	{
		when(tmockDao.getAll()).thenThrow(ServiceException.class);
		tservice.get();
	}
	
	public <Model extends BaseModel, Dao extends ICrudOperations<Model>, Service extends IBaseService<Model>>
	void findByIdPositive(Dao tmockDao, Service tservice, List<Model> tresult) throws ServiceException 
	{
		BigDecimal id = new BigDecimal(1);
		when(tmockDao.findById(id)).thenReturn(tresult.get(0));

		List<Model> serviceResult = tservice.findById(id);

		Assert.assertNotNull("Service result of findById method is null", serviceResult.get(0));
		Assert.assertEquals(id, serviceResult.get(0).getId());
	}
	
	public <Model extends BaseModel, Dao extends ICrudOperations<Model>, Service extends IBaseService<Model>> 
	void findByIdNegative(Dao tmockDao, Service tservice)
	{
		BigDecimal id = new BigDecimal(3);
		when(tmockDao.findById(id)).thenReturn(null);
		List<Model> serviceResult = tservice.findById(id);
		Assert.assertEquals(1, serviceResult.size());
		Assert.assertEquals(null, serviceResult.get(0));
	}
	
	public <Model extends BaseModel, Dao extends ICrudOperations<Model>, Service extends IBaseService<Model>> 
	void findByIdNullNegative(Dao tmockDao, Service tservice) throws ServiceException
	{
		when(tmockDao.findById(null)).thenThrow(ServiceException.class);
		tservice.findById(null);
	}
	
	public <Model extends BaseModel, Service extends IBaseService<Model>> 
	void removePositive(Service tservice) throws ServiceException 
	{
		tservice.remove(new BigDecimal(1));
	}
		
	public <Model extends BaseModel, Service extends IBaseService<Model>>
	void removeNegative(Service tservice) throws ServiceException 
	{
		tservice.remove(new BigDecimal(3));
	}
	
	public  <Model extends BaseModel, Service extends IBaseService<Model>> 
	void removeNullNegative(Service tservice) throws ServiceException 
	{
		tservice.remove(null);
	}
	
	public <Model extends BaseModel, Dao extends ICrudOperations<Model>, Service extends IBaseService<Model>> 
	void savePositive(Dao tmockDao, Service tservice, List<Model> tnewModels, List<Model> tresult)
	{		
		when(tmockDao.save(tnewModels.get(0))).thenReturn(tresult.get(0));
		when(tmockDao.save(tnewModels.get(1))).thenReturn(tresult.get(1));

		List<Model> serviceResult = tservice.save(tnewModels);

		Assert.assertNotNull(serviceResult);
		Assert.assertEquals(2, serviceResult.size());

		Iterator<Model> serviceIt = serviceResult.iterator();
		Iterator<Model> expectedIt = tresult.iterator();
		
		while(serviceIt.hasNext() && expectedIt.hasNext()) 
		{
		   Assert.assertEquals(expectedIt.next(), serviceIt.next());
		}
	}
	
	public <Model extends BaseModel, Dao extends ICrudOperations<Model>, Service extends IBaseService<Model>>
	void saveNegative(Dao tmockDao, Service tservice, List<Model> tnewModels)
	{		
		when(tmockDao.save(tnewModels.get(0))).thenThrow(ServiceException.class);
		when(tmockDao.save(tnewModels.get(1))).thenThrow(ServiceException.class);

		tservice.save(tnewModels);
	}
	
	public <Model extends BaseModel, Dao extends ICrudOperations<Model>>
	void resetDaoMock(Dao tmockDao, Class<Model> modelClass)
	{
		reset(tmockDao);
		when(tmockDao.getModel()).thenReturn(modelClass);
	}
	
	public static final int varchar100 = 100;
}
