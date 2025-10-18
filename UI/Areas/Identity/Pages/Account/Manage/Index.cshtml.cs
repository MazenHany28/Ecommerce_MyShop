// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using DAL.Data;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace UI.Areas.Identity.Pages.Account.Manage
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<AppIdentityUser> _userManager;
        private readonly SignInManager<AppIdentityUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public IndexModel(
            UserManager<AppIdentityUser> userManager,
            SignInManager<AppIdentityUser> signInManager,
            ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
       // public string Username { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [TempData]
        public string StatusMessage { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {

            [Required]
            [Display(Name = "UserName")]
            public string UserName { get; set; }

            [Required]
            [StringLength(50, MinimumLength = 3)]
            [Display(Name = "First Name")]
            public string FirstName { get; set; }

            [Required]
            [StringLength(50, MinimumLength = 3)]
            [Display(Name = "Last Name")]
            public string LastName { get; set; }

            [Display(Name = "Phone Number")]
            [RegularExpression("^(010|012|015)[0-9]{8}$"
                , ErrorMessage = "Invalid phone number format")]
            public string PhoneNumber { get; set; } = string.Empty;

            [Required]
            [Display(Name = "Address")]
            [StringLength(300, MinimumLength = 3)]
            public string Address { get; set; }

            [Display(Name = "Organization")]
            [StringLength(300, MinimumLength = 3)]
            public string Organization { get; set; } = string.Empty;

        }

        private async Task LoadAsync(AppIdentityUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            //var phoneNumber =user.phonenumber;
            var firstname = user.FirstName;
            var lastname = user.LastName;
            string address = string.Empty;
            string organization = string.Empty;

            switch (user) {
                case  Customer customer1:
                    var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == user.Id);
                    address = customer.Address;
                    break;
                case Buyer buyer1:
                    var Buyer = await _context.Buyers.FirstOrDefaultAsync(b => b.Id == user.Id);
                    organization = Buyer.Organization;
                    break;
                default:
                    break;
            }

            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                UserName = userName,
                FirstName=firstname,
                LastName=lastname,
                Address=address,
                Organization=organization
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);
                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            if (Input.UserName != userName)
            {
                var setUserNameResult = await _userManager.SetUserNameAsync(user, Input.UserName);
                if (!setUserNameResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set UserName.";
                    return RedirectToPage();
                }
            }

            bool identityCustomFieldsChanged = false;

            // FirstName
            if (user.FirstName != Input.FirstName)
            {
                user.FirstName = Input.FirstName;
                identityCustomFieldsChanged = true;
            }

            // LastName
            if (user.LastName != Input.LastName)
            {
                user.LastName = Input.LastName;
                identityCustomFieldsChanged = true;
            }

            if (identityCustomFieldsChanged)
            {
                var updateResult = await _userManager.UpdateAsync(user);
                if (!updateResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set first and last names.";
                    return RedirectToPage();
                }
            }

            switch (user)
            {
                case Customer customer1:
                    var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Id == user.Id);
                    customer.Address = Input.Address;
                    await _context.SaveChangesAsync();
                    break;
                case Buyer buyer1:
                    var Buyer = await _context.Buyers.FirstOrDefaultAsync(b => b.Id == user.Id);
                    Buyer.Organization = Input.Organization;
                    await _context.SaveChangesAsync();
                    break;
                default:
                    break;
            }


            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
