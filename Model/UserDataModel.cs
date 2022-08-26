using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReactProjectGym.Model
{
    public class UserDataModel
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string About { get; set; }


        public string ProfileImage { get; set; }
    }
    public class UserDataModelImage { 
       public IFormFile ImageFile { get; set; }
        public string Name { get; set; }

        public string About { get; set; }

    }
}
