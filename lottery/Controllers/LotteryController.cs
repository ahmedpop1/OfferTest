using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lottery.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LotteryController : ControllerBase
    {
        [Route("play")]
        [HttpPost]
        public int play(int customerNumber)
        {
           
            return 1234;
        }

        }
}
