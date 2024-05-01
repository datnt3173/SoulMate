using AutoMapper;
using BusinessLogicLayer.Viewmodels.RelationshipAction;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.AutoMapper
{
    public class RelationshipActionMap : Profile
    {
        public RelationshipActionMap()
        {
            CreateMap<RelationshipAction, RelationshipActionVM>().ReverseMap();
        }
    }
}
