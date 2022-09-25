using Domain;

namespace Aplication.Interfaces.Repositories;

public interface IDeveloperRepository {
    Task<Developer> GetDeveloperById(int id);
    Task<IReadOnlyList<Developer>> GetDevelopers(int limit);
}