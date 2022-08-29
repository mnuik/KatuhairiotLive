using Newtonsoft.Json;
using System.Net;
using System.Xml.Serialization;

namespace KatuhairiotLive.Helpers
{
    public class ApiWebRequestHelper
    {
        /// <summary>  
        /// Gets a request from an external JSON formatted API and returns a deserialized object of data.  
        /// </summary>  
        /// <typeparam name="T"></typeparam>  
        /// <param name="requestUrl"></param>  
        /// <returns></returns>  
        public static T GetJsonRequest<T>(string requestUrl)
        {
            try
            {
                WebRequest apiRequest = WebRequest.Create(requestUrl);
                HttpWebResponse apiResponse = (HttpWebResponse)apiRequest.GetResponse();

                if (apiResponse.StatusCode == HttpStatusCode.OK)
                {
                    string jsonOutput;
                    using (StreamReader sr = new StreamReader(apiResponse.GetResponseStream()))
                        jsonOutput = sr.ReadToEnd();

                    var jsResult = JsonConvert.DeserializeObject<T>(jsonOutput);

                    if (jsResult != null)
                        return jsResult;
                    else
                        return default(T);
                }
                else
                {
                    return default(T);
                }
            }
            catch (Exception ex)
            {
                // Log error here.  

                return default(T);
            }
        }

        /// <summary>  
        /// Gets a request from an external XML formatted API and returns a deserialized object of data.  
        /// </summary>  
        /// <typeparam name="T"></typeparam>  
        /// <param name="requestUrl"></param>  
        /// <returns></returns>  
        public static T GetXmlRequest<T>(string requestUrl)
        {
            try
            {
                WebRequest apiRequest = WebRequest.Create(requestUrl);
                HttpWebResponse apiResponse = (HttpWebResponse)apiRequest.GetResponse();

                if (apiResponse.StatusCode == HttpStatusCode.OK)
                {
                    string xmlOutput;
                    using (StreamReader sr = new StreamReader(apiResponse.GetResponseStream()))
                        xmlOutput = sr.ReadToEnd();

                    XmlSerializer xmlSerialize = new XmlSerializer(typeof(T));

                    var xmlResult = (T)xmlSerialize.Deserialize(new StringReader(xmlOutput));

                    if (xmlResult != null)
                        return xmlResult;
                    else
                        return default(T);
                }
                else
                {
                    return default(T);
                }
            }
            catch (Exception ex)
            {
                // Log error here.
                return default(T);
            }
        }
    }
}
