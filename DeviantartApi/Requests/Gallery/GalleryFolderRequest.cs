using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Gallery
{
    public class GalleryFolderRequest : PageableRequest<Objects.Deviations>
    {
        public enum SortMode
        {
            Popular,
            Newest
        }

        public enum UserExpand
        {
            Watch
        }

        public HashSet<UserExpand> UserExpands { get; set; } = new HashSet<UserExpand>();
        public string Username { get; set; }
        public bool MatureContent { get; set; }
        public SortMode Mode { get; set; }

        private string _folderid;

        public GalleryFolderRequest(string folderid)
        {
            _folderid = folderid;
        }

        public override async Task<Response<Objects.Deviations>> ExecuteAsync()
        {
            return await ExecuteDefaultGetAsync($"gallery/{_folderid}?"
                + $"username={Username}"
                + "&" + $"mature_content={MatureContent.ToString().ToLower()}"
                + "&" + $"mode={Mode.ToString().ToLower()}"
                + (Offset != null ? $"&offset={Offset}" : "") + (Limit != null ? $"&limit={Limit}" : "")
                + "&expand=" + string.Join(",", UserExpands.Select(x => "user." + x.ToString().ToLower()).ToList()));
        }
    }
}
