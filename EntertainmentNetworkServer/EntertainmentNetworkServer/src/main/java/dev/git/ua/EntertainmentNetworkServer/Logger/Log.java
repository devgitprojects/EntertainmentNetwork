package dev.git.ua.EntertainmentNetworkServer.Logger;

import java.lang.annotation.*;

@Retention(value = RetentionPolicy.RUNTIME)
@Target(value = { ElementType.TYPE, ElementType.METHOD })
public @interface Log 
{

}

