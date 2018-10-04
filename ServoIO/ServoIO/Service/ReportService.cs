using ServoIO.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using static ServoIO.Service.ForTest;

namespace ServoIO.Service
{
    public static class ReportService
    {
        public static async Task<SSRCreditAnalysisReport> GetCreditAnalysisReport()
        {
            try
            {
                HttpClient client = new HttpClient(); //http://172.25.29.70/SurvoWebAPI
                var result = await client.GetAsync("http://172.25.29.70:1273/api/CreditAnalysis/GetReport/08-01-2015/08-25-2016/1/1003");
                result.EnsureSuccessStatusCode();
                string stringJson = await result.Content.ReadAsStringAsync();
                var ObjRoot = JsonConvert.DeserializeObject<SSRCreditAnalysisReport>(stringJson);
                
                return ObjRoot;
            }
            catch (Exception)
            {
                throw;
            }
        }


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
            catch (Exception ex)
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
