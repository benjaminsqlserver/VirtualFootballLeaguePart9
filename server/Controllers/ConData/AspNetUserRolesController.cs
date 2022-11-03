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

  [Route("odata/ConData/AspNetUserRoles")]
  public partial class AspNetUserRolesController : ODataController
  {
    private VirtualLeague.Data.ConDataContext context;

    public AspNetUserRolesController(VirtualLeague.Data.ConDataContext context)
    {
      this.context = context;
    }
    // GET /odata/ConData/AspNetUserRoles
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet]
    public IEnumerable<Models.ConData.AspNetUserRole> GetAspNetUserRoles()
    {
      var items = this.context.AspNetUserRoles.AsQueryable<Models.ConData.AspNetUserRole>();
      this.OnAspNetUserRolesRead(ref items);

      return items;
    }

    partial void OnAspNetUserRolesRead(ref IQueryable<Models.ConData.AspNetUserRole> items);

    partial void OnAspNetUserRoleGet(ref SingleResult<Models.ConData.AspNetUserRole> item);

    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    [HttpGet("/odata/ConData/AspNetUserRoles(UserId={keyUserId},RoleId={keyRoleId})")]
    public SingleResult<AspNetUserRole> GetAspNetUserRole([FromODataUri] string keyUserId,[FromODataUri] string keyRoleId)
    {
        var items = this.context.AspNetUserRoles.Where(i=>i.UserId == Uri.UnescapeDataString(keyUserId) && i.RoleId == Uri.UnescapeDataString(keyRoleId));
        var result = SingleResult.Create(items);

        OnAspNetUserRoleGet(ref result);

        return result;
    }
    partial void OnAspNetUserRoleDeleted(Models.ConData.AspNetUserRole item);
    partial void OnAfterAspNetUserRoleDeleted(Models.ConData.AspNetUserRole item);

    [HttpDelete("/odata/ConData/AspNetUserRoles(UserId={keyUserId},RoleId={keyRoleId})")]
    public IActionResult DeleteAspNetUserRole([FromODataUri] string keyUserId,[FromODataUri] string keyRoleId)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var items = this.context.AspNetUserRoles
                .Where(i => i.UserId == Uri.UnescapeDataString(keyUserId) && i.RoleId == Uri.UnescapeDataString(keyRoleId))
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.ConData.AspNetUserRole>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnAspNetUserRoleDeleted(item);
            this.context.AspNetUserRoles.Remove(item);
            this.context.SaveChanges();
            this.OnAfterAspNetUserRoleDeleted(item);

            return new NoContentResult();
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnAspNetUserRoleUpdated(Models.ConData.AspNetUserRole item);
    partial void OnAfterAspNetUserRoleUpdated(Models.ConData.AspNetUserRole item);

    [HttpPut("/odata/ConData/AspNetUserRoles(UserId={keyUserId},RoleId={keyRoleId})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PutAspNetUserRole([FromODataUri] string keyUserId,[FromODataUri] string keyRoleId, [FromBody]Models.ConData.AspNetUserRole newItem)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.AspNetUserRoles
                .Where(i => i.UserId == Uri.UnescapeDataString(keyUserId) && i.RoleId == Uri.UnescapeDataString(keyRoleId))
                .AsQueryable();

            items = EntityPatch.ApplyTo<Models.ConData.AspNetUserRole>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            this.OnAspNetUserRoleUpdated(newItem);
            this.context.AspNetUserRoles.Update(newItem);
            this.context.SaveChanges();

            var itemToReturn = this.context.AspNetUserRoles.Where(i => i.UserId == Uri.UnescapeDataString(keyUserId) && i.RoleId == Uri.UnescapeDataString(keyRoleId));
            Request.QueryString = Request.QueryString.Add("$expand", "AspNetUser,AspNetRole");
            this.OnAfterAspNetUserRoleUpdated(newItem);
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    [HttpPatch("/odata/ConData/AspNetUserRoles(UserId={keyUserId},RoleId={keyRoleId})")]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult PatchAspNetUserRole([FromODataUri] string keyUserId,[FromODataUri] string keyRoleId, [FromBody]Delta<Models.ConData.AspNetUserRole> patch)
    {
        try
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var items = this.context.AspNetUserRoles.Where(i => i.UserId == Uri.UnescapeDataString(keyUserId) && i.RoleId == Uri.UnescapeDataString(keyRoleId));

            items = EntityPatch.ApplyTo<Models.ConData.AspNetUserRole>(Request, items);

            var item = items.FirstOrDefault();

            if (item == null)
            {
                return StatusCode((int)HttpStatusCode.PreconditionFailed);
            }

            patch.Patch(item);

            this.OnAspNetUserRoleUpdated(item);
            this.context.AspNetUserRoles.Update(item);
            this.context.SaveChanges();

            var itemToReturn = this.context.AspNetUserRoles.Where(i => i.UserId == Uri.UnescapeDataString(keyUserId) && i.RoleId == Uri.UnescapeDataString(keyRoleId));
            Request.QueryString = Request.QueryString.Add("$expand", "AspNetUser,AspNetRole");
            return new ObjectResult(SingleResult.Create(itemToReturn));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return BadRequest(ModelState);
        }
    }

    partial void OnAspNetUserRoleCreated(Models.ConData.AspNetUserRole item);
    partial void OnAfterAspNetUserRoleCreated(Models.ConData.AspNetUserRole item);

    [HttpPost]
    [EnableQuery(MaxExpansionDepth=10,MaxAnyAllExpressionDepth=10,MaxNodeCount=1000)]
    public IActionResult Post([FromBody] Models.ConData.AspNetUserRole item)
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

            this.OnAspNetUserRoleCreated(item);
            this.context.AspNetUserRoles.Add(item);
            this.context.SaveChanges();

            var keyUserId = item.UserId;
            var keyRoleId = item.RoleId;

            var itemToReturn = this.context.AspNetUserRoles.Where(i => i.UserId == Uri.UnescapeDataString(keyUserId) && i.RoleId == Uri.UnescapeDataString(keyRoleId));

            Request.QueryString = Request.QueryString.Add("$expand", "AspNetUser,AspNetRole");

            this.OnAfterAspNetUserRoleCreated(item);

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
