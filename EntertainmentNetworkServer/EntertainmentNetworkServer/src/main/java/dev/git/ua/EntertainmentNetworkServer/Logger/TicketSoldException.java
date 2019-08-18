package dev.git.ua.EntertainmentNetworkServer.Logger;

public class TicketSoldException extends ServiceException 
{
	private static final long serialVersionUID = -7488750884600208444L;

	public TicketSoldException(String message) 
	{
		super(message);
	}
	
	public TicketSoldException(String message, Throwable cause) 
	{
		super(message, cause);
	}
}
