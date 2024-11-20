using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Entities;

[Table("organizations")]
public class OrganizationEntity
{
    public int Id { get; set; }
    
    [MaxLength(50)]
    [Required]
    public string Title { get; set; }
    
    [MaxLength(50)]
    [Required]
    public string Regon { get; set; }
    
    [MaxLength(50)]
    [Required]
    public string Nip { get; set; }
    
    
    [Required]
    public Address Address { get; set; }
    
    public ISet<ComputerEntity> Computers { get; set;}
}

[Owned]
public class Address
{
    [MaxLength(100)]
    [Required]
    public string City { get; set; }
    
    [MaxLength(100)]
    [Required]
    public string Street { get; set; }
    
    [MaxLength(10)]
    [Required]
    public string PostalCode { get; set; }
    
    [MaxLength(100)]
    [Required]
    public string Region { get; set; }
}