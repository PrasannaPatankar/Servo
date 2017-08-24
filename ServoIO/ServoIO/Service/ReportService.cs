using ServoIO.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Newtonsoft.Json;
using System.Net.Http;

namespace ServoIO.Service
{
    public static class ReportService
    {
        public static async Task<List<PrimarySecReport>> GetPrimarySecondaryReport(string Year)
        {
            try
            {
                HttpClient client = new HttpClient();
                var result = await client.GetAsync(Constants.PrimarySecondaryYearlyReport_List + "/" + Year + "");
                result.EnsureSuccessStatusCode();
                string stringJson = await result.Content.ReadAsStringAsync();
                var ObjRoot = JsonConvert.DeserializeObject<List<PrimarySecReport>>(stringJson);
                return ObjRoot;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static async Task<List<IncentiveReport>> GetIncentiveReport(string FromDate, string ToDate)
        {
            try
            {
                HttpClient client = new HttpClient();
                var result = await client.GetAsync(Constants.InsentiveReport_List + "/" + FromDate + "/" + ToDate);
                result.EnsureSuccessStatusCode();
                string stringJson = await result.Content.ReadAsStringAsync();
                var ObjRoot = JsonConvert.DeserializeObject<List<IncentiveReport>>(stringJson);
                return ObjRoot;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static async Task<string> GetUserID(string UserName, string Password, string Role)
        {
            try
            {
                HttpClient client = new HttpClient();
                var result = await client.GetAsync(Constants.Login_GetUserID  + UserName + "/" + Password + "/" + Role);
                result.EnsureSuccessStatusCode();
                string stringJson = await result.Content.ReadAsStringAsync();
                var ObjRoot = JsonConvert.DeserializeObject<string>(stringJson);
                return ObjRoot;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
