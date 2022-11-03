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

  [Route("odata/ConData/PersistedGrants")]
  public partial class PersistedGrantsController : ODataController
  {
    private VirtualLeague.Data.ConDataContext context;

    public PersistedGrantsController(VirtualLeague.Data.ConDataContext context)
    {
      this.context = context;
    }
    // GET /odata/ConData/PersistedGrants
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.ConData.PersistedGrant> GetPersistedGrants()
    {
      var items = this.context.PersistedGrants.AsQueryable<Models.ConData.PersistedGrant>();
      this.OnPersistedGrantsRead(ref items);

      return items;
    }

    partial void OnPersistedGrantsRead(ref IQueryable<Models.ConData.PersistedGrant> items);

    partial void OnPersistedGrantGet(ref SingleResult<Models.ConData.PersistedGrant> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/ConData/PersistedGrants(Key={Key})")]
    public SingleResult<PersistedGrant> GetPersistedGrant(string key)
    {
        var items = this.context.PersistedGrants.Where(i=>i.Key == Uri.UnescapeDataString(key));
        var result = SingleResult.Create(items);

        OnPersistedGrantGet(ref result);

        return result;
    }
    partial void OnPersistedGrantDeleted(Models.ConData.PersistedGrant item);
    partial void OnAfterPersistedGrantDeleted(Models.ConData.PersistedGrant item);

    [HttpDelete("/odata/ConData/PersistedGrants(Key={Key})")]
    public IActionResult DeletePersistedGrant(string key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var items = this.context.PersistedGrants
                .Where(i => i.Key == Uri.UnescapeDataString(key))
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.ConData.PersistedGrant>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnPersistedGrantDeleted(item);
            this.context.PersistedGrants.Remove(item);
            this.context.SaveChanges();
            this.OnAfterPersistedGrantDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnPersistedGrantUpdated(Models.ConData.PersistedGrant item);
    partial void OnAfterPersistedGrantUpdated(Models.ConData.PersistedGrant item);

    [HttpPut("/odata/ConData/PersistedGrants(Key={Key})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutPersistedGrant(string key, [FromBody]Models.ConData.PersistedGrant newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.PersistedGrants
                .Where(i => i.Key == Uri.UnescapeDataString(key))
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.ConData.PersistedGrant>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnPersistedGrantUpdated(newItem);
            this.context.PersistedGrants.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.PersistedGrants.Where(i => i.Key == Uri.UnescapeDataString(key));
            this.OnAfterPersistedGrantUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/ConData/PersistedGrants(Key={Key})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchPersistedGrant(string key, [FromBody]Delta<Models.ConData.PersistedGrant> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.PersistedGrants.Where(i => i.Key == Uri.UnescapeDataString(key));

            items = EntityPatch.ApplyTo<Models.ConData.PersistedGrant>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            patch.Patch(item);

            this.OnPersistedGrantUpdated(item);
            this.context.PersistedGrants.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.PersistedGrants.Where(i => i.Key == Uri.UnescapeDataString(key));
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnPersistedGrantCreated(Models.ConData.PersistedGrant item);
    partial void OnAfterPersistedGrantCreated(Models.ConData.PersistedGrant item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.ConData.PersistedGrant item)
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

            this.OnPersistedGrantCreated(item);
            this.context.PersistedGrants.Add(item);
            this.context.SaveChanges();

        
            this.OnAfterPersistedGrantCreated(item);
            
            return Created($"odata/ConData/PersistedGrants/{item.Key}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
