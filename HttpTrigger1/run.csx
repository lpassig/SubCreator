#r "Newtonsoft.Json"

using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

public static async Task<IActionResult> Run(HttpRequest req, ILogger log)
{
    log.LogInformation("C# HTTP trigger function processed a request.");

    string name = req.Query["name"];
    string Availability = req.Query["Availability"];
    string Integrity = req.Query["Integrity"];
    string Confidentiality = req.Query["Confidentiality"];
    string NetworkReq = req.Query["NetworkReq"];
    string DataDone = req.Query["DataDone"];
    string PoC = req.Query["PoC"];

    string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
    dynamic data = JsonConvert.DeserializeObject(requestBody);
    
    name = name ?? data?.name;
    Availability = Availability ?? data?.Availability;
    Integrity = Integrity ?? data?.Integrity;
    Confidentiality = Confidentiality ?? data?.Confidentiality;
    NetworkReq = NetworkReq ?? data?.NetworkReq;
    DataDone = DataDone ?? data?.DataDone;
    PoC = PoC ?? data?.PoC;

    return name != null
        ? (ActionResult)new OkObjectResult($"Hello {name} your result was, Availability: {Availability}, Integrity: {Integrity}, Confidentiality: {Confidentiality}, NetworkReq: {NetworkReq}, DataDone: {DataDone}, PoC: {PoC}")
        : new BadRequestObjectResult("Please pass a value on the query string or in the request body");
}
