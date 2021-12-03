using Microsoft.AspNetCore.Mvc;
using Stripe.Checkout;
using System;
using System.Collections.Generic;

namespace server.Controllers
{
    [Route("create-checkout-session")]
    [ApiController]
    public class CheckoutApiController : Controller
    {
        [HttpPost]
        public ActionResult Create()
        {
            Console.WriteLine("Creating");
            var domain = "https://localhost:5001";
            var options = new SessionCreateOptions
            {
                LineItems = new List<SessionLineItemOptions>
                {
                  new SessionLineItemOptions
                  {
                    Price = "price_1K08xJKx17ccypEKrW7Cnucx",
                    Quantity = 1,
                  },
                },
                Mode = "subscription",
                SuccessUrl = domain + "/Success/{CHECKOUT_SESSION_ID}",
                CancelUrl = domain + "/counter",
            };
            var service = new SessionService();
            Session session = service.Create(options);

            Response.Headers.Add("Location", session.Url);
            return new StatusCodeResult(303);
        }
    }
}
