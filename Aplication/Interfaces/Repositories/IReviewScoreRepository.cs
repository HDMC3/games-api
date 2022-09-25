using Domain;

namespace Aplication.Interfaces.Repositories;

public interface IReviewScoreRepository {
    Task<IReadOnlyList<ReviewScore>> GetGameReviewScores(int gameId);
}