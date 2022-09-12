// This code requires the Nuget package Microsoft.AspNet.WebApi.Client to be installed.
// Instructions for doing this in Visual Studio:
// Tools -> Nuget Package Manager -> Package Manager Console
// Install-Package Newtonsoft.Json
// .NET Framework 4.7.1 or greater must be used
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;



namespace CardiovascularAPITest
{
    public partial class Input : Form
    {


        public Input()
        {
            InitializeComponent();

        }

        static async Task InvokeRequestResponseService(string scoreRequestContent)
        {
            var handler = new HttpClientHandler()
            {
                ClientCertificateOptions = ClientCertificateOption.Manual,
                ServerCertificateCustomValidationCallback =
                        (httpRequestMessage, cert, cetChain, policyErrors) => { return true; }
            };
            using (var client = new HttpClient(handler))
            {
                
                
                const string apiKey = "t6HNnhsyQBOY4u8Puk6OBoqeHijcptmb"; // Replace this with the API key for the web service
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
                client.BaseAddress = new Uri("http://19a4b27a-04ce-4987-a763-d068d480f689.southeastasia.azurecontainer.io/score");

                var content = new StringContent(scoreRequestContent);

                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                // WARNING: The 'await' statement below can result in a deadlock
                // if you are calling this code from the UI thread of an ASP.Net application.
                // One way to address this would be to call ConfigureAwait(false)
                // so that the execution does not attempt to resume on the original context.
                // For instance, replace code such as:
                //      result = await DoSomeTask()
                // with the following:
                //      result = await DoSomeTask().ConfigureAwait(false)
                HttpResponseMessage response = await client.PostAsync("", content);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    MessageBox.Show(result);
                }
                else
                {
                    MessageBox.Show(string.Format("The request failed with status code: {0}", response.StatusCode));

                    // Print the headers - they include the requert ID and the timestamp,
                    // which are useful for debugging the failure
                    MessageBox.Show(response.Headers.ToString());

                    string responseContent = await response.Content.ReadAsStringAsync();
                    MessageBox.Show(responseContent);
                }
            }
        }

        private void submit_Click(object sender, EventArgs e)
        {
            int id = 100;

            // Request data goes here
            // The example below assumes JSON formatting which may be updated
            // depending on the format your endpoint expects.
            // More information can be found here:
            // https://docs.microsoft.com/azure/machine-learning/how-to-deploy-advanced-entry-script
            var scoreRequestContent = @"{
                  ""Inputs"": {
                    ""data"": [
                      {
                        ""id"": """ + id + @""",
                        ""age"": """ + this.ageInput.Value + @""",
                        ""gender"": """ + this.genderInput.Text + @""",
                        ""height"": """ + this.heightInput.Value + @""",
                        ""weight"": """ + this.weightInput.Value + @""",
                        ""ap_hi"": """ + this.apHighInput.Value + @""",
                        ""ap_lo"": """ + this.apLowInput.Value + @""",
                        ""cholesterol"": """ + this.cholesterolInput.Value + @""",
                        ""gluc"": """ + this.glucInput.Value + @""",
                        ""smoke"": """ + this.smokeInput.Value + @""",
                        ""alco"": """ + this.alcoholInput.Value + @""",
                        ""active"": """ + this.activeInput.Value + @"""
                      }
                    ]
                  },
                  ""GlobalParameters"": {
                    ""method"": ""predict""
                  }
                }";
            MessageBox.Show(scoreRequestContent);
            _ = InvokeRequestResponseService(scoreRequestContent);
        }

       
    }
    
}
