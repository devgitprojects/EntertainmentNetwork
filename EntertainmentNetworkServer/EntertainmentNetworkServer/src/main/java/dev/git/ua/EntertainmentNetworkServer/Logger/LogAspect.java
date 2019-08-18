package dev.git.ua.EntertainmentNetworkServer.Logger;

import org.springframework.stereotype.Component;
import org.apache.commons.lang3.exception.ExceptionUtils;
import org.apache.log4j.Logger;
import org.aspectj.lang.*;
import org.aspectj.lang.annotation.*;

@Aspect
@Component
public class LogAspect
{		
	@AfterThrowing(pointcut = "@annotation(Log)", throwing = "ex")
    public void logException(JoinPoint jp, Throwable ex) throws ServiceException
	{
		if(ex instanceof ServiceException)
		{
			throw (ServiceException)ex;
		}
		else
		{
			this.getLog(jp).error(ex, ex);
			throw new ServiceException("One or more service errors occur: " + ExceptionUtils.getRootCauseMessage(ex), ex);
		}
    }
  
    public static Logger getLog(String name)
    {
        return Logger.getLogger(name);
    }
    
    /**
     * Get a logger in the context of the class instead of the
     * context of the interceptor. Otherwise every log message
     * will look like it's coming from here.
     *
     * @param jp
     * @return
     */
    private Logger getLog(JoinPoint jp)
    {
    	Logger logger = Logger.getLogger(jp.getTarget().getClass());
        return logger;
    }
}
