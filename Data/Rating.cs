using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


public class Rating
{
    [Key]
    public int Id { get; set; }

    public int RestaurantId { get; set; }
    
    [ForeignKey(nameof(RestaurantId))]
    public virtual Restaurant Restaurant{get;set;}
    
    public double FoodScore { get; set; }
    
    public double CleanlinessScore { get; set; }
    
    public double AtmosphereScore { get; set; }
}
