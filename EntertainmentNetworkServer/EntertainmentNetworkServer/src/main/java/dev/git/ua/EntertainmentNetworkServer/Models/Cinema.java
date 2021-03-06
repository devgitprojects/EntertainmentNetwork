package dev.git.ua.EntertainmentNetworkServer.Models;
// Generated Feb 9, 2018 5:32:55 PM by Hibernate Tools 3.5.0.Final

import java.math.BigDecimal;
import java.util.HashSet;
import java.util.Set;

import javax.persistence.*;
import javax.xml.bind.annotation.*;
import javax.xml.bind.annotation.adapters.XmlJavaTypeAdapter;

import org.hibernate.annotations.Proxy;

/**
 * Cinema generated by hbm2java
 */
@SuppressWarnings("serial")
@XmlAccessorType(XmlAccessType.FIELD)
@Entity
@Proxy(lazy = false)
@Table(name = "CINEMA", schema = "TEST")
public class Cinema extends BaseModel implements java.io.Serializable
{
	public Cinema()
	{
	}
	
	public Cinema(BigDecimal cinId)
	{
		this.id = cinId;
	}
	
	public Cinema(BigDecimal cinId, City city, String cinName, String cinAddress, byte[] cinIcon)
	{
		this.id = cinId;
		this.name = cinName;
		this.city = city;
		this.cinAddress = cinAddress;
	}

	public Cinema(BigDecimal cinId, City city, String cinName, String cinAddress, byte[] cinIcon, Set<Hall> halls)
	{
		this.id = cinId;
		this.name = cinName;
		this.city = city;
		this.cinIcon = cinIcon;
		this.cinAddress = cinAddress;
		this.halls = halls;
	}
	
	@Id
	@GeneratedValue(strategy = GenerationType.SEQUENCE, generator = "CINEMA_SEQ")
    @SequenceGenerator(name = "CINEMA_SEQ", sequenceName = "CINEMA_SEQ", allocationSize = 1)
	@Column(name = "CIN_ID", unique = true, nullable = false, precision = 22, scale = 0)
	public BigDecimal getCinId()
	{
		return this.id;
	}

	public void setCinId(BigDecimal cinId)
	{
		this.id = cinId;
	}

	@ManyToOne(fetch = FetchType.EAGER)
	@JoinColumn(name = "CIN_CITY_ID", nullable = false)
	public City getCity()
	{
		return this.city;
	}

	public void setCity(City city)
	{
		this.city = city;
	}

	@Column(name = "CIN_NAME", nullable = false, length = 100)
	public String getCinName()
	{
		return this.name;
	}

	public void setCinName(String cinName)
	{
		this.name = cinName;
	}

	@Column(name = "CIN_ICON")
	public byte[] getCinIcon()
	{
		return this.cinIcon;
	}

	public void setCinIcon(byte[] cinIcon)
	{
		this.cinIcon = cinIcon;
	}

	@Column(name = "CIN_ADDRESS", nullable = false)
	public String getCinAddress()
	{
		return this.cinAddress;
	}

	public void setCinAddress(String cinAddress)
	{
		this.cinAddress = cinAddress;
	}

	@OneToMany(fetch = FetchType.EAGER, mappedBy = "cinema", cascade = CascadeType.ALL, orphanRemoval = true )
	public Set<Hall> getHalls()
	{		
		for(Hall hall : this.halls)
		{
			if(hall.getCinema() == null)
			{
				hall.setCinema(this);
			}
		}		
		
		return this.halls;
	}

	public void setHalls(Set<Hall> halls)
	{
		this.halls = halls;
	}
		
	@XmlJavaTypeAdapter(value = CityXmlAdapter.class)
	private City city;	
	private byte[] cinIcon;
	private String cinAddress;
	private Set<Hall> halls = new HashSet<Hall>(0);
}
