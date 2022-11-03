using System;
using System.Net;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;




namespace VirtualLeague.Controllers.ConData
{
  using Models;
  using Data;
  using Models.ConData;

  [Route("odata/ConData/AspNetUserTokens")]
  public partial class AspNetUserTokensController : ODataController
  {
    private VirtualLeague.Data.ConDataContext context;

    public AspNetUserTokensController(VirtualLeague.Data.ConDataContext context)
    {
      this.context = context;
    }
    // GET /odata/ConData/AspNetUserTokens
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.ConData.AspNetUserToken> GetAspNetUserTokens()
    {
      var items = this.context.AspNetUserTokens.AsQueryable<Models.ConData.AspNetUserToken>();
      this.OnAspNetUserTokensRead(ref items);

      return items;
    }

    partial void OnAspNetUserTokensRead(ref IQueryable<Models.ConData.AspNetUserToken> items);

    partial void OnAspNetUserTokenGet(ref SingleResult<Models.ConData.AspNetUserToken> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/ConData/AspNetUserTokens(UserId={keyUserId},LoginProvider={keyLoginProvider},Name={keyName})")]
    public SingleResult<AspNetUserToken> GetAspNetUserToken([FromODataUri] string keyUserId,[FromODataUri] string keyLoginProvider,[FromODataUri] string keyName)
    {
        var items = this.context.AspNetUserTokens.Where(i=>i.UserId == Uri.UnescapeDataString(keyUserId) && i.LoginProvider == Uri.UnescapeDataString(keyLoginProvider) && i.Name == Uri.UnescapeDataString(keyName));
        var result = SingleResult.Create(items);

        OnAspNetUserTokenGet(ref result);

        return result;
    }
    partial void OnAspNetUserTokenDeleted(Models.ConData.AspNetUserToken item);
    partial void OnAfterAspNetUserTokenDeleted(Models.ConData.AspNetUserToken item);

    [HttpDelete("/odata/ConData/AspNetUserTokens(UserId={keyUserId},LoginProvider={keyLoginProvider},Name={keyName})")]
    public IActionResult DeleteAspNetUserToken([FromODataUri] string keyUserId,[FromODataUri] string keyLoginProvider,[FromODataUri] string keyName)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var items = this.context.AspNetUserTokens
                .Where(i => i.UserId == Uri.UnescapeDataString(keyUserId) && i.LoginProvider == Uri.UnescapeDataString(keyLoginProvider) && i.Name == Uri.UnescapeDataString(keyName))
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.ConData.AspNetUserToken>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnAspNetUserTokenDeleted(item);
            this.context.AspNetUserTokens.Remove(item);
            this.context.SaveChanges();
            this.OnAfterAspNetUserTokenDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnAspNetUserTokenUpdated(Models.ConData.AspNetUserToken item);
    partial void OnAfterAspNetUserTokenUpdated(Models.ConData.AspNetUserToken item);

    [HttpPut("/odata/ConData/AspNetUserTokens(UserId={keyUserId},LoginProvider={keyLoginProvider},Name={keyName})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutAspNetUserToken([FromODataUri] string keyUserId,[FromODataUri] string keyLoginProvider,[FromODataUri] string keyName, [FromBody]Models.ConData.AspNetUserToken newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.AspNetUserTokens
                .Where(i => i.UserId == Uri.UnescapeDataString(keyUserId) && i.LoginProvider == Uri.UnescapeDataString(keyLoginProvider) && i.Name == Uri.UnescapeDataString(keyName))
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.ConData.AspNetUserToken>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnAspNetUserTokenUpdated(newItem);
            this.context.AspNetUserTokens.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.AspNetUserTokens.Where(i => i.UserId == Uri.UnescapeDataString(keyUserId) && i.LoginProvider == Uri.UnescapeDataString(keyLoginProvider) && i.Name == Uri.UnescapeDataString(keyName));
            Request.QueryString = Request.QueryString.Add("$expand", "AspNetUser");
            this.OnAfterAspNetUserTokenUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/ConData/AspNetUserTokens(UserId={keyUserId},LoginProvider={keyLoginProvider},Name={keyName})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchAspNetUserToken([FromODataUri] string keyUserId,[FromODataUri] string keyLoginProvider,[FromODataUri] string keyName, [FromBody]Delta<Models.ConData.AspNetUserToken> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.AspNetUserTokens.Where(i => i.UserId == Uri.UnescapeDataString(keyUserId) && i.LoginProvider == Uri.UnescapeDataString(keyLoginProvider) && i.Name == Uri.UnescapeDataString(keyName));

            items = EntityPatch.ApplyTo<Models.ConData.AspNetUserToken>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            patch.Patch(item);

            this.OnAspNetUserTokenUpdated(item);
            this.context.AspNetUserTokens.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.AspNetUserTokens.Where(i => i.UserId == Uri.UnescapeDataString(keyUserId) && i.LoginProvider == Uri.UnescapeDataString(keyLoginProvider) && i.Name == Uri.UnescapeDataString(keyName));
            Request.QueryString = Request.QueryString.Add("$expand", "AspNetUser");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnAspNetUserTokenCreated(Models.ConData.AspNetUserToken item);
    partial void OnAfterAspNetUserTokenCreated(Models.ConData.AspNetUserToken item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.ConData.AspNetUserToken item)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (item == null)
            {
                return BadRequest();
            }

            this.OnAspNetUserTokenCreated(item);
            this.context.AspNetUserTokens.Add(item);
            this.context.SaveChanges();

            var keyUserId = item.UserId;
            var keyLoginProvider = item.LoginProvider;
            var keyName = item.Name;

            var itemToReturn = this.context.AspNetUserTokens.Where(i => i.UserId == Uri.UnescapeDataString(keyUserId) && i.LoginProvider == Uri.UnescapeDataString(keyLoginProvider) && i.Name == Uri.UnescapeDataString(keyName));

            Request.QueryString = Request.QueryString.Add("$expand", "AspNetUser");

            this.OnAfterAspNetUserTokenCreated(item);

            return new ObjectResult(SingleResult.Create(itemToReturn))
            {
                StatusCode = 201
            };
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
