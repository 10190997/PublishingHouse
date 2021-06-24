using System.Collections;
using System.Data.Entity;
using System.Linq;

namespace ClassLibraryPublishingHouse
{
    public static class DB
    {
        public static PublishingHouseEntities db;

        static DB()
        {
            db = new PublishingHouseEntities();
        }

        public static IEnumerable LoadAllPublications()
        {
            db.Publications.Load();
            db.Magazines.Load();
            db.PublicationTypes.Load();
            db.Authors.Load();
            db.UDKs.Load();
            return db.Publications.ToList();
        }
    }
}