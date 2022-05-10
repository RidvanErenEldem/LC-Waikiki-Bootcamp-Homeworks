using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Resources;
using Response;

namespace Services.Interfaces
{
    public interface IDirectorService
    {

        Task<DirectorResponse> SaveAsync(Director director);
        Task<List<Director>> GetAllAsync();
        Task<DirectorResponse> UpdateAsync(int id, Director director);
        Task<DirectorResponse> DeleteAsync(int id);

        Task<List<Director>> Search(SearchDirectorResource resource);
    }
}