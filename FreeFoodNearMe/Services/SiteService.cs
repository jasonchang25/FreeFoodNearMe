using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FreeFoodNearMe.Repositories;
using FreeFoodNearMe.Models;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FreeFoodNearMe.Services
{
    public class SiteService
    {
        private readonly ServiceRepositories serviceRepositories;

        public SiteService()
        {
            this.serviceRepositories = new ServiceRepositories(); 
        }

        /************ Food Services functions ***************/
        public async Task<IEnumerable<Service>> GetAllServices()
        {
            return await serviceRepositories.GetAllServices();
        }

        public async Task<IEnumerable<Service>> GetPendingServices()
        {
            return await serviceRepositories.GetPendingServices();
        }

        public async Task<Service> ServiceGetByID(string id)
        {
            return await serviceRepositories.GetServiceByID(id);
        }

        public async Task DeleteService(Service ThisService)
        {
            await serviceRepositories.Delete(ThisService);
        }

        public async Task EditService(Service ThisService)
        {
            await serviceRepositories.Edit(ThisService);
        }

        public async Task ServicesAddService(Service ThisService)
        {
            await serviceRepositories.AddService(ThisService);
        }
    }
}