using Core;
using EcoConecteWeb.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Authorize(Roles = "ADMROOT")]
public class AdmIdentityController : Controller
{
    private readonly EcoConecteContext _context;
    private readonly UserManager<UsuarioIdentity> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AdmIdentityController(EcoConecteContext context, UserManager<UsuarioIdentity> userManager, RoleManager<IdentityRole> roleManager)
    {
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    // Exibir todas as roles
    public async Task<IActionResult> Roles()
    {
        var roles = await _roleManager.Roles.ToListAsync();
        return View(roles);
    }

    // Exibir todos os usuários
    public async Task<IActionResult> Users()
    {
        var users = await _userManager.Users.ToListAsync();
        return View(users);
    }

    // Exibir roles de um usuário específico
    public async Task<IActionResult> UserRoles(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return NotFound();
        }

        var userRoles = await _userManager.GetRolesAsync(user);

        // Passando o UserId e as Roles disponíveis para a view
        ViewData["UserId"] = userId;
        ViewData["Roles"] = await _roleManager.Roles.ToListAsync();

        return View(userRoles);
    }

    // Atribuir uma role a um usuário
    [HttpPost]
    public async Task<IActionResult> AssignRoleToUser(string userId, string roleName)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null) return NotFound();

        // Verifica se roleName foi selecionada (não pode ser nula ou vazia)
        if (string.IsNullOrEmpty(roleName))
        {
            TempData["ErrorMessage"] = "Por favor, selecione uma função para o usuário.";
            return RedirectToAction("UserRoles", new { userId = userId });
        }

        var userRoles = await _userManager.GetRolesAsync(user);

        // Verifica se o usuário já tem uma função atribuída
        if (userRoles.Any())
        {
            TempData["ErrorMessage"] = "Antes de adicionar uma função nova, remova a anterior!";
            return RedirectToAction("UserRoles", new { userId = userId });
        }

        var role = await _roleManager.FindByNameAsync(roleName);
        if (role == null)
        {
            TempData["ErrorMessage"] = "Função selecionada não encontrada.";
            return RedirectToAction("UserRoles", new { userId = userId });
        }

        var result = await _userManager.AddToRoleAsync(user, role.Name);
        if (result.Succeeded)
        {
            return RedirectToAction("UserRoles", new { userId = userId });
        }

        TempData["ErrorMessage"] = "Erro ao adicionar a função ao usuário.";
        return RedirectToAction("UserRoles", new { userId = userId });
    }

    // Remover role de um usuário
    [HttpPost]
    public async Task<IActionResult> RemoveRoleFromUser(string userId, string roleName)
    {
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null) return NotFound();

        var result = await _userManager.RemoveFromRoleAsync(user, roleName);
        if (result.Succeeded)
        {
            return RedirectToAction("UserRoles", new { userId = userId });
        }
        return View("Error");
    }

    // Método para exibir a página de edição
    [HttpGet]
    public async Task<IActionResult> Edit(string userId)
    {
        // Buscar o usuário pelo ID
        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
        {
            return NotFound();
        }

        // Retornar a view de edição com os dados do usuário
        return View(user);
    }

    // Método para salvar as alterações do usuário
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(UsuarioIdentity user)
    {
        if (ModelState.IsValid)
        {
            var existingUser = await _userManager.FindByIdAsync(user.Id);
            if (existingUser == null)
            {
                return NotFound();
            }

            // Atualizar as propriedades do usuário
            existingUser.UserName = user.UserName;
            existingUser.Email = user.Email;
            existingUser.PessoaId = user.PessoaId;

            var result = await _userManager.UpdateAsync(existingUser);

            if (result.Succeeded)
            {
                return RedirectToAction("Users");
            }

            // Se falhar na atualização, retornar a view com erros
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        return View(user);
    }

}
