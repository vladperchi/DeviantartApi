using DeviantartApi.Attributes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Comments.Status
{
    public class StatusRequest : PageableRequest<Objects.Comments>
    {
        [Parameter("commentid")]
        public string CommentId { get; set; }

        [Parameter("maxdepth")]
        public uint MaxDepth { get; set; }

        private string _statusid;

        public StatusRequest(string statusid)
        {
            _statusid = statusid;
        }

        public override async Task<Response<Objects.Comments>> ExecuteAsync()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.AddParameter(() => CommentId);
            values.AddParameter(() => MaxDepth);
            if (Offset != null) values.AddParameter(() => Offset);
            if (Limit != null) values.AddParameter(() => Limit);
            return await ExecuteDefaultGetAsync($"comments/status/{_statusid}?" + values.ToGetParameters());
        }
    }
}