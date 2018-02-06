using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Microsoft.AspNet.Identity;
 
namespace Shoppers.Models.ViewModels
{
 

public class CreateSubscriptionViewModel
    {
        public CreateSubscriptionViewModel()
        {
            Id = HttpContext.Current.User.Identity.GetUserId();

        shopperEntities db = new shopperEntities();
        String gracePeriod = db.Settings.Where(e => e.VariableName == "GracePeriod").Select(e => e.VariableValue).First();

            GracePeriod = DateTime.Now.AddDays(int.Parse(gracePeriod));
        }

        public int SubscriptionId { get; set; }

        public string Id { get; set; }

        public int BundleId { get; set; }
        public string ExpirationDate { get; set; }

        public double SubscriptionAmount { get; set; }

        public DateTime GracePeriod { get; set; }

        public DateTime DateRegistered { get; set; }

    }
}
