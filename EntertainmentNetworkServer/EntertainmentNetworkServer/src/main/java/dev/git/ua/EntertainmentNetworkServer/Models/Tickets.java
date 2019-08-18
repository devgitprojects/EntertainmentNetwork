package dev.git.ua.EntertainmentNetworkServer.Models;
// Generated Mar 14, 2018 11:11:06 AM by Hibernate Tools 3.6.0.Final

import java.math.BigDecimal;
import javax.persistence.*;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlTransient;
import javax.xml.bind.annotation.XmlType;

/**
 * Tickets generated by hbm2java
 */
@SuppressWarnings("serial")
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType
@Entity
@Table(name = "TICKETS", schema = "TEST")
public class Tickets extends BaseModel  implements java.io.Serializable
{
	public Tickets() 
	{
	}

	public Tickets(BigDecimal tctId, Scheduler scheduler, Seat seat, Orders orders, BigDecimal tctPrice,
			boolean tctIssold) {
		this.id = tctId;
		this.scheduler = scheduler;
		this.seat = seat;
		this.orders = orders;
		this.tctPrice = tctPrice;
		this.tctIssold = tctIssold;
	}

	@Id
	@GeneratedValue(strategy = GenerationType.SEQUENCE, generator = "TCT_SEQ")
    @SequenceGenerator(name = "TCT_SEQ", sequenceName = "TCT_SEQ", allocationSize = 1)
	@Column(name = "TCT_ID", unique = true, nullable = false, precision = 22, scale = 0)
	public BigDecimal getTctId()
	{
		return this.id;
	}

	public void setTctId(BigDecimal tctId) 
	{
		this.id = tctId;
	}

	@ManyToOne(fetch = FetchType.EAGER)
	@JoinColumn(name = "TCT_SCH_ID", nullable = false)
	public Scheduler getScheduler() 
	{
		return this.scheduler;
	}

	public void setScheduler(Scheduler scheduler)
	{
		this.scheduler = scheduler;
	}

	@ManyToOne(fetch = FetchType.EAGER)
	@JoinColumn(name = "TCT_SEAT_ID", nullable = false)
	public Seat getSeat() 
	{
		return this.seat;
	}

	public void setSeat(Seat seat) 
	{
		this.seat = seat;
	}
	
	@ManyToOne(fetch = FetchType.LAZY)
	@JoinColumn(name = "TCT_ORD_ID", nullable = false)
	public Orders getOrders()
	{
		return this.orders;
	}

	public void setOrders(Orders orders) 
	{
		this.orders = orders;
	}
	
	@Transient
	@XmlElement
	public BigDecimal getOrdersId()
	{
		return this.getOrders() == null ? new BigDecimal("-1") : this.getOrders().getOrdId();
	}
	
	public void setOrdersId(BigDecimal id)
	{
		this.setOrders(new Orders(id));
	}
	
	@Column(name = "TCT_PRICE", nullable = false, precision = 22, scale = 0)
	public BigDecimal getTctPrice()
	{
		return this.tctPrice;
	}

	public void setTctPrice(BigDecimal tctPrice) 
	{
		this.tctPrice = tctPrice;
	}

	@Column(name = "TCT_ISSOLD", nullable = false, precision = 1, scale = 0)
	public boolean isTctIssold() 
	{
		return this.tctIssold;
	}

	public void setTctIssold(boolean tctIssold)
	{
		this.tctIssold = tctIssold;
	}

	private Scheduler scheduler;
	private Seat seat;
	@XmlTransient
	private Orders orders;
	private BigDecimal tctPrice;
	private boolean tctIssold;
}
