using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


public class Restaurant
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Location { get; set; }

    public List<Rating> Ratings { get; set; } = new List<Rating>();

    public double AverageFoodScore=> Ratings.Average(r => r.FoodScore);
    public double AverageClenlinessScore => Ratings.Average(r => r.CleanlinessScore);
    public double AverageAtomsphereScore => Ratings.Average(r => r.AtmosphereScore);

    public double Score => (AverageAtomsphereScore + AverageFoodScore + AverageClenlinessScore) / 3;

}
