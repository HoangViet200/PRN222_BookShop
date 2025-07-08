using PRN222_BookShop.DA;
using PRN222_DreamsCar.Models;

namespace PRN222_BookShop.Services
{
    public class PublisherServices :IPublisherServices
    {
        private readonly IPublisherDA _publisherDA;
        public PublisherServices(IPublisherDA publisherDA)
        {
            _publisherDA = publisherDA;
        }
        public List<Publisher> GetAllPublishers()
        {
            return _publisherDA.GetAllPublishers();
        }
    }
}
