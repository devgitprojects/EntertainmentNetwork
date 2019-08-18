package dev.git.ua.EntertainmentNetworkServer.Models;

import java.math.BigDecimal;
import java.util.Objects;

import javax.xml.bind.annotation.*;

/**
 * Represents common class for all entities
 * @author test
 */
@XmlAccessorType(XmlAccessType.FIELD)
public class BaseModel 
{
	protected BaseModel()
	{	
	}
	
	public BaseModel(BigDecimal id, String name)
	{	
		this.id = id;
		this.name = name;
	}
	
	public BigDecimal getId() 
	{
		return id;
	}	

	public String getName() 
	{
		return name;
	}
	
	/**
	 * Check equility of classes inherited from BaseModel by id, name and type of instance
	 */
	@Override
	public boolean equals(Object obj)
	{
		boolean result = this == obj && obj instanceof BaseModel && obj.getClass().equals(this.getClass());
		
		if(result)
		{
			BaseModel other = (BaseModel)obj;    
			result = other.id == this.id && other.id == this.id;
		}
		
		return result;
	}
	   
	@Override
	public int hashCode()
	{
	   return Objects.hash(this.id, this.name, this.getClass());
	}
    
	/**
	 * String representation of ID of entity inherited from BaseModel
	 */
	@Override
	public String toString()
	{
		return "[Id=" + String.valueOf(this.id) + "]";
	}
	
	protected BigDecimal id;
	protected String name;
}
