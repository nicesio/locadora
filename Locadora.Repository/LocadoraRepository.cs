using System;
using System.Linq;
using System.Threading.Tasks;
using Locadora.Domain;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Repository
{
    public class LocadoraRepository: ILocadoraRepository
    {
        private readonly LocadoraContext _context;

        public LocadoraRepository(LocadoraContext context)
        {
            _context = context;
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }

        public async Task<Filme[]> GetAllFilmeAsync(bool filme)
        {
            IQueryable<Filme> query = _context.Filmes;

            if (filme){
                query = query.AsNoTracking().OrderByDescending(c => c.Id);
            }

            return await query.ToArrayAsync();

        }

        public async Task<Filme> GetAllFilmeAsyncById(int FilmeId, bool filme = false)
        {
            IQueryable<Filme> query = _context.Filmes;

            if (filme){
            }
            query = query.AsNoTracking().OrderByDescending(c => c.Id).Where(c => c.Id == FilmeId);

            

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Filme> GetAllFilmeAsyncByName(string name, bool filme = false)
        {
            IQueryable<Filme> query = _context.Filmes;

            if (filme){
                query = query.AsNoTracking().Where(c => c.nomeFilme.ToLower().Contains(name.ToLower()));
            }


            return await query.FirstOrDefaultAsync();
        }

        public async Task<Diretor> GetAllDiretorAsyncByName(string name, bool diretor = false)
        {
            IQueryable<Diretor> query = _context.Diretores;

            if (diretor){
                query = query.AsNoTracking().Where(c => c.nomeDiretor.ToLower().Contains(name.ToLower()));
            }


            return await query.FirstOrDefaultAsync();
        }

        public async Task<Diretor> GetAllDiretorAsyncById(int DiretorId, bool diretor = false)
        {
            IQueryable<Diretor> query = _context.Diretores;

            if (diretor){
            }
            
            query = query.AsNoTracking().OrderBy(c => c.nomeDiretor).Where(c => c.Id == DiretorId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Diretor[]> GetAllDiretorAsync(bool diretor = false)
        {
            IQueryable<Diretor> query = _context.Diretores;

            if (diretor){
                query = query.AsNoTracking().OrderBy(c => c.nomeDiretor);
            }

            return await query.ToArrayAsync();

        }



    }
}