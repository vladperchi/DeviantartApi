﻿using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.User
{
    public class ProfileRequest : Request<Objects.Profile>
    {
        public enum Error
        {
            AccountHasBeenSuspended = 0,
            AccountIsInactive = 1,
            UserNotFound = 2
        }

        public enum UserExpand
        {
            Details,
            Geo,
            Stats
        }

        private string _username;

        [Parameter("user")]
        [Expands]
        public HashSet<UserExpand> UserExpands { get; set; } = new HashSet<UserExpand>();

        [Parameter("ext_collections")]
        public bool ExtCollections { get; set; }

        [Parameter("ext_galleries")]
        public bool ExtGalleries { get; set; }

        public ProfileRequest(string username)
        {
            _username = username;
        }

        public override async Task<Response<Objects.Profile>> ExecuteAsync()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddParameter(() => ExtCollections);
            values.AddParameter(() => ExtGalleries);
            values.AddHashSetParameter(() => UserExpands);
            return await ExecuteDefaultGetAsync($"user/profile/{_username}" + values.ToGetParameters());
        }
    }
}