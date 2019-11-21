using System;
using System.Threading.Tasks;
using Locadora.Domain;

namespace Locadora.Repository
{
    public interface ILocadoraRepository
    {
         void Add <T>(T entity) where T: class;

         void Update <T>(T entity) where T: class;
         void Delete <T>(T entity) where T: class;
         Task <bool> SaveChangesAsync();

         Task<Filme[]> GetAllFilmeAsync(bool filme);
         Task<Filme> GetAllFilmeAsyncById(int Id, bool filme);
         Task<Filme> GetAllFilmeAsyncByName(string name, bool filme);
         Task<Diretor> GetAllDiretorAsyncById(int Id, bool diretor);
         Task<Diretor[]> GetAllDiretorAsync(bool diretor);         
         Task<Diretor> GetAllDiretorAsyncByName(string name, bool diretor);
    }
}