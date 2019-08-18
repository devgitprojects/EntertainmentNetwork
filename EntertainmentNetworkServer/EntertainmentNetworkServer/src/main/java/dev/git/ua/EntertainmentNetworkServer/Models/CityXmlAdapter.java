package dev.git.ua.EntertainmentNetworkServer.Models;


import java.math.BigDecimal;

import javax.xml.bind.annotation.adapters.XmlAdapter;

import org.apache.commons.lang.StringUtils;

import dev.git.ua.EntertainmentNetworkServer.Logger.Log;

public class CityXmlAdapter extends XmlAdapter<String, City>
{	 
	@Log
	@Override
	public String marshal(City entity) throws Exception
	{
		return String.valueOf(entity.getCitId());
	}
	
	@Log
	@Override
	public City unmarshal(String id) throws Exception 
	{
		return StringUtils.isNumeric(id) ? new City(new BigDecimal(id)) : null;
	}       
}
