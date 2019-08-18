package dev.git.ua.EntertainmentNetworkServer.Dao;

import java.math.BigDecimal;
import java.util.List;

import dev.git.ua.EntertainmentNetworkServer.Models.BaseModel;

/**
 * @author test
 * Represents common operation for get/set entity of type T to data source
 * 
 * @param <T>
 */
public interface ICrudOperations<T> 
{
	/**
	 * Finds entity by ID
	 * 
	 * @param id
	 * @return
	 */
	T findById(BigDecimal id);

	/**
	 * Gets all entities of type T
	 * @return
	 */
	List<T> getAll();
	
	/**
	 * Gets type of model (T)
	 * @return
	 */
	Class<T> getModel();
	
	/**
	 * Loads proxy for entity
	 * @param model
	 * @param id
	 * @return
	 */
	<M extends BaseModel> M load(Class<M> model, BigDecimal id);
	
	/**
	 * @param persistentInstance
	 */
	void remove(T persistentInstance);	

	/**
	 * Saves (merge) instance to data source
	 * @param detachedInstance
	 * @return
	 */
	T save(T detachedInstance);
}