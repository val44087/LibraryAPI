using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RabbitMqUtils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ReservationProcessor
{
    public class ReservationListener : RabbitListener
    {
        ILogger<ReservationListener> Logger;
        ReservationHTTPService Service;

        public ReservationListener(ReservationHTTPService service, ILogger<ReservationListener> logger, IOptionsMonitor<RabbitOptions> options) : base(options)
        {
            Logger = logger;
            Service = service;

        }
        public override Task<bool> Process(string message)
        {
            var request = JsonSerializer.Deserialize<Reservation>(message);
            Logger.LogInformation($"Got a reservation for {request.For}");
            // Log it out.
            // Business logic!
            var shouldApprove = request.Books.Split(',').Length;
            if (shouldApprove <= 3)
            {
                // If Approved - POST /reservations/approved
                return Service.MarkReservationApproved(request);
            }
            else
            {
                // If Denied - POST /reservations/denied
                return Service.MarkReservationDenied(request);
            }
        }
    };
  
}
