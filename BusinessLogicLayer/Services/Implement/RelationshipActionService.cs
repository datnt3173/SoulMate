using AutoMapper;
using AutoMapper.QueryableExtensions;
using BusinessLogicLayer.Services.Interface;
using BusinessLogicLayer.Viewmodels.RelationshipAction;
using DataAccessLayer.ApplicationDBContext;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Services.Implement
{
    public class RelationshipActionService : IRelationshipActionService
    {
        private readonly IMapper _mapper;
        private readonly SoulMateIdentittyDBContext _dbContext;

        public RelationshipActionService(SoulMateIdentittyDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<bool> CreateRelationshipActionAsync(RelationshipActionCreateVM request)
        {
            var newRelationshipAction = new RelationshipAction
            {
                ID = Guid.NewGuid(),
                IDUser = request.IDUser,
                IDRelatedUser = request.IDRelatedUser,
                ActionType = request.ActionType,
                Status = 1,
                CreateBy = request.CreateBy,
                CreateDate = DateTime.Now
            };

            _dbContext.RelationshipAction.Add(newRelationshipAction);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteRelationshipActionAsync(Guid ID)
        {
            try
            {
                var relationshipAction = await _dbContext.RelationshipAction.FindAsync(ID);
                if (relationshipAction == null)
                    return false;

                _dbContext.RelationshipAction.Remove(relationshipAction);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<List<RelationshipActionVM>> GetAllRelationshipActionsAsync()
        {
            var relationshipActions = await _dbContext.RelationshipAction.ToListAsync();
            return _mapper.Map<List<RelationshipActionVM>>(relationshipActions);
        }

        public async Task<RelationshipActionVM> GetRelationshipActionByIDAsync(Guid ID)
        {
            var relationshipAction = await _dbContext.RelationshipAction.FindAsync(ID);
            return _mapper.Map<RelationshipActionVM>(relationshipAction);
        }

        public Task<bool> UpdateRelationshipActionAsync(Guid ID, RelationshipActionUpdateVM request)
        {
            throw new NotImplementedException();
        }
    }
}
