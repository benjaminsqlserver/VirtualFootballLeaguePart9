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

  [Route("odata/ConData/AspNetRoles")]
  public partial class AspNetRolesController : ODataController
  {
    private VirtualLeague.Data.ConDataContext context;

    public AspNetRolesController(VirtualLeague.Data.ConDataContext context)
    {
      this.context = context;
    }
    // GET /odata/ConData/AspNetRoles
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.ConData.AspNetRole> GetAspNetRoles()
    {
      var items = this.context.AspNetRoles.AsQueryable<Models.ConData.AspNetRole>();
      this.OnAspNetRolesRead(ref items);

      return items;
    }

    partial void OnAspNetRolesRead(ref IQueryable<Models.ConData.AspNetRole> items);

    partial void OnAspNetRoleGet(ref SingleResult<Models.ConData.AspNetRole> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/ConData/AspNetRoles(Id={Id})")]
    public SingleResult<AspNetRole> GetAspNetRole(string key)
    {
        var items = this.context.AspNetRoles.Where(i=>i.Id == Uri.UnescapeDataString(key));
        var result = SingleResult.Create(items);

        OnAspNetRoleGet(ref result);

        return result;
    }
    partial void OnAspNetRoleDeleted(Models.ConData.AspNetRole item);
    partial void OnAfterAspNetRoleDeleted(Models.ConData.AspNetRole item);

    [HttpDelete("/odata/ConData/AspNetRoles(Id={Id})")]
    public IActionResult DeleteAspNetRole(string key)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var items = this.context.AspNetRoles
                .Where(i => i.Id == Uri.UnescapeDataString(key))
                .Include(i => i.AspNetRoleClaims)
                .Include(i => i.AspNetUserRoles)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.ConData.AspNetRole>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnAspNetRoleDeleted(item);
            this.context.AspNetRoles.Remove(item);
            this.context.SaveChanges();
            this.OnAfterAspNetRoleDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnAspNetRoleUpdated(Models.ConData.AspNetRole item);
    partial void OnAfterAspNetRoleUpdated(Models.ConData.AspNetRole item);

    [HttpPut("/odata/ConData/AspNetRoles(Id={Id})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutAspNetRole(string key, [FromBody]Models.ConData.AspNetRole newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.AspNetRoles
                .Where(i => i.Id == Uri.UnescapeDataString(key))
                .Include(i => i.AspNetRoleClaims)
                .Include(i => i.AspNetUserRoles)
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.ConData.AspNetRole>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnAspNetRoleUpdated(newItem);
            this.context.AspNetRoles.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.AspNetRoles.Where(i => i.Id == Uri.UnescapeDataString(key));
            this.OnAfterAspNetRoleUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/ConData/AspNetRoles(Id={Id})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchAspNetRole(string key, [FromBody]Delta<Models.ConData.AspNetRole> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.AspNetRoles.Where(i => i.Id == Uri.UnescapeDataString(key));

            items = EntityPatch.ApplyTo<Models.ConData.AspNetRole>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            patch.Patch(item);

            this.OnAspNetRoleUpdated(item);
            this.context.AspNetRoles.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.AspNetRoles.Where(i => i.Id == Uri.UnescapeDataString(key));
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnAspNetRoleCreated(Models.ConData.AspNetRole item);
    partial void OnAfterAspNetRoleCreated(Models.ConData.AspNetRole item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.ConData.AspNetRole item)
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

            this.OnAspNetRoleCreated(item);
            this.context.AspNetRoles.Add(item);
            this.context.SaveChanges();

        
            this.OnAfterAspNetRoleCreated(item);
            
            return Created($"odata/ConData/AspNetRoles/{item.Id}", item);
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }
  }
}
