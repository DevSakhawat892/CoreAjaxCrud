using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoreAjax.Models
{
   public class ModelManager : DbContext
   {
      public ModelManager(DbContextOptions<ModelManager> options) : base(options)
      {
      }
      public DbSet<TransectionModel> TransectionModels { get; set; }
      public DbSet<Student> Students { get; set; }
      public DbSet<Department> Departments { get; set; }
      public DbSet<Employee> Employees { get; set; }
   }

   public class Student
   {
      public int Id { get; set; }
      [Column(TypeName = "nvarchar(100)")]
      [DisplayName("Name")]
      [Required(ErrorMessage = "This Field is required.")]
      public string Name { get; set; }
      [Column(TypeName = "nvarchar(200)")]
      [DisplayName("Address")]
      [Required(ErrorMessage = "This Field is required.")]
      public string Address { get; set; }
   }

   public class TransectionModel
   {
      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public int TransactionId { get; set; }

      [Column(TypeName = "nvarchar(12)")]
      [DisplayName("Account Number")]
      [Required(ErrorMessage = "This Field is required.")]
      [MaxLength(12, ErrorMessage = "Maximum 12 characters only")]
      public string AccountNumber { get; set; }

      [Column(TypeName = "nvarchar(100)")]
      [DisplayName("Beneficiary Name")]
      [Required(ErrorMessage = "This Field is required.")]
      public string BeneficiaryName { get; set; }

      [Column(TypeName = "nvarchar(100)")]
      [DisplayName("Bank Name")]
      [Required(ErrorMessage = "This Field is required.")]
      public string BankName { get; set; }

      [Column(TypeName = "nvarchar(11)")]
      [DisplayName("SWIFT Code")]
      [Required(ErrorMessage = "This Field is required.")]
      [MaxLength(11)]
      public string SWIFTCode { get; set; }

      [DisplayName("Amount")]
      [Required(ErrorMessage = "This Field is required.")]
      public int Amount { get; set; }

      [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
      public DateTime Date { get; set; }
   }

   public class Department
   {
      [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public int Id { get; set; }
      [Required]
      [StringLength(100, MinimumLength = 2, ErrorMessage = "Minimum 2 character Required")]
      [Display(Name = "Department Name")]
      public string Name { get; set; }
      [DataType(DataType.MultilineText)]
      public string Descripttion { get; set; }

      public virtual IList<Employee> Employees { get; set; }
   }
   public class Employee
   {
      [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public int Id { get; set; }
      [StringLength(100, MinimumLength = 3, ErrorMessage = "Minimum 3 charecter is required")]
      [Required(ErrorMessage = "Field is required")]
      public string Name { get; set; }
      [DataType(DataType.Date)]
      [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
      [Display(Name = "Birth Date")]
      public DateTime BirthDate { get; set; }
      public bool IsTemporary { get; set; }
      [Display(Name = "Image")]
      public string PicturePath { get; set; }
      [NotMapped]
      public IFormFile Picture { get; set; }
      public int DepartmentId { get; set; }
      public virtual Department Department { get; set; }
   }


}
