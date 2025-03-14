﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Service
{
    public interface IOrientacoesService
    {
        /// <summary>
        /// Criar orientação
        /// </summary>
        /// <param name="orientacoes"></param>
        /// <returns></returns>
        uint Create(Orientacoes orientacoes);

        /// <summary>
        /// Atualiza uma orientação
        /// </summary>
        /// <param name="orientacoes"></param>
        void Update(Orientacoes orientacoes);

        /// <summary>
        /// Edita uma orientação
        /// </summary>
        /// <param name="orientacoes"></param>
        void Edit(Orientacoes orientacoes);

        /// <summary>
        /// Deleta uma orientação
        /// </summary>
        /// <param name="id"></param>
        void Delete(uint id);

        /// <summary>
        /// Busca orientação pelo ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Orientacoes? GetById(uint id);

        /// <summary>
        /// Lista N orientação
        /// </summary>
        /// <returns></returns>
        IEnumerable<Orientacoes> GetAll();

        /// <summary>
        /// Busca orientação pelo título
        /// </summary>
        /// <param name="titulo"></param>
        /// <returns></returns>
        IEnumerable<Orientacoes> GetByTitulo(string titulo);

    }
}
