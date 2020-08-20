using System;
using System.Collections.Generic;
using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace studentOrganizer
{
    public partial class FullTimeTable
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("abbr", NullValueHandling = NullValueHandling.Ignore)]
        public string Abbr { get; set; }

        [JsonProperty("faculties", NullValueHandling = NullValueHandling.Ignore)]
        public List<Faculty> Faculties { get; set; }
    }

    public partial class Faculty
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("groups", NullValueHandling = NullValueHandling.Ignore)]
        public List<Group> Groups { get; set; }
    }

    public partial class Group
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("lessons", NullValueHandling = NullValueHandling.Ignore)]
        public List<Lesson> Lessons { get; set; }
    }

    public partial class Lesson
    {
        [JsonProperty("subject", NullValueHandling = NullValueHandling.Ignore)]
        public string Subject { get; set; }

        [JsonProperty("type", NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        [JsonProperty("time", NullValueHandling = NullValueHandling.Ignore)]
        public Time Time { get; set; }

        [JsonProperty("date", NullValueHandling = NullValueHandling.Ignore)]
        public Date Date { get; set; }

        [JsonProperty("audiences", NullValueHandling = NullValueHandling.Ignore)]
        public List<Audience> Audiences { get; set; }

        [JsonProperty("teachers", NullValueHandling = NullValueHandling.Ignore)]
        public List<Audience> Teachers { get; set; }
    }

    public partial class Audience
    {
        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
    }

    public partial class Date
    {
        [JsonProperty("start", NullValueHandling = NullValueHandling.Ignore)]
        public string Start { get; set; }

        [JsonProperty("end", NullValueHandling = NullValueHandling.Ignore)]
        public string End { get; set; }

        [JsonProperty("weekday", NullValueHandling = NullValueHandling.Ignore)]
        public int? Weekday { get; set; }

        [JsonProperty("week", NullValueHandling = NullValueHandling.Ignore)]
        public int? Week { get; set; }
    }

    public partial class Time
    {
        [JsonProperty("start", NullValueHandling = NullValueHandling.Ignore)]
        public string Start { get; set; }

        [JsonProperty("end", NullValueHandling = NullValueHandling.Ignore)]
        public string End { get; set; }
    }
}