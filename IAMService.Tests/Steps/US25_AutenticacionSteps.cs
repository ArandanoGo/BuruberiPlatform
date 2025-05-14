using System.Net;
using System.Text.Json;
using System.Text;
using RestSharp;
using TechTalk.SpecFlow;
using Xunit;

namespace IAMService.Tests.Steps;

[Binding]
public class US25_AutenticacionSteps
{
    private RestResponse? _response;

    [When(@"hace un POST a ""(.*)""")]
    public async Task WhenHacePost(string endpoint)
    {
        var client = new RestClient("http://localhost:5161");
        var request = new RestRequest(endpoint, Method.Post);

        if (ScenarioContext.Current.ScenarioInfo.Title.Contains("exitosa"))
        {
            request.AddJsonBody(new
            {
                email = "usuario@prueba.com",
                password = "contrasenaCorrecta123"
            });
        }
        else
        {
            request.AddJsonBody(new
            {
                email = "usuario@prueba.com",
                password = "incorrecta"
            });
        }

        _response = await client.ExecuteAsync(request);
    }

    [Then(@"el sistema responde con (\d{3}) OK")]
    public void ThenRespuestaOk(int statusCode)
    {
        Assert.Equal((HttpStatusCode)statusCode, _response!.StatusCode);
    }

    [Then(@"el sistema responde con (\d{3}) Unauthorized")]
    public void ThenRespuestaUnauthorized(int statusCode)
    {
        Assert.Equal((HttpStatusCode)statusCode, _response!.StatusCode);
    }

    [Given(@"que el usuario tiene credenciales válidas")]
    public void GivenUsuarioConCredencialesValidas() { }

    [Given(@"que el usuario tiene credenciales inválidas")]
    public void GivenUsuarioConCredencialesInvalidas() { }
}