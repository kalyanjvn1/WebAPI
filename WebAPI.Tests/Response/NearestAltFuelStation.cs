﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Tests.Response
{
   

    public class NearestAltFuelStation
    {
        public float latitude { get; set; }
        public float longitude { get; set; }
        public Precision precision { get; set; }
        public string station_locator_url { get; set; }
        public int total_results { get; set; }
        public Station_Counts station_counts { get; set; }
        public int offset { get; set; }
        public Fuel_Stations[] fuel_stations { get; set; }
    }

    public class Precision
    {
        public string name { get; set; }
        public string[] types { get; set; }
        public int value { get; set; }
    }

    public class Station_Counts
    {
        public int total { get; set; }
        public Fuels fuels { get; set; }
    }

    public class Fuels
    {
        public E85 E85 { get; set; }
        public ELEC ELEC { get; set; }
        public HY HY { get; set; }
        public LNG LNG { get; set; }
        public BD BD { get; set; }
        public CNG CNG { get; set; }
        public LPG LPG { get; set; }
    }

    public class E85
    {
        public int total { get; set; }
    }

    public class ELEC
    {
        public int total { get; set; }
        public Stations stations { get; set; }
    }

    public class Stations
    {
        public int total { get; set; }
    }

    public class HY
    {
        public int total { get; set; }
    }

    public class LNG
    {
        public int total { get; set; }
    }

    public class BD
    {
        public int total { get; set; }
    }

    public class CNG
    {
        public int total { get; set; }
    }

    public class LPG
    {
        public int total { get; set; }
    }

    public class Fuel_Stations
    {
        public string access_days_time { get; set; }
        public object cards_accepted { get; set; }
        public string date_last_confirmed { get; set; }
        public object expected_date { get; set; }
        public string fuel_type_code { get; set; }
        public int id { get; set; }
        public string groups_with_access_code { get; set; }
        public object open_date { get; set; }
        public object owner_type_code { get; set; }
        public string status_code { get; set; }
        public string station_name { get; set; }
        public string station_phone { get; set; }
        public DateTime updated_at { get; set; }
        public string geocode_status { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        public string city { get; set; }
        public string intersection_directions { get; set; }
        public object plus4 { get; set; }
        public string state { get; set; }
        public string street_address { get; set; }
        public string zip { get; set; }
        public object bd_blends { get; set; }
        public object e85_blender_pump { get; set; }
        public string[] ev_connector_types { get; set; }
        public object ev_dc_fast_num { get; set; }
        public int? ev_level1_evse_num { get; set; }
        public int? ev_level2_evse_num { get; set; }
        public string ev_network { get; set; }
        public string ev_network_web { get; set; }
        public object ev_other_evse { get; set; }
        public object hy_status_link { get; set; }
        public object lpg_primary { get; set; }
        public object ng_fill_type_code { get; set; }
        public object ng_psi { get; set; }
        public object ng_vehicle_class { get; set; }
        public Ev_Network_Ids ev_network_ids { get; set; }
        public float distance { get; set; }
    }

    public class Ev_Network_Ids
    {
        public string[] posts { get; set; }
    }
}
