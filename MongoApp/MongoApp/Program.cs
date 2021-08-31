using System;

namespace MongoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // If database is not there then it will create or else use the existing one.
            MongoCRUD db = new MongoCRUD("Biodata");

            // Option 1: To insert partially
            // db.InsertRecord<UserDetails>("horoscope", new UserDetails { GroomName = "Nani", BrideName = "Potti" });

            // Option 2: Insert full record
            var userWithHoroscope = new UserDetails
            {
                GroomName = "Nani",
                BrideName = "Potti",
                BrideDOB = "1993-12-20",
                GroomDOB = "1987-10-29",
                BridePlaceOfBirth = "Kakinada",
                GroomPlaceOfBirth = "Nellore",
                BrideTime = "2:00 PM",
                GroomTime = "5:00 PM",
                horoscope = new HoroscopeDetails()
                {
                    MatchCount = 29,
                    MatchStatus = "Perfect",
                    Reason = "Sooper ga chesukovachu",
                }
            };

            db.InsertRecord<UserDetails>("horoscope", userWithHoroscope);
        }
    }
}
