using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace RemoveGithubArtifactsFuntion
{
    public partial class Github
    {
        [JsonProperty("total_count")]
        public long TotalCount { get; set; }

        [JsonProperty("artifacts")]
        public Artifact[] Artifacts { get; set; }
    }

    public partial class Artifact
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("node_id")]
        public string NodeId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("size_in_bytes")]
        public long SizeInBytes { get; set; }

        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("archive_download_url")]
        public Uri ArchiveDownloadUrl { get; set; }

        [JsonProperty("expired")]
        public bool Expired { get; set; }

        [JsonProperty("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; }
    }


}
