using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWorkStuff.Entities
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Cost { get; set; }
        public string Owner { get; set; }
        public virtual Category Category { get; set; }
        [ForeignKey(nameof(Category))]
        public long? ultraCat { get; set; }
        public virtual List<Supplier> Suppliers { get; set; }
    }
    [Table("myCategories")]
    public class Category
    {
        //public List<Product> Products { get; set; } = new List<Product>();
        [Key]
        public long catd { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(50)]
        [Column("desc",TypeName = "varchar")]
        public string Description { get; set; }
        [NotMapped]
        public int Profit { get; set; }
        public virtual List<Product> Products { get; set; }
    }
    //[Table("Suppliers")]
    public class Supplier : Person
    {
        public string GST { get; set; }
        public int? Rating { get; set; }
        public List<Product> Products { get; set; }
        public Address Address { get ; set; }
    }
    [ComplexType]
    public class Address
    {
        public string Area { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
    }
    abstract public class Person
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
    }
    //[Table("Customers")]
    public class Customer : Person
    {
        public string CustomerType { get; set; }
        public double Discount { get; set; }
    }

}
