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

  [Route("odata/ConData/AspNetUserClaims")]
  public partial class AspNetUserClaimsController : ODataController
  {
    private VirtualLeague.Data.ConDataContext context;

    public AspNetUserClaimsController(VirtualLeague.Data.ConDataContext context)
    {
      this.context = context;
    }
    // GET /odata/ConData/AspNetUserClaims
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.ConData.AspNetUserClaim> GetAspNetUserClaims()
    {
      var items = this.context.AspNetUserClaims.AsQueryable<Models.ConData.AspNetUserClaim>();
      this.OnAspNetUserClaimsRead(ref items);

      return items;
    }

    partial void OnAspNetUserClaimsRead(ref IQueryable<Models.ConData.AspNetUserClaim> items);

    partial void OnAspNetUserClaimGet(ref SingleResult<Models.ConData.AspNetUserClaim> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/ConData/AspNetUserClaims(Id={Id})")]
    public SingleResult<AspNetUserClaim> GetAspNetUserClaim(int key)
    {
        var items = this.context.AspNetUserClaims.Where(i=>i.Id == key);
        var result = SingleResult.Create(items);

        OnAspNetUserClaimGet(ref result);

        return result;
    }
    partial void OnAspNetUserClaimDeleted(Models.ConData.AspNetUserClaim item);
    partial void OnAfterAspNetUserClaimDeleted(Models.ConData.AspNetUserClaim item);

    [HttpDelete("/odata/ConData/AspNetUserClaims(Id={Id})")]
    public IActionResult DeleteAspNetUserClaim(int key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var items = this.context.AspNetUserClaims
                .Where(i => i.Id == key)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.ConData.AspNetUserClaim>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnAspNetUserClaimDeleted(item);
            this.context.AspNetUserClaims.Remove(item);
            this.context.SaveChanges();
            this.OnAfterAspNetUserClaimDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnAspNetUserClaimUpdated(Models.ConData.AspNetUserClaim item);
    partial void OnAfterAspNetUserClaimUpdated(Models.ConData.AspNetUserClaim item);

    [HttpPut("/odata/ConData/AspNetUserClaims(Id={Id})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutAspNetUserClaim(int key, [FromBody]Models.ConData.AspNetUserClaim newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.AspNetUserClaims
                .Where(i => i.Id == key)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.ConData.AspNetUserClaim>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnAspNetUserClaimUpdated(newItem);
            this.context.AspNetUserClaims.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.AspNetUserClaims.Where(i => i.Id == key);
            Request.QueryString = Request.QueryString.Add("$expand", "AspNetUser");
            this.OnAfterAspNetUserClaimUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/ConData/AspNetUserClaims(Id={Id})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchAspNetUserClaim(int key, [FromBody]Delta<Models.ConData.AspNetUserClaim> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.AspNetUserClaims.Where(i => i.Id == key);

            items = EntityPatch.ApplyTo<Models.ConData.AspNetUserClaim>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            patch.Patch(item);

            this.OnAspNetUserClaimUpdated(item);
            this.context.AspNetUserClaims.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.AspNetUserClaims.Where(i => i.Id == key);
            Request.QueryString = Request.QueryString.Add("$expand", "AspNetUser");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnAspNetUserClaimCreated(Models.ConData.AspNetUserClaim item);
    partial void OnAfterAspNetUserClaimCreated(Models.ConData.AspNetUserClaim item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.ConData.AspNetUserClaim item)
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

            this.OnAspNetUserClaimCreated(item);
            this.context.AspNetUserClaims.Add(item);
            this.context.SaveChanges();

            var key = item.Id;

            var itemToReturn = this.context.AspNetUserClaims.Where(i => i.Id == key);

            Request.QueryString = Request.QueryString.Add("$expand", "AspNetUser");

            this.OnAfterAspNetUserClaimCreated(item);

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
