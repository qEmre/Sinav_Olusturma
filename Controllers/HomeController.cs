using Microsoft.AspNetCore.Mvc;
using System.Xml;
using System.ServiceModel.Syndication;
using SinavOlusturma.Repositories;
using SinavOlusturma.Models;

namespace SinavOlusturma.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRssItemRepository _rssItemRepository;

        public HomeController(IRssItemRepository rssItemRepository)
        {
            _rssItemRepository = rssItemRepository;
        }

        public IActionResult Index([FromServices] IRssItemRepository rssItemRepository)
        {
            List<RssItem> rssItems = new List<RssItem>();

            string rssFeedUrl = "https://www.wired.com/feed/rss";

            using (XmlReader reader = XmlReader.Create(rssFeedUrl))
            {
                SyndicationFeed feed = SyndicationFeed.Load(reader);

                foreach (var item in feed.Items.Take(5))
                {
                    RssItem rssItem = new RssItem
                    {
                        Title = item.Title.Text,
                        Description = item.Summary.Text,
                        Link = item.Links[0].Uri.AbsoluteUri,
                        Date = item.PublishDate.DateTime,
                    };

                    if (!_rssItemRepository.GetAll().Any(h => h.Link == rssItem.Link))
                    {
                        _rssItemRepository.Ekle(new RssItem
                        {
                            Title = rssItem.Title,
                            Description = rssItem.Description,
                            Date = rssItem.Date,
                            Link = rssItem.Link,
                        });
                    }
                    rssItems.Add(rssItem);
                }
                _rssItemRepository.Kaydet();
            }
            return View(rssItems);
        }
    }
}