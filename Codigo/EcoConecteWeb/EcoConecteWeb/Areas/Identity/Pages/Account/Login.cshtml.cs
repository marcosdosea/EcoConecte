using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EcoConecteWeb.Areas.Identity.Data;

public class LoginModel : PageModel
{
    private readonly SignInManager<UsuarioIdentity> _signInManager;
    private readonly UserManager<UsuarioIdentity> _userManager;

    public LoginModel(SignInManager<UsuarioIdentity> signInManager, UserManager<UsuarioIdentity> userManager)
    {
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [BindProperty]
    public InputModel Input { get; set; }

    public string ReturnUrl { get; set; }

    public class InputModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }

    public async Task<IActionResult> OnPostAsync(string returnUrl = null)
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var user = await _userManager.FindByEmailAsync(Input.Email);
        if (user == null)
        {
            ModelState.AddModelError(string.Empty, "Usu�rio ou senha inv�lidos.");
            return Page();
        }

        var result = await _signInManager.PasswordSignInAsync(user, Input.Password, Input.RememberMe, lockoutOnFailure: false);

        if (result.Succeeded)
        {
            // Obt�m as roles do usu�rio
            var roles = await _userManager.GetRolesAsync(user);

            // Redireciona para p�ginas espec�ficas com base nas roles
            if (roles.Contains("ADMROOT"))
            {
                return RedirectToAction("Index", "Cooperativa");
            }
            else if (roles.Contains("COOPERADO"))
            {
                return RedirectToAction("Index", "Pessoa");
            }
            else if (roles.Contains("USERDEFAULT"))
            {
                return RedirectToAction("Index", "Noticia");
            }

            // Se n�o houver role espec�fica, redireciona para a p�gina padr�o
            return RedirectToPage("/Index");
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Usu�rio ou senha inv�lidos.");
            return Page();
        }
    }
}
