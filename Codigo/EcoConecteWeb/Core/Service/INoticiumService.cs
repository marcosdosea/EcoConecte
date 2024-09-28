namespace Core.Service
{
    public interface INoticiumServices
    {
        uint Inserir(Noticium noticium);
        void Editar(Noticium noticium);
        void Remover(uint id);
        Noticium? GetById(uint id);
        IEnumerable<Noticium> GetAll();
        IEnumerable<Noticium> GetByTitulo(string titulo);
    }
}
