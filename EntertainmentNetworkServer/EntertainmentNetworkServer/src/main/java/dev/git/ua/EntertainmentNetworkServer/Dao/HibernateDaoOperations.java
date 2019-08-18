package dev.git.ua.EntertainmentNetworkServer.Dao;
// Generated Feb 9, 2018 5:32:55 PM by Hibernate Tools 3.5.0.Final

import java.math.BigDecimal;
import java.util.List;

import org.hibernate.*;
import org.hibernate.cfg.Configuration;
import org.hibernate.criterion.CriteriaSpecification;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.transaction.annotation.Transactional;

import dev.git.ua.EntertainmentNetworkServer.Logger.Log;
import dev.git.ua.EntertainmentNetworkServer.Models.BaseModel;

/**
 * Represents hibernate base dao operations for T model
 * @author test
 *
 * @param <T>
 */
@Transactional
public class HibernateDaoOperations<T extends BaseModel> implements ICrudOperations<T>
{
	/**
	 * @param model
	 */
	public HibernateDaoOperations(Class<T> model)
	{
		this.model = model;
	}

	/** {@inheritDoc} */
	@Override
	public Class<T> getModel()
	{
		return this.model;		
	}

	/* 
	 * Performs removing item to DB
	 * {@inheritDoc}
	 */
	@Override
	@Log
	public void remove(T persistentInstance)
	{
		this.getSeession().delete(persistentInstance);
	}

	/** 
	 * Performs merging (updating) item to DB
	 {@inheritDoc}
	 */
	@SuppressWarnings("unchecked")
	@Log
	@Override
	public T save(T detachedInstance)
	{
		return (T) this.getSeession().merge(detachedInstance);
	}

	/**
	 * Finds item by ID
	 * {@inheritDoc}
	 */
	@Override
	@Log
	public T findById(BigDecimal id)
	{		
		return this.getSeession().get(model, id);
	}
	
	/** 
	 * Returns collection of items of type T
	 * {@inheritDoc}
	 */
	@Override
	@Log
	public List<T> getAll()
	{
	    return this.ListCast(this.getSeession()
	    		.createCriteria(this.getModel())
	    		.setResultTransformer(CriteriaSpecification.DISTINCT_ROOT_ENTITY));
	}
	
	/** 
	 * Loads proxy of model of type M
	 * {@inheritDoc}
	 */
	@Log
	@Override
	public <M extends BaseModel> M load(Class<M> model, BigDecimal id) 
	{
		return this.getSeession().load(model, id);
	}
	
	/**
	 * Opens new Hibernate session
	 * @return
	 */
	public Session getSession()
	{
		return this.factory.openSession();		
	}
	
	protected void flush()
	{
		this.getSeession().flush();
	}
	
	/**
	 * Gets current hibernate config
	 * @return
	 */
	protected Configuration getSessionConfig()
	{
		return this.config;
	}
	
	/**
	 * gets current hibernate ssession
	 * @return
	 */
	protected Session getSeession()
	{
		return this.factory.getCurrentSession();
	}
	
	/**
	 * Casts criteria result list to List of type T (suppresses cast warning)
	 * @param criteria
	 * @return
	 */
	@SuppressWarnings("unchecked")
	protected <X extends BaseModel> List<X>  ListCast(Criteria criteria)
	{
	    return criteria.list();		
	}
	
	/**
	 * Casts query result list to List of type T (suppresses cast warning)
	 * @param query
	 * @return
	 */
	@SuppressWarnings("unchecked")
	protected <X extends BaseModel> List<X>  ListCast(Query query)
	{
	    return query.list();		
	}
	
	/**
	 * Represents hibernate factory for communication with DB
	 */
	@Autowired
	private SessionFactory factory;
	
	/**
	 * Represents hibernate configuration
	 */
	@Autowired
	private Configuration config;

	/**
	 * Represents type of model that is handled
	 */
	private final Class<T> model;
}

