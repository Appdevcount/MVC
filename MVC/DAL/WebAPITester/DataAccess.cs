using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using MVC.Models.WebAPITester;
using System.Web.Script.Serialization;
using System.Text;

namespace MVC.DAL.WebAPITester
{
    //http://stackoverflow.com/questions/19158378/httpclient-not-supporting-postasjsonasync-method-c-sharp
    //There is some issue is using Postasjsonasync and putasjsonasync methods , 
    //please refer above discussion for better method to use new string content to pass parameter to API

    //============
    //XML serialize and deserialization technique - http://www.csharptutorial.in/10/csharp-net-xml-deserialization-in-csharp

    //Can use XMLserializer in place of JSONserialier in Httpcontent new stringcontent() method as per below links
    //https://stackoverflow.com/questions/25352462/how-to-send-xml-content-with-httpclient-postasync
    //https://stackoverflow.com/questions/41985373/post-call-for-xml-content-using-httpclient
    //https://www.experts-exchange.com/questions/28942195/Asynchronous-HttpClient-request-as-text-xml.html
    public class DataAccess
    {
        private string Base_URL = "http://localhost/WEBAPIProject/api/";

        public IEnumerable<Customer> findAll()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("customersapi").Result;

                if (response.IsSuccessStatusCode)
                {
                    string JsonString= response.Content.ReadAsStringAsync().Result;
                    //use JavaScriptSerializer from System.Web.Script.Serialization
                    JavaScriptSerializer JSserializer = new JavaScriptSerializer();
                    //deserialize to your class
                    return JSserializer.Deserialize<IEnumerable<Customer>>(JsonString);
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        public Customer find(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("customersapi/" + id).Result;

                if (response.IsSuccessStatusCode)
                {

                    string JsonString = response.Content.ReadAsStringAsync().Result;
                    //use JavaScriptSerializer from System.Web.Script.Serialization
                    JavaScriptSerializer JSserializer = new JavaScriptSerializer();
                    //deserialize to your class
                    return JSserializer.Deserialize<Customer>(JsonString);
                }
                return null;
            }
            catch
            {
                return null;
            }
        }
        public bool Create(Customer customer)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                HttpResponseMessage response = client.PostAsync("customersapi", new StringContent(
                    new JavaScriptSerializer().Serialize(customer), Encoding.UTF8, "application/json")).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
        public bool Edit(Customer customer)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.PutAsync("customersapi/" + customer.CustId, new StringContent(
                    new JavaScriptSerializer().Serialize(customer), Encoding.UTF8, "application/json")).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(int id)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Base_URL);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.DeleteAsync("customersapi/" + id).Result;
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }
    }
}