// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using EcoConecteWeb.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Core;

namespace EcoConecteWeb.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<UsuarioIdentity> _signInManager;
        private readonly UserManager<UsuarioIdentity> _userManager;
        private readonly IUserStore<UsuarioIdentity> _userStore;
        private readonly IUserEmailStore<UsuarioIdentity> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;
        private readonly EcoConecteContext _contextEcoconecte;

        public RegisterModel(
            UserManager<UsuarioIdentity> userManager,
            IUserStore<UsuarioIdentity> userStore,
            SignInManager<UsuarioIdentity> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            EcoConecteContext contextEcoconecte)
            

        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _contextEcoconecte = contextEcoconecte;
        }

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
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            /// <summary>
            ///  CPF
            /// </summary>
            [Required]
            [Display(Name = "CPF")]
            public string Cpf { get; set; }

            /// <summary>
            /// Nome
            /// </summary>
            [Required]
            [Display(Name = "Nome Completo")]
            public string Nome { get; set; }

            /// <summary>
            /// Telefone
            /// </summary>
            [Display(Name = "Telefone")]
            public string Telefone { get; set; }

            /// <summary>
            /// Lagradouro
            /// </summary>
            [Display(Name = "Endereço")]
            public string Logradouro { get; set; }

            /// <summary>
            /// Número
            /// </summary>
            [Display(Name = "Número")]
            public string Numero { get; set; }

            /// <summary>
            /// Bairro
            /// </summary>
            [Display(Name = "Bairro")]
            public string Bairro { get; set; }

            /// <summary>
            /// Cidade
            /// </summary>
            [Display(Name = "Cidade")]
            public string Cidade { get; set; }

            /// <summary>
            /// Estado
            /// </summary>
            [Display(Name = "Estado")]
            public string Estado { get; set; }
        }


        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (ModelState.IsValid)
            {
                using var transaction = await _contextEcoconecte.Database.BeginTransactionAsync(); // Inicia a transação
                try
                {
                    var user = CreateUser();

                    await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                    await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
                    var result = await _userManager.CreateAsync(user, Input.Password);

                    if (result.Succeeded)
                    {
                        _logger.LogInformation("User created a new account with password.");

                        // Criar a pessoa no banco Ecoconecte
                        var pessoa = new Pessoa
                        {
                            Cpf = Input.Cpf,
                            Nome = Input.Nome,
                            Telefone = Input.Telefone,
                            Logradouro = Input.Logradouro,
                            Numero = Input.Numero,
                            Bairro = Input.Bairro,
                            Cidade = Input.Cidade,
                            Estado = Input.Estado,
                            Status = "A"
                        };

                        _contextEcoconecte.Pessoas.Add(pessoa);
                        var result2 = await _contextEcoconecte.SaveChangesAsync();

                        // Vincular o usuário Identity à pessoa criada
                        user.PessoaId = (int)pessoa.Id;
                        await _userManager.UpdateAsync(user);

                        // Confirmar a transação
                        await transaction.CommitAsync();

                        var userId = await _userManager.GetUserIdAsync(user);
                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                        var callbackUrl = Url.Page(
                            "/Account/ConfirmEmail",
                            pageHandler: null,
                            values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                            protocol: Request.Scheme);

                        if (_userManager.Options.SignIn.RequireConfirmedAccount)
                        {
                            return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                        }
                        else
                        {
                            await _signInManager.SignInAsync(user, isPersistent: false);
                            return LocalRedirect(returnUrl);
                        }
                    }

                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
                catch (Exception ex)
                {
                    // Se algum erro ocorrer, reverter todas as operações
                    await transaction.RollbackAsync();

                    // Remover o usuário Identity se ele foi criado
                    var userToDelete = await _userManager.FindByEmailAsync(Input.Email);
                    if (userToDelete != null)
                    {
                        await _userManager.DeleteAsync(userToDelete);
                    }

                    _logger.LogError(ex, "Erro ao registrar usuário e criar pessoa associada.");
                    ModelState.AddModelError(string.Empty, "Erro ao registrar usuário. Tente novamente.");
                }
            }

            // Se falhar, retorna a página com os erros
            return Page();
        }


        private UsuarioIdentity CreateUser()
        {
            try
            {
                return Activator.CreateInstance<UsuarioIdentity>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(UsuarioIdentity)}'. " +
                    $"Ensure that '{nameof(UsuarioIdentity)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<UsuarioIdentity> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<UsuarioIdentity>)_userStore;
        }
    }
}
