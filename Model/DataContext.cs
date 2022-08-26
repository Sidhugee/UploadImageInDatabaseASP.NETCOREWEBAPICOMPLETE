using Microsoft.EntityFrameworkCore;

namespace ReactProjectGym.Model
{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
                
        }
        public DbSet<UserDataModel> userDataModels { get; set; }

    }
}
