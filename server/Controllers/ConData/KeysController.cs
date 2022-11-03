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

  [Route("odata/ConData/Keys")]
  public partial class KeysController : ODataController
  {
    private VirtualLeague.Data.ConDataContext context;

    public KeysController(VirtualLeague.Data.ConDataContext context)
    {
      this.context = context;
    }
    // GET /odata/ConData/Keys
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.ConData.Key> GetKeys()
    {
      var items = this.context.Keys.AsQueryable<Models.ConData.Key>();
      this.OnKeysRead(ref items);

      return items;
    }

    partial void OnKeysRead(ref IQueryable<Models.ConData.Key> items);

    partial void OnKeyGet(ref SingleResult<Models.ConData.Key> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/ConData/Keys(Id={Id})")]
    public SingleResult<Key> GetKey(string key)
    {
        var items = this.context.Keys.Where(i=>i.Id == Uri.UnescapeDataString(key));
        var result = SingleResult.Create(items);

        OnKeyGet(ref result);

        return result;
    }
    partial void OnKeyDeleted(Models.ConData.Key item);
    partial void OnAfterKeyDeleted(Models.ConData.Key item);

    [HttpDelete("/odata/ConData/Keys(Id={Id})")]
    public IActionResult DeleteKey(string key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var items = this.context.Keys
                .Where(i => i.Id == Uri.UnescapeDataString(key))
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.ConData.Key>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnKeyDeleted(item);
            this.context.Keys.Remove(item);
            this.context.SaveChanges();
            this.OnAfterKeyDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnKeyUpdated(Models.ConData.Key item);
    partial void OnAfterKeyUpdated(Models.ConData.Key item);

    [HttpPut("/odata/ConData/Keys(Id={Id})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutKey(string key, [FromBody]Models.ConData.Key newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.Keys
                .Where(i => i.Id == Uri.UnescapeDataString(key))
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.ConData.Key>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnKeyUpdated(newItem);
            this.context.Keys.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.Keys.Where(i => i.Id == Uri.UnescapeDataString(key));
            this.OnAfterKeyUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/ConData/Keys(Id={Id})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchKey(string key, [FromBody]Delta<Models.ConData.Key> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.Keys.Where(i => i.Id == Uri.UnescapeDataString(key));

            items = EntityPatch.ApplyTo<Models.ConData.Key>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            patch.Patch(item);

            this.OnKeyUpdated(item);
            this.context.Keys.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.Keys.Where(i => i.Id == Uri.UnescapeDataString(key));
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnKeyCreated(Models.ConData.Key item);
    partial void OnAfterKeyCreated(Models.ConData.Key item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.ConData.Key item)
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

            this.OnKeyCreated(item);
            this.context.Keys.Add(item);
            this.context.SaveChanges();

        
            this.OnAfterKeyCreated(item);
            
            return Created($"odata/ConData/Keys/{item.Id}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
