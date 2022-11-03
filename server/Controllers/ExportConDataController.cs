using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VirtualLeague.Data;

namespace VirtualLeague
{
    public partial class ExportConDataController : ExportController
    {
        private readonly ConDataContext context;
        public ExportConDataController(ConDataContext context)
        {
            this.context = context;
        }

        [HttpGet("/export/ConData/aspnetroles/csv")]
        [HttpGet("/export/ConData/aspnetroles/csv(fileName='{fileName}')")]
        public FileStreamResult ExportAspNetRolesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.AspNetRoles, Request.Query), fileName);
        }

        [HttpGet("/export/ConData/aspnetroles/excel")]
        [HttpGet("/export/ConData/aspnetroles/excel(fileName='{fileName}')")]
        public FileStreamResult ExportAspNetRolesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.AspNetRoles, Request.Query), fileName);
        }
        [HttpGet("/export/ConData/aspnetroleclaims/csv")]
        [HttpGet("/export/ConData/aspnetroleclaims/csv(fileName='{fileName}')")]
        public FileStreamResult ExportAspNetRoleClaimsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.AspNetRoleClaims, Request.Query), fileName);
        }

        [HttpGet("/export/ConData/aspnetroleclaims/excel")]
        [HttpGet("/export/ConData/aspnetroleclaims/excel(fileName='{fileName}')")]
        public FileStreamResult ExportAspNetRoleClaimsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.AspNetRoleClaims, Request.Query), fileName);
        }
        [HttpGet("/export/ConData/aspnetusers/csv")]
        [HttpGet("/export/ConData/aspnetusers/csv(fileName='{fileName}')")]
        public FileStreamResult ExportAspNetUsersToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.AspNetUsers, Request.Query), fileName);
        }

        [HttpGet("/export/ConData/aspnetusers/excel")]
        [HttpGet("/export/ConData/aspnetusers/excel(fileName='{fileName}')")]
        public FileStreamResult ExportAspNetUsersToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.AspNetUsers, Request.Query), fileName);
        }
        [HttpGet("/export/ConData/aspnetuserclaims/csv")]
        [HttpGet("/export/ConData/aspnetuserclaims/csv(fileName='{fileName}')")]
        public FileStreamResult ExportAspNetUserClaimsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.AspNetUserClaims, Request.Query), fileName);
        }

        [HttpGet("/export/ConData/aspnetuserclaims/excel")]
        [HttpGet("/export/ConData/aspnetuserclaims/excel(fileName='{fileName}')")]
        public FileStreamResult ExportAspNetUserClaimsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.AspNetUserClaims, Request.Query), fileName);
        }
        [HttpGet("/export/ConData/aspnetuserlogins/csv")]
        [HttpGet("/export/ConData/aspnetuserlogins/csv(fileName='{fileName}')")]
        public FileStreamResult ExportAspNetUserLoginsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.AspNetUserLogins, Request.Query), fileName);
        }

        [HttpGet("/export/ConData/aspnetuserlogins/excel")]
        [HttpGet("/export/ConData/aspnetuserlogins/excel(fileName='{fileName}')")]
        public FileStreamResult ExportAspNetUserLoginsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.AspNetUserLogins, Request.Query), fileName);
        }
        [HttpGet("/export/ConData/aspnetuserroles/csv")]
        [HttpGet("/export/ConData/aspnetuserroles/csv(fileName='{fileName}')")]
        public FileStreamResult ExportAspNetUserRolesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.AspNetUserRoles, Request.Query), fileName);
        }

        [HttpGet("/export/ConData/aspnetuserroles/excel")]
        [HttpGet("/export/ConData/aspnetuserroles/excel(fileName='{fileName}')")]
        public FileStreamResult ExportAspNetUserRolesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.AspNetUserRoles, Request.Query), fileName);
        }
        [HttpGet("/export/ConData/aspnetusertokens/csv")]
        [HttpGet("/export/ConData/aspnetusertokens/csv(fileName='{fileName}')")]
        public FileStreamResult ExportAspNetUserTokensToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.AspNetUserTokens, Request.Query), fileName);
        }

        [HttpGet("/export/ConData/aspnetusertokens/excel")]
        [HttpGet("/export/ConData/aspnetusertokens/excel(fileName='{fileName}')")]
        public FileStreamResult ExportAspNetUserTokensToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.AspNetUserTokens, Request.Query), fileName);
        }
        [HttpGet("/export/ConData/devicecodes/csv")]
        [HttpGet("/export/ConData/devicecodes/csv(fileName='{fileName}')")]
        public FileStreamResult ExportDeviceCodesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.DeviceCodes, Request.Query), fileName);
        }

        [HttpGet("/export/ConData/devicecodes/excel")]
        [HttpGet("/export/ConData/devicecodes/excel(fileName='{fileName}')")]
        public FileStreamResult ExportDeviceCodesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.DeviceCodes, Request.Query), fileName);
        }

        [HttpGet("/export/ConData/fixturegenerators/csv(Team1='{Team1}', Team2='{Team2}', Team3='{Team3}', Team4='{Team4}', Team5='{Team5}', Team6='{Team6}', Team7='{Team7}', Team8='{Team8}', Team9='{Team9}', Team10='{Team10}', Team11='{Team11}', Team12='{Team12}', Team13='{Team13}', Team14='{Team14}', Team15='{Team15}', Team16='{Team16}', Team17='{Team17}', Team18='{Team18}', Team19='{Team19}', Team20='{Team20}', fileName='{fileName}')")]
        public FileStreamResult ExportFixtureGeneratorsToCSV(string Team1, string Team2, string Team3, string Team4, string Team5, string Team6, string Team7, string Team8, string Team9, string Team10, string Team11, string Team12, string Team13, string Team14, string Team15, string Team16, string Team17, string Team18, string Team19, string Team20, string fileName = null)
        {
            return ToCSV(ApplyQuery(context.FixtureGenerators.FromSqlRaw("EXEC [dbo].[FixtureGenerator] @Team1={0}, @Team2={1}, @Team3={2}, @Team4={3}, @Team5={4}, @Team6={5}, @Team7={6}, @Team8={7}, @Team9={8}, @Team10={9}, @Team11={10}, @Team12={11}, @Team13={12}, @Team14={13}, @Team15={14}, @Team16={15}, @Team17={16}, @Team18={17}, @Team19={18}, @Team20={19}", Team1, Team2, Team3, Team4, Team5, Team6, Team7, Team8, Team9, Team10, Team11, Team12, Team13, Team14, Team15, Team16, Team17, Team18, Team19, Team20).ToList().AsQueryable(), Request.Query), fileName);
        }

        [HttpGet("/export/ConData/fixturegenerators/excel(Team1='{Team1}', Team2='{Team2}', Team3='{Team3}', Team4='{Team4}', Team5='{Team5}', Team6='{Team6}', Team7='{Team7}', Team8='{Team8}', Team9='{Team9}', Team10='{Team10}', Team11='{Team11}', Team12='{Team12}', Team13='{Team13}', Team14='{Team14}', Team15='{Team15}', Team16='{Team16}', Team17='{Team17}', Team18='{Team18}', Team19='{Team19}', Team20='{Team20}', fileName='{fileName}')")]
        public FileStreamResult ExportFixtureGeneratorsToExcel(string Team1, string Team2, string Team3, string Team4, string Team5, string Team6, string Team7, string Team8, string Team9, string Team10, string Team11, string Team12, string Team13, string Team14, string Team15, string Team16, string Team17, string Team18, string Team19, string Team20, string fileName = null)
        {
            return ToExcel(ApplyQuery(context.FixtureGenerators.FromSqlRaw("EXEC [dbo].[FixtureGenerator] @Team1={0}, @Team2={1}, @Team3={2}, @Team4={3}, @Team5={4}, @Team6={5}, @Team7={6}, @Team8={7}, @Team9={8}, @Team10={9}, @Team11={10}, @Team12={11}, @Team13={12}, @Team14={13}, @Team15={14}, @Team16={15}, @Team17={16}, @Team18={17}, @Team19={18}, @Team20={19}", Team1, Team2, Team3, Team4, Team5, Team6, Team7, Team8, Team9, Team10, Team11, Team12, Team13, Team14, Team15, Team16, Team17, Team18, Team19, Team20).ToList().AsQueryable(), Request.Query), fileName);
        }
        [HttpGet("/export/ConData/fixturetemplates/csv")]
        [HttpGet("/export/ConData/fixturetemplates/csv(fileName='{fileName}')")]
        public FileStreamResult ExportFixtureTemplatesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.FixtureTemplates, Request.Query), fileName);
        }

        [HttpGet("/export/ConData/fixturetemplates/excel")]
        [HttpGet("/export/ConData/fixturetemplates/excel(fileName='{fileName}')")]
        public FileStreamResult ExportFixtureTemplatesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.FixtureTemplates, Request.Query), fileName);
        }
        [HttpGet("/export/ConData/keys/csv")]
        [HttpGet("/export/ConData/keys/csv(fileName='{fileName}')")]
        public FileStreamResult ExportKeysToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Keys, Request.Query), fileName);
        }

        [HttpGet("/export/ConData/keys/excel")]
        [HttpGet("/export/ConData/keys/excel(fileName='{fileName}')")]
        public FileStreamResult ExportKeysToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Keys, Request.Query), fileName);
        }
        [HttpGet("/export/ConData/leagueseasons/csv")]
        [HttpGet("/export/ConData/leagueseasons/csv(fileName='{fileName}')")]
        public FileStreamResult ExportLeagueSeasonsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.LeagueSeasons, Request.Query), fileName);
        }

        [HttpGet("/export/ConData/leagueseasons/excel")]
        [HttpGet("/export/ConData/leagueseasons/excel(fileName='{fileName}')")]
        public FileStreamResult ExportLeagueSeasonsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.LeagueSeasons, Request.Query), fileName);
        }
        [HttpGet("/export/ConData/matchdays/csv")]
        [HttpGet("/export/ConData/matchdays/csv(fileName='{fileName}')")]
        public FileStreamResult ExportMatchDaysToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.MatchDays, Request.Query), fileName);
        }

        [HttpGet("/export/ConData/matchdays/excel")]
        [HttpGet("/export/ConData/matchdays/excel(fileName='{fileName}')")]
        public FileStreamResult ExportMatchDaysToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.MatchDays, Request.Query), fileName);
        }
        [HttpGet("/export/ConData/persistedgrants/csv")]
        [HttpGet("/export/ConData/persistedgrants/csv(fileName='{fileName}')")]
        public FileStreamResult ExportPersistedGrantsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.PersistedGrants, Request.Query), fileName);
        }

        [HttpGet("/export/ConData/persistedgrants/excel")]
        [HttpGet("/export/ConData/persistedgrants/excel(fileName='{fileName}')")]
        public FileStreamResult ExportPersistedGrantsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.PersistedGrants, Request.Query), fileName);
        }
        [HttpGet("/export/ConData/seasonfixtures/csv")]
        [HttpGet("/export/ConData/seasonfixtures/csv(fileName='{fileName}')")]
        public FileStreamResult ExportSeasonFixturesToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.SeasonFixtures, Request.Query), fileName);
        }

        [HttpGet("/export/ConData/seasonfixtures/excel")]
        [HttpGet("/export/ConData/seasonfixtures/excel(fileName='{fileName}')")]
        public FileStreamResult ExportSeasonFixturesToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.SeasonFixtures, Request.Query), fileName);
        }

        [HttpGet("/export/ConData/seasonfixtureslists/csv(SeasonID={SeasonID}, fileName='{fileName}')")]
        public FileStreamResult ExportSeasonFixturesListsToCSV(int? SeasonID, string fileName = null)
        {
            return ToCSV(ApplyQuery(context.SeasonFixturesLists.FromSqlRaw("EXEC [dbo].[SeasonFixturesList] @SeasonID={0}", SeasonID).ToList().AsQueryable(), Request.Query), fileName);
        }

        [HttpGet("/export/ConData/seasonfixtureslists/excel(SeasonID={SeasonID}, fileName='{fileName}')")]
        public FileStreamResult ExportSeasonFixturesListsToExcel(int? SeasonID, string fileName = null)
        {
            return ToExcel(ApplyQuery(context.SeasonFixturesLists.FromSqlRaw("EXEC [dbo].[SeasonFixturesList] @SeasonID={0}", SeasonID).ToList().AsQueryable(), Request.Query), fileName);
        }
        [HttpGet("/export/ConData/teams/csv")]
        [HttpGet("/export/ConData/teams/csv(fileName='{fileName}')")]
        public FileStreamResult ExportTeamsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.Teams, Request.Query), fileName);
        }

        [HttpGet("/export/ConData/teams/excel")]
        [HttpGet("/export/ConData/teams/excel(fileName='{fileName}')")]
        public FileStreamResult ExportTeamsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.Teams, Request.Query), fileName);
        }
        [HttpGet("/export/ConData/virtualleagueresults/csv")]
        [HttpGet("/export/ConData/virtualleagueresults/csv(fileName='{fileName}')")]
        public FileStreamResult ExportVirtualLeagueResultsToCSV(string fileName = null)
        {
            return ToCSV(ApplyQuery(context.VirtualLeagueResults, Request.Query), fileName);
        }

        [HttpGet("/export/ConData/virtualleagueresults/excel")]
        [HttpGet("/export/ConData/virtualleagueresults/excel(fileName='{fileName}')")]
        public FileStreamResult ExportVirtualLeagueResultsToExcel(string fileName = null)
        {
            return ToExcel(ApplyQuery(context.VirtualLeagueResults, Request.Query), fileName);
        }
    }
}
