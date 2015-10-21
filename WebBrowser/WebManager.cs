using System;
using System.IO;
using System.Net;
using System.Text;

namespace WebBrowser
{
    public static class WebManager
    {

        //return the html of a page given its url
        public static string getPage(string address)
        {
            try {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(address);
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    Stream receiveStream = response.GetResponseStream();
                    StreamReader readStream = null;

                    if (response.CharacterSet == null)
                    {
                        readStream = new StreamReader(receiveStream);
                    }
                    else
                    {
                        readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                    }

                    string data = readStream.ReadToEnd();
                    response.Close();
                    readStream.Close();
                    return data;
                }
            //if couldn't get the response, return the messages of raised exceptions
            }catch (WebException e) {
                return e.Message;
            }
            catch (UriFormatException e)
            {
                return e.Message;
            }
            return "error";
        }
    }
}
