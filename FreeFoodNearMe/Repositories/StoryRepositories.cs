using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FreeFoodNearMe.Models;
using System.Threading.Tasks;

namespace FreeFoodNearMe.Repositories
{
    public class StoryRepositories
    {
        public async Task<IEnumerable<Stories>> GetAllStories()
        {
            var ThisStory = await CosmosRepository<Stories>.GetItemsAsync(d => d.Type == "Story");
            return ThisStory;
        }

        public async Task<IEnumerable<Stories>> GetAllStoriesForService(string Service)
        {
            var ThisStory = await CosmosRepository<Stories>.GetItemsAsync(d => d.Type == "Story" && d.ServiceId == Service);
            return ThisStory;
        }

        public async Task AddStory(Stories Story)
        {
            await CosmosRepository<Stories>.CreateItemAsync(Story);
        }

        public async Task<bool> CheckStoryAvailableByAccountObj(Stories Story)
        {
            bool available = await CosmosRepository<Stories>.CheckItemAvailable(Story.Id);
            return available;
        }

        public async Task<bool> CheckStoryAvailableById(string id)
        {
            bool available = await CosmosRepository<Stories>.CheckItemAvailable(id);
            return available;
        }

        public async Task<Stories> GetStoryByID(string id)
        {
            Stories ThisStory = await CosmosRepository<Stories>.GetItemAsync(id);
            return ThisStory;
        }

        public async Task Edit(Stories Story)
        {
            await CosmosRepository<Stories>.UpdateItemAsync(Story.Id, Story);
        }

        public async Task Delete(Stories Story)
        {
            await CosmosRepository<Stories>.DeleteItemAsync(Story.Id);
        }
    }
}