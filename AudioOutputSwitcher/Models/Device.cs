namespace AudioOutputSwitcher.Models
{
    using System;
    using Newtonsoft.Json;

    public class Device
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("deviceId")]
        public Guid DeviceId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
