using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Module4.DB;

namespace Module4.Controllers
{
    [Route("TransferSimulator")]
    [ApiController]
    public class PhoneNumber : ControllerBase
    {
        private readonly Module2Context module2Context;

        public PhoneNumber(Module2Context module2Context_)
        {
            module2Context = module2Context_;
        }

        [HttpGet("mobilePhone")]
        public async Task<ActionResult<object>> mobilePhone()
        {
            //получаем рандомный номер телефона из бд
            var phoneNumber = module2Context.Clients.Select(c => c.PhoneNumber).OrderBy(c => Guid.NewGuid()).FirstOrDefault();

            //возвращаем в необходимом формате
            return Ok(phoneNumber + "@");
        }
    }
}
