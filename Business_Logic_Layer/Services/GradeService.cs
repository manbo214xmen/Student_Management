using Data_Acess_Layer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business_Logic_Layer.DTOs;
using Data_Acess_Layer.Entities;


namespace Business_Logic_Layer.Services
{
    public class GradeService
    {
        private readonly GradeRepository _gradeRepository;
        private readonly IMapper _mapper;

        public GradeService(GradeRepository gradeRepository, IMapper mapper)
        {
            this._gradeRepository = gradeRepository;
            this._mapper = mapper;
        }


    }
}
