using Microsoft.AspNetCore.Mvc.Infrastructure;
using RB.Core.Application.DTOModel;
using RB.Core.Application.Interface;
using RB.Core.Domain.Models;
using RB.Infrastructure.RB.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RB.Infrastructure.RB.Infrastructure.Services.User
{
    public class HostRideService : IHostRide
    {
        private readonly UserDbContext _userDbContext;
        public HostRideService(UserDbContext userDbContext)
        {
            _userDbContext = userDbContext;
        }

        public UserResponseDTO HostRide(HostedRidesRequest hostedRides, string id)
        {
            

            UserResponseDTO response = new UserResponseDTO();

            var user = _userDbContext.Users.Where(x => x.EmployeeId == id).ToList();
            var vehicles = _userDbContext.Vehicles.Where(x => x.VehicleId == hostedRides.VehicleId).ToList();
            if (user.Count != 0)
            {
                if (vehicles.Count != 0)
                {
                    var hosted = new HostedRides()
                    {
                        StartLocation = hostedRides.StartLocation,
                        EndLocation = hostedRides.EndLocation,
                        StartDate = hostedRides.StartDate,
                        StartTime = hostedRides.StartTime,
                        HostId = user[0].EmployeeId,
                        VehicleId = vehicles[0].VehicleId
                    };
                    _userDbContext.Add(hosted);
                    _userDbContext.SaveChangesAsync();

                    response.Output = "Ride hosted succesfully";
                    response.Status = true;
                    return response;
                }
                else
                {
                    response.Output = "Ride host unsuccesfull - Vehicle not found ";
                    response.Status = false;
                    return response;

                }

            }
            else
            {
                response.Output = "Ride host unsuccesfull - Member id is not fetched";
                response.Status = false;
                return response;

            }
        }
    }
}
