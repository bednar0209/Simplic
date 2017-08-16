/*****************
* This abstract class need for creating derived Entities 
* Example class ProductEntity : BaseEntity
*
*****************/
using System;
using System.ComponentModel.DataAnnotations;

namespace Simplic.Core.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }

    }
}
