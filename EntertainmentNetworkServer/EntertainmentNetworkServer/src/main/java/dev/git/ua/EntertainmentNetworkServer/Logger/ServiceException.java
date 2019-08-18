package dev.git.ua.EntertainmentNetworkServer.Logger;

public class ServiceException extends Exception 
{
	private static final long serialVersionUID = -7488750884600208444L;

	public ServiceException(String message) 
	{
		super(message);
	}
	
	public ServiceException(String message, Throwable cause) 
	{
		super(message, cause);
	}
}
