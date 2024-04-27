using Aplication.Wrappers;
using Domain;

namespace Aplication.Interfaces.Repositories;

public interface ISoundtrackRepository
{
    Task<Soundtrack> GetSoundtrackById(int id);
    Task<DataCollection<Soundtrack>> GetSoundtracks(int page, int take);
    Task<IReadOnlyList<Soundtrack>> GetGameSoundtracks(int gameId);
}