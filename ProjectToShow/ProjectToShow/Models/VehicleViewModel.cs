using ConexionDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectToShow.Models
{
    public class VehicleViewModel
    {

        public VehicleViewModel()
        {
        }
        public VehicleViewModel(Vehicle vehicle)
        {
            if (vehicle == null)
            {
                vehicle = new Vehicle();
            }

            Id = vehicle.Id;
            Color = vehicle.Color;
            Make = vehicle.Make;
            Year = vehicle.Year;
            Miles = vehicle.Miles;

        }

        public int Id { get; set; }
       
        public string Color { get; set; }

        public string Make { get; set; }

        public int Year { get; set; }

        public double Miles { get; set; }

        public Vehicle ToVehicle(Vehicle vehicleObj) 
        {
            if (vehicleObj == null)
            {
                vehicleObj = new Vehicle();
            }
           

                vehicleObj.Id = Id;
                vehicleObj.Make = Make;
                vehicleObj.Year = Year;
                vehicleObj.Color = Color;
                vehicleObj.Miles = Miles;
         

            return vehicleObj;
        }

    }

    public class DeleteVehicleViewModel
    {

        public DeleteVehicleViewModel()
        {
        }
        public DeleteVehicleViewModel(Vehicle vehicle)
        {
            if (vehicle == null)
            {
                vehicle = new Vehicle();
            }

            Id = vehicle.Id;
            Color = vehicle.Color;
            Make = vehicle.Make;
            Year = vehicle.Year;
            Miles = vehicle.Miles;

        }

        public int Id { get; set; }

        public string Color { get; set; }

        public string Make { get; set; }

        public int Year { get; set; }

        public double Miles { get; set; }

        

    }
}