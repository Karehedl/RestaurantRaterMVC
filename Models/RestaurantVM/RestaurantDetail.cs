using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


public class RestaurantDetail
{
    
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }

    public double AverageFoodScore{get;set;}
    public double AverageClenlinessScore {get;set;}
    public double AverageAtomsphereScore{get;set;}
    public double Score {get;set;}

    //  public List<RatingListItem> Ratings { get; set; } = new List<RatingListItem>();
}
