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
            //var userWithHoroscope = new UserDetails
            //{
            //    GroomName = "Nani",
            //    BrideName = "Potti",
            //    BrideDOB = "1993-12-20",
            //    GroomDOB = "1987-10-29",
            //    BridePlaceOfBirth = "Kakinada",
            //    GroomPlaceOfBirth = "Nellore",
            //    BrideTime = "2:00 PM",
            //    GroomTime = "5:00 PM",
            //    horoscope = new HoroscopeDetails()
            //    {
            //        MatchCount = 29,
            //        MatchStatus = "Perfect",
            //        Reason = "Sooper ga chesukovachu",
            //    }
            //};

            //db.InsertRecord<UserDetails>("horoscope", userWithHoroscope);

            var userDetails = db.LoadRecords<UserDetails>("horoscope");
            foreach (var user in userDetails)
            {
                Console.WriteLine($"Groom : {user?.GroomName} vs Bride: {user?.BrideName} and status of their horoscope: {user?.horoscope?.MatchStatus}.");
            }

            // var userRec = db.LoadRecordById<UserDetails>("horoscope", new Guid("1cf60e95-20aa-40cf-a0b2-0722cd42884b"));
            var userRec = db.LoadRecordById<UserDetails>("horoscope", new Guid("1cf60e95-20aa-40cf-a0b2-0722cd42884b"));
            Console.WriteLine($"Horoscope status: {userRec?.horoscope?.MatchStatus} and reason: {userRec?.horoscope?.Reason}");
            Console.ReadKey();
        }
    }
}
