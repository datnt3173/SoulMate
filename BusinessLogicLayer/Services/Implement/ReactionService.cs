using AutoMapper;
using BusinessLogicLayer.Services.Interface;
using BusinessLogicLayer.Viewmodels.Reaction;
using DataAccessLayer.ApplicationDBContext;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using static DataAccessLayer.Entities.Base.EnumBase;

namespace BusinessLogicLayer.Services.Implement
{
    public class ReactionService : IReactionService
    {
        private readonly IMapper _mapper;
        private readonly SoulMateIdentittyDBContext _dbContext;
        public ReactionService(SoulMateIdentittyDBContext SoulMateIdentittyDBContext, IMapper IMapper)
        {
            _dbContext = SoulMateIdentittyDBContext;
            _mapper = IMapper;
        }

        public async Task<bool> CreateAsync(ReactionCreateVM request)
        {
            var newReaction = new Reaction
            {
                ID = Guid.NewGuid(),
                IDUser = request.IDUser,
                IDPost = request.IDPost,
                IDComment = null,
                Type = request.Type,
                Status = 1,
                CreateBy = request.CreateBy,
                CreateDate = DateTime.Now
            };

            _dbContext.Reaction.Add(newReaction);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<ReactionVM>> GetAllActiveInformationAsync()
        {
            var reactions = await _dbContext.Reaction
            .Where(r => r.Status == 1)
            .ToListAsync();

            var reactionVMs = reactions.Select(r => new ReactionVM
            {
                ID = r.ID,
                IDUser = r.IDUser,
                IDPost = r.IDPost,
                IDComment = r.IDComment,
                Type = r.Type,
                Status = r.Status
            }).ToList();

            return reactionVMs;
        }

        public async Task<List<ReactionVM>> GetAllInformationAsync()
        {
            var reactions = await _dbContext.Reaction
            .ToListAsync();

            var reactionVMs = reactions.Select(r => new ReactionVM
            {
                ID = r.ID,
                IDUser = r.IDUser,
                IDPost = r.IDPost,
                IDComment = r.IDComment,
                Type = r.Type,
                Status = r.Status
            }).ToList();

            return reactionVMs;
        }

        public async Task<ReactionVM> GetInformationByID(Guid ID)
        {
            var reaction = await _dbContext.Reaction.FindAsync(ID);
            var reactionVM = new ReactionVM
            {
                ID = reaction.ID,
                IDUser = reaction.IDUser,
                IDPost = reaction.IDPost,
                IDComment = reaction.IDComment,
                Type = reaction.Type,
                Status = reaction.Status
            };

            return reactionVM;
        }

        public async Task<bool> RemoveAsync(Guid ID)
        {
            var reaction = await _dbContext.Reaction.FindAsync(ID);
            if (reaction == null)
                return false;

            _dbContext.Reaction.Remove(reaction);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Guid IDReaction, ReactionType newType)
        {
            var reaction = await _dbContext.Reaction.FindAsync(IDReaction);
            if (reaction == null)
                return false;

            reaction.Type = newType;
            reaction.ModifiedBy = "";
            reaction.CreateDate = DateTime.Now;
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
