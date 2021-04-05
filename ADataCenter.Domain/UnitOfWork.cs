﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADataCenter.Domain
{
    public class UnitOfWork : IUnitOfWork<Incident>
    {
        private readonly IRepository<Incident> IncidentRepository;

        public UnitOfWork(IRepository<Incident> inRepository)
        {
            this.IncidentRepository = inRepository;
        }
        public Task<Incident> Create(Incident item)
        {
            return IncidentRepository.Create(item);
        }

        public Task<EN_RETCODE> Delete(Guid id)
        {
            return IncidentRepository.Delete(id);
        }

        public Task<IEnumerable<Incident>> GetAll()
        {
            return IncidentRepository.GetAll();
        }

        public Task<Incident> GetById(Guid id)
        {
            return IncidentRepository.GetById(id);
        }

        public Task<EN_RETCODE> Update(Incident item)
        {
            return IncidentRepository.Update(item);
        }
    }
}
