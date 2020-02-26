using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStudy.Models
{
    public static class Repository
    {
        private static readonly List<GuestResponse> responses = new List<GuestResponse>();

        public static IEnumerable<GuestResponse> guests
        {
            get
            {
                return responses;
            }
        }

        public static void addResponse(GuestResponse guestResponse)
        {
            responses.Add(guestResponse);
        }
    }
}
