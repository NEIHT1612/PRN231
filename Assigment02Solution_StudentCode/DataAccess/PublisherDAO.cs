using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class PublisherDAO
    {
        private static PublisherDAO instance;
        public static readonly object instanceLock = new object();
        public PublisherDAO() { }
        public static PublisherDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new PublisherDAO();

                    }
                    return instance;
                }
            }
        }
        public async Task<IEnumerable<Publisher>> GetPublishersAsync()
        {
            var db = new eBookStoreContext();
            return await db.Publishers.ToListAsync();
        }
        public async Task<Publisher> GetPublisherAsync(int pulisherId)
        {
            var dbcontext = new eBookStoreContext();
            return await dbcontext.Publishers.FindAsync(pulisherId);
        }
        public async Task<Publisher> AddPublisherAsync(Publisher publisher)
        {
            var context = new eBookStoreContext();
            await context.Publishers.AddAsync(publisher);
            await context.SaveChangesAsync();
            return publisher;
        }
        public async Task<Publisher> UpdatePublisherAsync(Publisher publisher)
        {
            if (await GetPublisherAsync(publisher.PubId) == null)
            {
                throw new Exception();
            }
            var context = new eBookStoreContext();
            context.Publishers.Update(publisher);
            await context.SaveChangesAsync();
            return publisher;
        }
        public async Task DeletePublisherAsync(int publisherId)
        {
            Publisher publisher = await GetPublisherAsync(publisherId);
            if (publisher == null)
            {
                throw new Exception();
            }
            var context = new eBookStoreContext();
            context.Publishers.Remove(publisher);
            await context.SaveChangesAsync();
        }
    }
}
