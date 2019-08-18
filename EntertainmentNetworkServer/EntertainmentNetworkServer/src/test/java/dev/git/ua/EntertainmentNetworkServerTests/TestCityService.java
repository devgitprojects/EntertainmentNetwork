package dev.git.ua.EntertainmentNetworkServerTests;

import java.math.BigDecimal;
import java.util.*;

import org.apache.commons.lang3.RandomStringUtils;
import org.junit.*;
import org.junit.runner.RunWith;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

import dev.git.ua.EntertainmentNetworkServer.AppConfiguration;
import dev.git.ua.EntertainmentNetworkServer.Dao.ICrudOperations;
import dev.git.ua.EntertainmentNetworkServer.Logger.ServiceException;
import dev.git.ua.EntertainmentNetworkServer.Models.City;
import dev.git.ua.EntertainmentNetworkServer.Services.CityServices.CityService;

import static org.mockito.Mockito.*;

@SuppressWarnings("unchecked")
@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration(classes = {AppConfiguration.class})
public class TestCityService extends TestBaseModelService
{
	@BeforeClass 
	public static void Initialize()
	{
		/* Prepare dao mock */
		mockDao = (ICrudOperations<City>)mock(ICrudOperations.class);   
		when(mockDao.getModel()).thenReturn(City.class);
		/* Prepare service */
		service = new CityService(mockDao);
		
		result = new ArrayList<City>();
		result.add(new City(new BigDecimal(1), RandomStringUtils.randomAlphabetic(varchar100), RandomStringUtils.randomAlphabetic(varchar100)));
		result.add(new City(new BigDecimal(2), "testName", "testCountry"));
	}
	
	@Test
	public void getPositive() 
	{	
		super.getPositive(mockDao, service, result);
	}
	
	@Test(expected = ServiceException.class)
	public void getNegative() throws ServiceException 
	{
		super.getNegative(mockDao, service);
	}
	
	@Test
	public void findByIdPositive() throws ServiceException 
	{
		super.findByIdPositive(mockDao, service, result);
	}
	
	@Test
	public void findByIdNegative()
	{
		super.findByIdNegative(mockDao, service);
	}
	
	@Test(expected = ServiceException.class)
	public void findByIdNullNegative() throws ServiceException
	{
		super.findByIdNullNegative(mockDao, service);
	}
	
	@Test
	public void removePositive() throws ServiceException 
	{
		super.removePositive(service);
	}
	
	@Test
	public void removeNegative() throws ServiceException 
	{
		super.removeNegative(service);
	}
	
	@Test
	public void removeNullNegative() throws ServiceException 
	{
		super.removeNullNegative(service);
	}
	
	@Test
	public void savePositive()
	{	
		List<City> newCities = new ArrayList<City>();
		newCities.add(new City(null, result.get(0).getCitName(), result.get(0).getCitCountry()));	
		newCities.add(new City(null, result.get(1).getCitName(), result.get(1).getCitCountry()));
		
		super.savePositive(mockDao, service, newCities, result);
	}
	
	@Test(expected = ServiceException.class)
	public void saveNegative()
	{		
		List<City> newCities = new ArrayList<City>();
		newCities.add(new City());	
		newCities.add(new City(null, RandomStringUtils.randomAlphabetic(varchar100 + 1), RandomStringUtils.randomAlphabetic(varchar100)));
		
		super.saveNegative(mockDao, service, newCities);
	}
	
	@After
	public void resetDaoMock()
	{
		super.resetDaoMock(mockDao, City.class);
	}
	 
	private static ICrudOperations<City> mockDao;
	private static CityService service;
	private static List<City> result;
}
