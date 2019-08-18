package dev.git.ua.EntertainmentNetworkServer.Services;

import java.math.BigDecimal;
import java.util.*;

import dev.git.ua.EntertainmentNetworkServer.Logger.ServiceException;
import dev.git.ua.EntertainmentNetworkServer.Models.BaseModel;

/**
 * Common web service representation
 * @author test
 *
 * @param <T>
 */
public interface IBaseService<T extends BaseModel>
{
	/**
	 * Returns entity of type T by ID
	 * @param id
	 * @return
	 */
	public List<T> findById(BigDecimal id);

	/**
	 * Returns all entities of type T
	 * @return
	 */
	public List<T> get();

	/** 
	 * Removes entity by ID
	 * @param id
	 * @throws ServiceException 
	 */
	public void remove(BigDecimal id) throws ServiceException;

	/**
	 * Save (merge) entities of type T
	 * @param entities
	 * @return
	 */
	public List<T> save(List<T> entities);
}
