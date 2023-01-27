using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


public class RestaurantCreate
{
    [Required]
    public string Name { get; set; }

    [Required]
    public string Location { get; set; }
}
