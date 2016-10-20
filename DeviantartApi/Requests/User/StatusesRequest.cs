﻿using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.User
{
    public class StatusesRequest : PageableRequest<Objects.ArrayOfResults<Objects.Status>>
    {
        [Parameter("username")]
        public string Username { get; set; }

        [Parameter("mature_contetn")]
        public bool MatureContent { get; set; }

        public override async Task<Response<Objects.ArrayOfResults<Objects.Status>>> ExecuteAsync()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddParameter(() => Username);
            values.AddParameter(() => MatureContent);
            if (Offset != null) values.AddParameter(() => Offset);
            if (Limit != null) values.AddParameter(() => Limit);
            return await ExecuteDefaultGetAsync("user/statuses/?" + values.ToGetParameters());
        }
    }
}