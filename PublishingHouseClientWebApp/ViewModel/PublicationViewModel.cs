using ClassLibraryPublishingHouse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublishingHouseClientWebApp.ViewModel
{
    public class PublicationViewModel
    {
        public IEnumerable<Publication> Publications { get; set; }
    }
}