using Locadora.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Repository
{
    public class LocadoraContext: DbContext
    {
        public LocadoraContext(DbContextOptions<LocadoraContext> options):base (options){

        }
        public DbSet<Filme>Filmes{get;set;}
        public DbSet<Diretor>Diretores{get;set;}
    }
}