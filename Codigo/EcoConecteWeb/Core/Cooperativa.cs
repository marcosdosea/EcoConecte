using System;
using System.Collections.Generic;

namespace Core;

public partial class Cooperativa
{
    public uint IdCooperativa { get; set; }

    public string Nome { get; set; } = null!;

    public string InscricaoEstadual { get; set; } = null!;

    public string InscricaoMunicipal { get; set; } = null!;

    public string Cnpj { get; set; } = null!;

    public string Cep { get; set; } = null!;

    public string? Rua { get; set; }

    public string? Bairro { get; set; }

    public int? NumeroEndereco { get; set; }

    public string? Telefone { get; set; }

    public string? Email { get; set; }

    public string NomeRepresentante { get; set; } = null!;

    public string CpfRepresentante { get; set; } = null!;

    public uint CooperadoIdCooperado { get; set; }

    public uint VendaMaterialIdVendaMaterial { get; set; }

    public uint AgendamentoIdAgendamento { get; set; }

    public uint RotinaDeColetaIdRotinaDeColeta { get; set; }

    public uint NoticiaIdNoticia { get; set; }

    public uint OrientacoesIdOrientacoes { get; set; }

    public virtual Agendamento AgendamentoIdAgendamentoNavigation { get; set; } = null!;

    public virtual Noticium NoticiaIdNoticiaNavigation { get; set; } = null!;

    public virtual Orientaco OrientacoesIdOrientacoesNavigation { get; set; } = null!;

    public virtual Rotinadecoletum RotinaDeColetaIdRotinaDeColetaNavigation { get; set; } = null!;

    public virtual Vendamaterial VendaMaterialIdVendaMaterialNavigation { get; set; } = null!;
}
