using Domain;

namespace Aplication.Interfaces.Repositories;

public interface IEngineRepository {
    Task<Engine> GetEngineById(int id);
    Task<IReadOnlyList<Engine>> GetEngines(int limit);
}