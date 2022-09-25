using Domain;

namespace Aplication.Interfaces.Repositories;

public interface ISoundtrackRepository {
    Task<Soundtrack> GetSoundtrackById(int id);
    Task<IReadOnlyList<Soundtrack>> GetGameSoundtracks(int gameId);
}