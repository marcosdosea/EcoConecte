using Core;
using Core.Service;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public ColetaService : IColetaService
    {
        private readonly IColetaRepository _coletaRepository;
        private readonly IMapper _mapper;

        public ColetaService(IColetaRepository coletaRepository, IMapper mapper)
        {
            _coletaRepository = coletaRepository;
            _mapper = mapper;
        }

        public IEnumerable<Coleta> GetAll()
        {
            return _coletaRepository.GetAll();
        }

        public Coleta GetById(uint id)
        {
            return _coletaRepository.GetById(id);
        }

        public void Create(Coleta coleta)
        {
            _coletaRepository.Create(coleta);
        }

        public void Update(Coleta coleta)
        {
            _coletaRepository.Update(coleta);
        }

        public void Delete(uint id)
        {
            _coletaRepository.Delete(id);
        }
    }