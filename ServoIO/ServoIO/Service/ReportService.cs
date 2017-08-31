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
                var result = await client.GetAsync(Constants.Login_GetUserID + UserName + "/" + Password + "/" + Role);
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

        //2014-03-01/2017-08-23

        public static async Task<List<SSRPerformance>> Get_SSRPerformanceReport(string FromDate, string ToDate)
        {
            try
            {
                HttpClient client = new HttpClient();
                var result = await client.GetAsync(Constants.SSRPerformance + "/" + FromDate + "/" + ToDate);
                result.EnsureSuccessStatusCode();
                string stringJson = await result.Content.ReadAsStringAsync();
                var ObjRoot = JsonConvert.DeserializeObject<List<SSRPerformance>>(stringJson);
                return ObjRoot;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static async Task<List<LedgerReport>> Get_LedgerReport(string FromDate, string ToDate, string LedgerName)
        {
            try
            {
                HttpClient client = new HttpClient();
                var result = await client.GetAsync(Constants.LedgerReport + "/" + FromDate + "/" + ToDate + "/" + LedgerName);
                result.EnsureSuccessStatusCode();
                string stringJson = await result.Content.ReadAsStringAsync();
                var ObjRoot = JsonConvert.DeserializeObject<List<LedgerReport>>(stringJson);
                return ObjRoot;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static async Task<List<LedgerName>> Get_LedgerName()
        {
            try
            {
                HttpClient client = new HttpClient();
                var result = await client.GetAsync(Constants.LedgerName);
                result.EnsureSuccessStatusCode();
                string stringJson = await result.Content.ReadAsStringAsync();
                var ObjRoot = JsonConvert.DeserializeObject<List<LedgerName>>(stringJson);
                return ObjRoot;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
