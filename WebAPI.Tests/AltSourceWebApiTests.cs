using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using WebAPI.Tests.Response;

namespace WebAPI.Tests
{
    [TestFixture]
    public class AltSourceWebApiTests
    {
        protected string baseUrl = "https://api.data.gov/nrel/";
        protected string apiKey = "tuZIu9r5UlF8goYqGLPu9c6Y39uSP1HQXkDiVKgi";
        protected string location = "Austin,TX";
        protected string evNetwork = "ChargePoint Network";
        protected int fuelStationId = 0;
        protected string fuelStationName = "HYATT AUSTIN";
        protected string expectedFuelStationAddress = "208 Barton Springs Rd, Austin, TX, USA, 78704";

        [Test]
        public async Task GetTheNearestFeulStationByCity()
        {
            using (var client = new HttpClient())
            {
                var uriBuilder = new UriBuilder(baseUrl +"alt-fuel-stations/v1/nearest.json");
                var query = HttpUtility.ParseQueryString(uriBuilder.Query);
                query["api_key"] = apiKey;
                query["location"] = location;
                query["ev_network"] = evNetwork;

                uriBuilder.Query = query.ToString();

                HttpResponseMessage response = await client.GetAsync(uriBuilder.ToString());

                Assert.IsTrue(response.IsSuccessStatusCode, string.Format("Get nearest fuel station by city returned an error:{0}", response.StatusCode));

                if(response.IsSuccessStatusCode)
                {
                  NearestAltFuelStation responseData = JsonConvert.DeserializeObject<NearestAltFuelStation> (response.Content.ReadAsStringAsync().Result);

                    foreach(var fuelStation in responseData.fuel_stations )
                    {
                        if (fuelStation.station_name == fuelStationName)
                        {
                            fuelStationId = fuelStation.id;
                            Console.WriteLine(string.Format("Fuel Station name is {0} ", fuelStation.station_name));
                            break;
                        }
                    }

                    Assert.Greater(fuelStationId, 0, "Fuel Station Id did not returned any value");
                    Console.WriteLine(string.Format("Fuel Station id is {0} ", fuelStationId));                     
                }
            }

        }

        

        [Test]
        public async Task GetStattionAddressFromStationId()
        {
            await GetTheNearestFeulStationByCity();
            using (var client = new HttpClient())
            {
                Assert.Greater(fuelStationId, 0, "Fuel Station Id did not returned any value");
                var uriBuilder = new UriBuilder(baseUrl + string.Format("alt-fuel-stations/v1/{0}.json", fuelStationId));
                var query = HttpUtility.ParseQueryString(uriBuilder.Query);
                query["api_key"] = apiKey;

                uriBuilder.Query = query.ToString();

                HttpResponseMessage response = await client.GetAsync(uriBuilder.ToString());

                Assert.IsTrue(response.IsSuccessStatusCode, string.Format("Get fuel station by id returned an error:{0}", response.StatusCode));

                if (response.IsSuccessStatusCode)
                {
                    var responseData = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result) as JObject;
                    var altFuelResponseResponse = JsonConvert.DeserializeObject(responseData["alt_fuel_station"].ToString()) as JObject;

                    Fuel_Stations altFuelStation = JsonConvert.DeserializeObject<Fuel_Stations>(altFuelResponseResponse.ToString());

                    Assert.IsNotNull(altFuelStation.station_name, "Response Data is null");

                    if (altFuelStation.station_name == fuelStationName)
                     {
                         string actualStationAddress = string.Concat(altFuelStation.street_address, ", ", altFuelStation.city, ", ", altFuelStation.state, ", ", "USA, ", altFuelStation.zip);
                         Assert.AreEqual(expectedFuelStationAddress, actualStationAddress, "Actual station address did not matched with expected station address");
                     }
 
                }
            }

        }

    }
}
