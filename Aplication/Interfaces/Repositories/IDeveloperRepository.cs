using Aplication.Wrappers;
using Domain;

namespace Aplication.Interfaces.Repositories;

public interface IDeveloperRepository
{
    Task<Developer> GetDeveloperById(int id);
    Task<DataCollection<Developer>> GetDevelopers(int page, int take);
}