using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EcoConecteWeb.Areas.Identity.Data;

// Add profile data for application users by adding properties to the UsuarioIdentity class
public class UsuarioIdentity : IdentityUser
{
    public int PessoaId { get; set; } // Chave para o banco Ecoconecte

    public UsuarioIdentity() { }
}

