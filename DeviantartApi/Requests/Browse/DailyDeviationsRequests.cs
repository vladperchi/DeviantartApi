﻿using DeviantartApi.Attributes;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace DeviantartApi.Requests.Browse
{
    /// <summary>
    /// Browse daily deviations
    /// </summary>
    public class DailyDeviationsRequest : Request<Objects.ArrayOfResults<Objects.Deviation>>
    {
        public enum UserExpand
        {
            Watch
        }

        [Parameter("user")]
        [Expands]
        public HashSet<UserExpand> UserExpands { get; set; } = new HashSet<UserExpand>();

        /// <summary>
        /// The day to browse, defaults(null) to today
        /// </summary>
        [Parameter("date")]
        [DateTimeFormat("yyyy-MM-dd")]
        public DateTime? Day { get; set; } = null;

        [Parameter("mature_content")]
        public bool MatureContent { get; set; }

        public override Task<Response<Objects.ArrayOfResults<Objects.Deviation>>> ExecuteAsync(CancellationToken cancellationToken)
        {
            var values = new Dictionary<string, string>();
            values.AddParameter(() => Day);
            values.AddHashSetParameter(() => UserExpands);
            values.AddParameter(() => MatureContent);
            cancellationToken.ThrowIfCancellationRequested();
            return ExecuteDefaultGetAsync("browse/dailydeviations?" + values.ToGetParameters(), cancellationToken);
        }
    }
}
