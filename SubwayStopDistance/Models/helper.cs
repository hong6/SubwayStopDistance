using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using System.Web;
using System.IO;

namespace SubwayStopDistance.Models
{
    public static class TrainHelper
    {
        static string pathToFiles = HttpContext.Current.Server.MapPath("~/Content/stops.txt");
      
        public static List<StopViewModel> GetFromFile()
        {
            var query = File.ReadLines(pathToFiles)
               .Select(line => line.Split(','))
               .Select(tokens => new StopViewModel { stop_id = tokens[0], stop_name = tokens[1], stop_latlonFrom = tokens[3] + "_" + tokens[4], stop_latlonTo = tokens[3] + "_" + tokens[4] }).OrderBy(o => o.stop_name)             
               .ToList();
            return query;
        }       
    }   

    public class DistanceAlgorithm
    {
        const double PIx = 3.141592653589793;
        const double RADIUS = 6378.16;

        private DistanceAlgorithm() { }

        public static double Radians(double x)
        {
            return x * PIx / 180;
        }

        public static double DistanceBetweenPlaces(
            double lon1,
            double lat1,
            double lon2,
            double lat2)
        {
            double dlon = Radians(lon2 - lon1);
            double dlat = Radians(lat2 - lat1);

            double a = (Math.Sin(dlat / 2) * Math.Sin(dlat / 2)) + Math.Cos(Radians(lat1)) * Math.Cos(Radians(lat2)) * (Math.Sin(dlon / 2) * Math.Sin(dlon / 2));
            double angle = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return angle * RADIUS;
        }
    }
}