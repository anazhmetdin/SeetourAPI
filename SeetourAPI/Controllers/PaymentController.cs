using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeetourAPI.DAL.DTO;
using SeetourAPI.Data.Context;
using SeetourAPI.Data.Models;
using SeetourAPI.Data.Models.Users;
using System.Security.Claims;

namespace SeetourAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly UserManager<SeetourUser> manager;
        private readonly HttpContextAccessor httpContextAccessor;

        public SeetourContext Context { get; }
       public PaymentController(SeetourContext context,UserManager<SeetourUser>manager,
           HttpContextAccessor httpContextAccessor)
        {
            Context = context;
            this.manager = manager;
            this.httpContextAccessor = httpContextAccessor;
        }

        
        [HttpPost]     
        public async Task <IActionResult> CreatePayment([FromBody] paymentInfoDto paymentInfo)
        {
          var bookedtour=  Context.BookedTours.Find(paymentInfo.bookedTourId);
            if (bookedtour != null)
            {
                var payment = new TourBookingPayment
                {

                    Total = paymentInfo.Amount,
                    Currency = paymentInfo.Currency,
                    PaymentMethod = "Stripe",
                    CardNumber = paymentInfo.CardNumber,
                    ExpirationDate = paymentInfo.ExpDate,
                    CardholderName = paymentInfo.CardHolderName,
                    CreatedAt = DateTime.UtcNow,
                    BookedTourId = paymentInfo.bookedTourId,

                };

                Context.payments.Add(payment);
                await Context.SaveChangesAsync();

                return Ok(payment);


            }
            else
                return BadRequest();

        }
    }
}
