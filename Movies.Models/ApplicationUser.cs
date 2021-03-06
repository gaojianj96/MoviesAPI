﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Movies.Models.Common;
using Newtonsoft.Json;

namespace Movies.Models
{
    /*
     * Now we want to define our first custom entity framework class which is the “ApplicationUser” class, 
     * this class will represents a user wants to register in our membership system, as well we want to extend the default
     * class in order to add application specific data properties for the user, data properties such as: First Name, Last Name, 
     * Level, JoinDate. Those properties will be converted to columns in table “AspNetUsers” as we’ll see on the next steps.

          So to do this we need to create new class named “ApplicationUser” and derive from
          “Microsoft.AspNet.Identity.EntityFramework.IdentityUser” class.


     * */
    [Table("User")]
    public class ApplicationUser : IdentityUser, IAuditableEntity
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }


        [ScaffoldColumn(false)]
        [JsonIgnore]
        public DateTime? CreatedDate { get; set; }

        [ScaffoldColumn(false)]
        [JsonIgnore]
        public string CreatedBy { get; set; }

        [ScaffoldColumn(false)]
        [JsonIgnore]
        public DateTime? UpdatedDate { get; set; }

        [ScaffoldColumn(false)]
        [JsonIgnore]
        public string UpdatedBy { get; set; }

        public virtual Address BillingAddress { get; set; }
        public virtual Address ShippingAddress { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager,
            string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
}