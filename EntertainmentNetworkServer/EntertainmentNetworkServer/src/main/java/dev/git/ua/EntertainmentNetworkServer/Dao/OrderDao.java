package dev.git.ua.EntertainmentNetworkServer.Dao;
// Generated Feb 9, 2018 5:32:55 PM by Hibernate Tools 3.5.0.Final

import java.util.Date;

import org.springframework.stereotype.Repository;
import org.springframework.transaction.annotation.Transactional;

import dev.git.ua.EntertainmentNetworkServer.Models.Orders;

/**
 * Home object for domain model class Hall.
 * @see dev.git.ua.EntertainmentNetworkServer.Models.Hall
 * @author Hibernate Tools
 */
@Repository
@Transactional
public class OrderDao extends HibernateDaoOperations<Orders>
{
	public OrderDao()
	{
		super(Orders.class);
	}
	
	public Orders generateOrder(String orderComment)
	{
		Orders order = new Orders();
		order.setOrdComm(orderComment);
		order.setOrdDate(new Date());
		order = super.save(order);
		return order;
	}	
}
