package dev.git.ua.EntertainmentNetworkServer.Models;
// Generated Feb 9, 2018 5:32:55 PM by Hibernate Tools 3.5.0.Final

import java.math.BigDecimal;
import java.util.HashSet;
import java.util.Set;

import javax.persistence.*;
import javax.xml.bind.annotation.*;

/**
 * City generated by hbm2java
 */
@SuppressWarnings("serial")
@XmlAccessorType(XmlAccessType.FIELD)
@Entity
@Table(name = "CITY", schema = "TEST")
public class City  extends BaseModel implements java.io.Serializable
{
	public City()
	{
	}

	public City(BigDecimal citId)
	{
		this.id = citId;
	}
	
	public City(BigDecimal citId, String citName, String citCountry)
	{
		this.id = citId;
		this.name = citName;
		this.citCountry = citCountry;
	}

	public City(BigDecimal citId, String citName, String citCountry, Set<Cinema> cinemas)
	{
		this(citId, citName, citCountry);
		this.cinemas = cinemas;
	}
	
	@Id
	@GeneratedValue(strategy = GenerationType.SEQUENCE, generator = "CITY_SEQ")
    @SequenceGenerator(name = "CITY_SEQ", sequenceName = "CITY_SEQ", allocationSize = 1)
	@Column(name = "CIT_ID", unique = true, nullable = false, precision = 22, scale = 0)
	public BigDecimal getCitId()
	{
		return this.id;
	}

	public void setCitId(BigDecimal citId)
	{
		this.id = citId;
	}

	@Column(name = "CIT_NAME", nullable = false, length = 100)
	public String getCitName()
	{
		return this.name;
	}

	public void setCitName(String citName)
	{
		this.name = citName;
	}

	@Column(name = "CIT_COUNTRY", nullable = false, length = 100)
	public String getCitCountry()
	{
		return this.citCountry;
	}

	public void setCitCountry(String citCountry)
	{
		this.citCountry = citCountry;
	}

	@OneToMany(cascade=CascadeType.ALL, fetch = FetchType.EAGER, mappedBy = "city")
	public Set<Cinema> getCinemas()
	{
		return this.cinemas;
	}

	public void setCinemas(Set<Cinema> cinemas)
	{
		this.cinemas = cinemas;
	}
	
	private String citCountry;
	@XmlTransient
	private Set<Cinema> cinemas = new HashSet<Cinema>(0);
}