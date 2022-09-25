using Domain;

namespace Aplication.Interfaces.Repositories;

public interface IReleaseRepository {
    Task<IReadOnlyList<Release>> GetGameReleases(int gameId);
}
