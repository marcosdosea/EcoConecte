using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
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
            ModelState.AddModelError(string.Empty, "Usuário ou senha inválidos.");
            return Page();
        }

        var result = await _signInManager.PasswordSignInAsync(user, Input.Password, Input.RememberMe, lockoutOnFailure: false);

        if (result.Succeeded)
        {
            // Obtém as roles do usuário
            var roles = await _userManager.GetRolesAsync(user);

            // Se o usuário não tiver nenhuma role atribuída, ele será tratado como "CLIENTE"
            if (!roles.Any())
            {
                roles = new List<string> { "CLIENTE" }; // Define a role padrão
            }

            // Adiciona o PessoaId como Claim
            var pessoaId = user.PessoaId.ToString();
            var claims = new List<Claim>
            {
                new Claim("PessoaId", pessoaId)
            };

            var userPrincipal = await _signInManager.CreateUserPrincipalAsync(user);
            var claimsIdentity = (ClaimsIdentity)userPrincipal.Identity;
            claimsIdentity.AddClaims(claims);

            await _signInManager.SignInWithClaimsAsync(user, Input.RememberMe, claims);

            // Redirecionamento com base nas roles
            if (roles.Contains("ADMROOT"))
            {
                return RedirectToAction("Index", "Home");
            }
            else if (roles.Contains("COOPERADO"))
            {
                return RedirectToAction("Index", "Home");
            }
            else if (roles.Contains("COOPERATIVA"))
            {
                return RedirectToAction("Index", "Home");
            }

            // Se não houver role específica, redireciona para a área padrão (Cliente)
            return RedirectToAction("Index", "Home");
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Usuário ou senha inválidos.");
            return Page();
        }
    }
}
