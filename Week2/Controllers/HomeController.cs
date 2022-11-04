using BackendStageTwo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Text;
using System.Configuration;

namespace BackendStageTwo.Controllers;
[ApiController]
[Route("api")]
public class HomeController : ControllerBase
{
    private static readonly AboutMeModel _RESPONSE_ = AboutMeModel.ResponseModelInstance;
    private static readonly string OPENAI_KEY = "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";
    private HttpClient client = new ();

    [HttpGet]
    public IActionResult Get()
    {

        HttpContext.Response.Headers.Add("access-control-allow-origin", "*");
        return Ok(_RESPONSE_);
    }

    [HttpPost("maths")]
    public async Task<ActionResult<MathematicalOperationResponseModel>> 
        PerformMatematicalOperation([FromBody] MathematicalOperationRequestModel requestModel)
    {
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/json"));
        client.DefaultRequestHeaders.Add("Authorization", $"Bearer {OPENAI_KEY}");
        client.DefaultRequestHeaders.Add("User-Agent", "HNG Backend");


        var operationString = await ProcessOperationTypeAsync(client, requestModel.operation_type);
        var mathematicalModel = new MathematicalOperationModel();
        mathematicalModel.x = requestModel.x;
        mathematicalModel.y = requestModel.y;
        
        switch (operationString)
        {
            case "Addition":
                mathematicalModel.operation_type = OperationType.addition;
                break;

            case "Subtraction":
                mathematicalModel.operation_type = OperationType.subtraction;
                break;

            case "Multiplication":
                mathematicalModel.operation_type = OperationType.multiplication;
                break;
            default:
                return BadRequest();
        }
        mathematicalModel.PerformOperation();


        var response = new MathematicalOperationResponseModel() { result = mathematicalModel.result, operation_type = mathematicalModel.operation_type };

        return Ok(response);
    }

    public async Task<string?> ProcessOperationTypeAsync(HttpClient client, string operation_string)
    {
        var requestdata = new OpenAIRequestModel();
        requestdata.prompt =$"Convert this text to a single mathematical operation. Output should be one of Addition, Substitution," +
            $" Multiplication\nExample = Alli goes to school and was asked to find the solution of 2 * 2\nOutput: Multiplication\n\n" +
            $"Example = Add them together\nOutput: Addition\n\nExample = Subtract x from y\nOutput: Subtraction\n\n{ operation_string}\".";

        var stringContent = new StringContent(JsonConvert.SerializeObject(requestdata), Encoding.UTF8, "application/json");
        string x = await stringContent.ReadAsStringAsync();
       
        var res = await client.PostAsync("https://api.openai.com/v1/completions", stringContent);
        var resJson = await res.Content.ReadAsStringAsync();
        var openApiResponse = JsonConvert.DeserializeObject<openAIResponseModel>(resJson);
        
        var sanitizedResponse = openApiResponse.choices[0].text.Trim().Replace("Output: ", "");
        return sanitizedResponse;

    }
}
