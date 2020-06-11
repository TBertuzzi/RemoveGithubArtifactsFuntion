using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace RemoveGithubArtifactsFuntion
{
    public static class RemoveArtifactsFuntion
    {
        [FunctionName("RemoveArtifactsFuntion")]
        public static async void Run([TimerTrigger("0 0 1 * * *", RunOnStartup = true)]TimerInfo myTimer, ILogger log) //Voce pode definir o Horario de Execução no NCron
        {
            await ExecuteRemoveArtifacts("Seu Usuario ou Organização","Seu Repositorio");
        }

        public static async Task ExecuteRemoveArtifacts(string usuario,string repositorio)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://api.github.com");
            var token = "seu token";

            client.DefaultRequestHeaders.UserAgent.Add(new System.Net.Http.Headers.ProductInfoHeaderValue("AppName", "3.0"));
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Token", token);

            var response = await client.GetAsync<Github>($"/repos/{usuario}/{repositorio}/actions/artifacts");

            foreach (Artifact artifact in response.Value?.Artifacts)
            {
                await client.DeleteAsync($"/repos/{usuario}/{repositorio}/actions/artifacts/{artifact.Id}");
            }

        }

    }
}
