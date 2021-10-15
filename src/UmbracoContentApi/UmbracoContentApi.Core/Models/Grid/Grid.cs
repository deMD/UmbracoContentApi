using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace UmbracoContentApi.Core.Models.Grid
{
    public class Grid
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Name { get; set; }

        public int NrOfColumns { get; set; }

        public IEnumerable<Section>? Sections { get; set; }
    }

    public class Section
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Grid { get; set; }

        public int ColumnWidth { get; set; }

        public IEnumerable<Row>? Rows { get; set; }
    }

    public class Row
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Name { get; set; }

        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public Guid Id { get; set; }

        public int NrOfColumns { get; set; }

        public IEnumerable<Area>? Areas { get; set; }
    }

    public class Area
    {
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public string? Grid { get; set; }

        public int ColumnWidth { get; set; }

        public IEnumerable<Control>? Controls { get; set; }
    }


    public class Control
    {
        // EVIL
        public dynamic? Value { get; set; }

        public Editor? Editor { get; set; }
    }

    public class Editor
    {
        public string? Name { get; set; }

        public string? Alias { get; set; }
    }
}