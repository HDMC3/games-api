using Aplication.Wrappers;
using Domain;

namespace Aplication.Interfaces.Repositories;

public interface IEngineRepository
{
    Task<Engine> GetEngineById(int id);
    Task<DataCollection<Engine>> GetEngines(int page, int take);
}