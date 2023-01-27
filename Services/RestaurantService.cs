using Microsoft.EntityFrameworkCore;

public class RestaurantService : IRestaurantService
{
    private readonly RestaurantDbContext _context;

    public RestaurantService(RestaurantDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateRestaurant(RestaurantCreate model)
    {
        var entity = new Restaurant
        {
            Name = model.Name,
            Location = model.Location
        };

        await _context.Restaurants.AddAsync(entity);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteRestaurant(int id)
    {
        var restaurant = await _context.Restaurants.FirstOrDefaultAsync(x => x.Id == id);
        if (restaurant is null) return false;
        _context.Restaurants.Remove(restaurant);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<List<RestaurantListItem>> GetAllRestaurants()
    {
        return await _context.Restaurants.Select(r => new RestaurantListItem
        {
            Name = r.Name,
            Location = r.Location
        }).ToListAsync();
    }

    public async Task<RestaurantDetail> GetRestaurantById(int id)
    {
        var restaurant = await _context
        .Restaurants
        .Include(r=>r.Ratings)
        .FirstOrDefaultAsync(x => x.Id == id);
        
        if (restaurant is null) return null;
        
        return new RestaurantDetail
        {
            Id = restaurant.Id,
            Name = restaurant.Name,
            Location = restaurant.Location,
            AverageFoodScore = restaurant.AverageFoodScore,
            AverageAtomsphereScore = restaurant.AverageAtomsphereScore,
            AverageClenlinessScore = restaurant.AverageAtomsphereScore,
            Score = restaurant.Score
        };
    }

    public async Task<bool> UpdateRestaurant(RestaurantEdit model)
    {
        if (model is null) return false;
        var restaurant = await _context.Restaurants.FirstOrDefaultAsync(x => x.Id == model.Id);
        if (restaurant is null) return false;

        restaurant.Name = model.Name;
        restaurant.Location = model.Location;

        return await _context.SaveChangesAsync() > 0;
    }
}
