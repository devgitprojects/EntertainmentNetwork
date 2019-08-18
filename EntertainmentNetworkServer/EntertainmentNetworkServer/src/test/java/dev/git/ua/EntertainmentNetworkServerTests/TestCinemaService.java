package dev.git.ua.EntertainmentNetworkServerTests;

import java.math.BigDecimal;
import java.util.*;

import org.apache.commons.lang3.*;
import org.apache.commons.lang3.tuple.ImmutableTriple;
import org.junit.*;
import org.junit.runner.RunWith;
import org.springframework.test.context.ContextConfiguration;
import org.springframework.test.context.junit4.SpringJUnit4ClassRunner;

import dev.git.ua.EntertainmentNetworkServer.AppConfiguration;
import dev.git.ua.EntertainmentNetworkServer.Dao.CinemaDao;
import dev.git.ua.EntertainmentNetworkServer.Logger.ServiceException;
import dev.git.ua.EntertainmentNetworkServer.Models.*;
import dev.git.ua.EntertainmentNetworkServer.Services.CinemaServices.CinemaService;
import junit.framework.Assert;

import static org.mockito.Mockito.*;

@SuppressWarnings("unchecked")
@RunWith(SpringJUnit4ClassRunner.class)
@ContextConfiguration(classes = {AppConfiguration.class})
public class TestCinemaService extends TestBaseModelService
{
	@BeforeClass 
	public static void Initialize()
	{
		/* Prepare dao mock */
		mockDao = mock(CinemaDao.class);   
		when(mockDao.getModel()).thenReturn(Cinema.class);
		/* Prepare service */
		service = new CinemaService(mockDao);
		City city = new City();
		result = new ArrayList<Cinema>();
		result.add(new Cinema(new BigDecimal(1), city, RandomStringUtils.randomAlphabetic(varchar100), RandomStringUtils.randomAlphabetic(varchar100), new byte[1]));
		result.add(new Cinema(new BigDecimal(2), city, "testName", "testAddress", new byte[1]));
	}
	
	@Test
	public void getSimplifiedCinemasPositive() 
	{	
		List<ImmutableTriple<BigDecimal, String, BigDecimal>> pairs = new ArrayList<ImmutableTriple<BigDecimal, String, BigDecimal>>();
		pairs.add(new ImmutableTriple<BigDecimal, String, BigDecimal>(
				new BigDecimal(RandomUtils.nextInt()), RandomStringUtils.randomAlphabetic(varchar100), new BigDecimal(RandomUtils.nextInt())));
		pairs.add(new ImmutableTriple<BigDecimal, String, BigDecimal>(
				new BigDecimal(RandomUtils.nextInt()), RandomStringUtils.randomAlphabetic(varchar100), new BigDecimal(RandomUtils.nextInt())));
		when(mockDao.getSimplifiedCinemasByCityIdShowId(BigDecimal.ZERO, BigDecimal.ZERO)).thenReturn(pairs);

		/* Check service result */
		Assert.assertEquals(2, service.getSimplifiedCinemasByCityIdShowId(BigDecimal.ZERO, BigDecimal.ZERO).size());
	}
	
	@Test(expected = ServiceException.class)
	public void getSimplifiedCinemasNegative() throws ServiceException 
	{	
		when(mockDao.getSimplifiedCinemasByCityIdShowId(BigDecimal.ZERO, BigDecimal.ZERO)).thenThrow(ServiceException.class);
		service.getSimplifiedCinemasByCityIdShowId(BigDecimal.ZERO, BigDecimal.ZERO);
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
	
	@Test
	public void generateSeatsPositive()
	{
		BigDecimal secId = new BigDecimal(RandomUtils.nextInt());
		Section section = new Section(secId); //, new Hall(flrId, result.get(0), "hallName", new BigDecimal())
		
		List<Seat> seats = new ArrayList<Seat>();
		seats.add(new Seat(null, section, 1, 0, 0, 0, true));
		seats.add(new Seat(null, section, 2, 1, 0, 0, true));
		seats.add(new Seat(null, section, 3, 0, 1, 0, true));
		seats.add(new Seat(null, section, 4, 1, 1, 0, true));
		
		section.setSecName(RandomStringUtils.randomAlphabetic(100));
		section.setHall(new Hall(new BigDecimal(RandomUtils.nextInt()), result.get(0), RandomStringUtils.randomAlphabetic(100)));
						
		when(mockDao.load(Section.class, secId)).thenReturn(section);
		when(mockDao.addSeats(seats)).thenReturn(seats);
		
		List<Seat> serviceResult = service.generateSeats(secId, 2, 2);
		
		Assert.assertNotNull(serviceResult);
		Assert.assertEquals(seats.size(), serviceResult.size());

		Iterator<Seat> serviceIt = serviceResult.iterator();
		Iterator<Seat> expectedIt = seats.iterator();
		
		while(serviceIt.hasNext() && expectedIt.hasNext()) 
		{
		   Assert.assertNotNull(serviceIt.next().getSeatId());
		   Assert.assertEquals(expectedIt.next().getSeatColumn(), serviceIt.next().getSeatColumn());
		   Assert.assertEquals(expectedIt.next().getSeatRow(), serviceIt.next().getSeatRow());
		   Assert.assertEquals(expectedIt.next().getSeatNum(), serviceIt.next().getSeatNum());
		   Assert.assertEquals(expectedIt.next().getSeatType(), serviceIt.next().getSeatType());
		   Assert.assertEquals(expectedIt.next().getSeatIsactive(), serviceIt.next().getSeatIsactive());
		}
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
		List<Cinema> newCities = new ArrayList<Cinema>();
		newCities.add(new Cinema(null, result.get(0).getCity(), result.get(0).getCinName(), result.get(0).getCinAddress(), result.get(0).getCinIcon()));	
		newCities.add(new Cinema(null, result.get(1).getCity(), result.get(1).getCinName(), result.get(1).getCinAddress(), result.get(1).getCinIcon()));
		
		super.savePositive(mockDao, service, newCities, result);
	}
	
	@Test(expected = ServiceException.class)
	public void saveNegative()
	{		
		List<Cinema> newCities = new ArrayList<Cinema>();
		newCities.add(new Cinema());	
		newCities.add(new Cinema(null, null, RandomStringUtils.randomAlphabetic(varchar100 + 1), RandomStringUtils.randomAlphabetic(varchar100), null));
		
		super.saveNegative(mockDao, service, newCities);
	}
	
	@After
	public void resetDaoMock()
	{
		super.resetDaoMock(mockDao, Cinema.class);
	}
	 
	private static CinemaDao mockDao;
	private static CinemaService service;
	private static List<Cinema> result;
}
