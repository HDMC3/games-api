using Aplication.Interfaces.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

public class ReviewScoreRepository : IReviewScoreRepository {
    private readonly DatabaseContext _dbContext;

    public ReviewScoreRepository(DatabaseContext dbContext) {
        _dbContext = dbContext;
    }

    public async Task<IReadOnlyList<ReviewScore>> GetGameReviewScores(int gameId)
    {
        var reviewScores = await _dbContext.ReviewScores
            .Where(review => review.GameId == gameId)
            .ToListAsync();
        return reviewScores;
    }
}