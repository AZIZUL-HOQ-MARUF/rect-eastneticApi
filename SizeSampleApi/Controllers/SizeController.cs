using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Newtonsoft.Json;
using System.IO;

namespace SizeSampleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizeController : ControllerBase
    {
        [HttpGet("get-shape")]
        public IActionResult Get()
        {
            try
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "SIZESAMPLEAPI") + "size.json";

                var data = System.IO.File.ReadAllText(path);
                if (data == null)
                {
                    return Ok(new Size(100, 100));
                }
                return Ok(data);
            }
            catch (FileNotFoundException ex)
            {
                return Ok(new Size(100, 100));
            }
            catch (Exception ex)
            {

                return Ok("Error");
            }

        }

        [HttpPost("create-shape")]
        public void CreateShape(Size size)
        {
            try
            {

                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), "SIZESAMPLEAPI") + "size.json";
                FileInfo file = new FileInfo(pathToSave);
                Console.WriteLine(pathToSave);
                file.Directory.Create();
                System.IO.File.WriteAllText(file.FullName, JsonConvert.SerializeObject(size));
                
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in the save");
            }
        }
    }


}
