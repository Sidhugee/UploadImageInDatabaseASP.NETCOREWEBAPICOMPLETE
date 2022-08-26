using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReactProjectGym.Model;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace ReactProjectGym.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class gymtrainer : ControllerBase
    {
        private readonly DataContext _context;
        private IHostingEnvironment _hostingEnvironment;
        public gymtrainer(DataContext context, IHostingEnvironment environment)
        {
            _context = context;
            _hostingEnvironment = environment ?? throw new ArgumentNullException(nameof(environment));
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = _context.userDataModels;
            return Ok(result);
        }
        [Route("{Id}")]
        public async Task<ActionResult> Get(int Id)
        {
            var result = await _context.userDataModels.FindAsync(Id);    
            return Ok(result);
        }


        // Post: api/User/UpdateUserData
        [Route("/updateuserdata")]
        [HttpPost]
        
        public async Task<ActionResult> Post([FromForm] UserDataModelImage userData)
        {
            if (userData.ImageFile != null)
            {
                var a = _hostingEnvironment.WebRootPath;
                var fileName = Path.GetFileName(userData.ImageFile.FileName);
                var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "images\\", fileName);

                using (var fileSteam = new FileStream(filePath, FileMode.Create))
                {
                    await userData.ImageFile.CopyToAsync(fileSteam);
                }

                UserDataModel userDataModel = new UserDataModel();
                userDataModel.ProfileImage = filePath;  //save the filePath to database ImagePath field.
                userDataModel.Name = userData.Name;
                userDataModel.About = userData.About;
                _context.Add(userDataModel);
                await _context.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
