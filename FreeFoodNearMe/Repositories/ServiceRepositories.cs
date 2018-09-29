using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FreeFoodNearMe.Models;
using System.Threading.Tasks;

namespace FreeFoodNearMe.Repositories
{
    public class ServiceRepositories
    {
        public async Task<IEnumerable<Service>> GetAllServices()
        {
            var ThisService = await CosmosRepository<Service>.GetItemsAsync(d => d.Type == "Service");
            return ThisService;
        }

        public async Task<IEnumerable<Service>> GetPendingServices()
        {
            var ThisService = await CosmosRepository<Service>.GetItemsAsync(d => d.Type == "PendingService");
            return ThisService;
        }

        public async Task AddService(Service service)
        {
            await CosmosRepository<Service>.CreateItemAsync(service);
        }

        public async Task<bool> CheckServiceAvailableByAccountObj(Service service)
        {
            bool available = await CosmosRepository<Service>.CheckItemAvailable(service.Id);
            return available;
        }

        public async Task<bool> CheckServiceIAvailableById(string id)
        {
            bool available = await CosmosRepository<Service>.CheckItemAvailable(id);
            return available;
        }

        public async Task<Service> GetServiceByID(string id)
        {
            Service ThisService = await CosmosRepository<Service>.GetItemAsync(id);
            return ThisService;
        }

        public async Task Edit(Service Service)
        {
            await CosmosRepository<Service>.UpdateItemAsync(Service.Id, Service);
        }

        public async Task Delete(Service Service)
        {
            await CosmosRepository<Service>.DeleteItemAsync(Service.Id);
        }
    }
}