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
        private readonly StoryRepositories storyRepositories;

        public SiteService()
        {
            this.serviceRepositories = new ServiceRepositories();
            this.storyRepositories = new StoryRepositories();
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

        /************ Story functions ***************/
        public async Task<IEnumerable<Stories>> GetAllStories()
        {
            return await storyRepositories.GetAllStories();
        }
        public async Task<IEnumerable<Stories>> GetAllStoriesForService(string Service)
        {
            return await storyRepositories.GetAllStoriesForService(Service);
        }

        public async Task<Stories> StoryGetByID(string id)
        {
            return await storyRepositories.GetStoryByID(id);
        }

        public async Task DeleteStory(Stories ThisStory)
        {
            await storyRepositories.Delete(ThisStory);
        }

        public async Task EditStory(Stories ThisStory)
        {
            await storyRepositories.Edit(ThisStory);
        }

        public async Task StoriesAddStory(Stories ThisStory)
        {
            await storyRepositories.AddStory(ThisStory);
        }
    }
}