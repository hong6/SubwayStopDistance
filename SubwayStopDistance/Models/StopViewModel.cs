using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using System.Web;
using System.IO;

namespace SubwayStopDistance.Models
{

    public class StopViewModel
    {
        private List<StopViewModel> _listvm;        

        public string stop_id { get; set; }        
        public string stop_name { get; set; }           
        public string stop_latlonFrom { get; set; }
        public string stop_latlonTo { get; set; }

        public List<StopViewModel> listvm
        {
            get
            {
                return TrainHelper.GetFromFile();
            }
            set
            {
                _listvm = value;
            }
        }
        
    }
}