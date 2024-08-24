using Microsoft.AspNetCore.Mvc;
using LapShop.Models;
using Microsoft.AspNetCore.Identity;

namespace LapShop.Controllers
{
    public class UserController : Controller
    {
        UserManager<ApplicationUser> _userManager;
        
        SignInManager<ApplicationUser> _signInManager;
        public UserController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
           _userManager = userManager;
           _signInManager = signInManager;
        }


        public IActionResult Login (string returnUrl)
        {
            UserModel model = new UserModel()
            {
                ReturnUrl = returnUrl
            };
            return View(model);
        }


        public async Task<IActionResult> LoginOut()
        {
            await _signInManager.SignOutAsync();
            return Redirect("~/");
        }

   
        public IActionResult Register()
        {
            return View(new UserModel());
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserModel model)
        
        {

            if (!ModelState.IsValid)

            return View("Register", model);

            ApplicationUser user = new ApplicationUser()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email
            };
            //الباسوورد عشات متهيشة 
            try
            {
                var result = await _userManager.CreateAsync(user, model.Password);
               

                if (result.Succeeded)
                {
                   var LogInResult= await _signInManager.PasswordSignInAsync(user, model.Password,true,true);
                 //why tie user to row
                    var MyUser = await _userManager.FindByEmailAsync(user.Email);
                    await _userManager.AddToRoleAsync(MyUser,"Customer");
                    if (LogInResult.Succeeded)
                    
                         Redirect("~/Order/OrderSuccess");

                }
                else
                {

                }

            }
            catch (Exception ex) { }
          
            return View(new UserModel());
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserModel model)

        {

          

            ApplicationUser user = new ApplicationUser()
            {

                Email = model.Email,
                UserName = model.Email
            };
            //الباسوورد عشات متهيشة 
            try
            {

                var LogInResult = await _signInManager.PasswordSignInAsync(user.Email, model.Password, true, true);
                if (LogInResult.Succeeded)
                {
                  
                    if (string.IsNullOrEmpty(model.ReturnUrl))
                      return Redirect("~/");
                   else
                     return Redirect(model.ReturnUrl);
                }



            }
            catch (Exception ex) { }

            return View(new UserModel());
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
