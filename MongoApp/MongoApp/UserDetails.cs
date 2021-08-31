using MongoDB.Bson.Serialization.Attributes;
using System;

namespace MongoApp
{
    public class UserDetails
    {
        [BsonId]
        public Guid Id { get; set; }
        public string BrideName { get; set; }

        public string GroomName { get; set; }

        public string BrideDOB { get; set; }

        public string GroomDOB { get; set; }

        public string BrideTime { get; set; }

        public string GroomTime { get; set; }

        public string BridePlaceOfBirth { get; set; }

        public string GroomPlaceOfBirth { get; set; }

        public HoroscopeDetails horoscope { get; set; }
    }
}
