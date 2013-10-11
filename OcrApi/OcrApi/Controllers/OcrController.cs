using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using OcrApi.Models;
using Ocr_Server.HttpExtentions;

namespace OcrApi.Controllers
{
    public class OcrController : ApiController
    {
        public HttpResponseMessage<ParkingConfirmation> Post(ParkingDetails id)
        {
            //if (parkingDetails.LocationFile != null && parkingDetails.LocationFile.ContentLength > 0)

            var result = new ParkingConfirmation
            {
                Id = 122345,
                Location = new Location
                {
                    Id = 1,
                    Name = "Vancouver"
                },
                QuotedPrice = 0.30m,
                UserProperties = new UserProperties
                {
                    Vehicle = new Dictionary<string, string>() { { "car 1 ", "123 sdf" }, { "car 2", "sdf234" } }
                }
            };

            return Request.CreateResponse(result);
        }
    }
}