using CSRF_zaifligi.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSRF_zaifligi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IEmailSender _email;

        public ValuesController(IEmailSender email)
        {
            _email = email;
        }
        [HttpPost("sendEmail")]
        public IActionResult SendEmail([FromBody] EmailModel emailModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _email.SendEmail(emailModel.EmailAddress, "fromAdmin", emailModel.Text);
                }
                else return BadRequest(new { message = "error-invalid-data" });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(new { message = "successfully send email" });
        }
    }
}
