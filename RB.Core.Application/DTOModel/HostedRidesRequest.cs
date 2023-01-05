using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RB.Core.Application.DTOModel
{
    public class HostedRidesRequest
    {
        public string StartLocation { get; set; } = string.Empty;
        public string EndLocation { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime StartTime { get; set; }
        public int VehicleId { get; set; }
        public string MemberId { get; set; } = string.Empty;

    }
}
