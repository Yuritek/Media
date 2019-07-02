using System.Linq;
using System.Threading.Tasks;
using Core.DAL;
using Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace MediaProject.Controllers
{
	[Route("api/mediaType")]
	[ApiController]
	public class ValuesController : ControllerBase
	{
		// GET api/values
		[HttpGet]
		public async Task<IActionResult> GetAsync()
		{
			using (var mainContext = new DP_MainContext())
			{
				using (var publishingUnit = new UnitOfWork<RefMediaType>(mainContext))
				{
					var result = await publishingUnit.Repository.Get();
					var data=result.Select(type => new
					{
						MediaType = type.MediaType, 
						LastUpdate = type.LastUpdated, 
						deleted = type.Deleted
					});
					return Ok(data);
				}
			}
		}

		// GET api/values/5
		[HttpGet("{id}")]
		public ActionResult<string> Get(int id)
		{
			return "value";
		}

		// POST api/values
		[HttpPost]
		public void Post([FromBody] string value)
		{
		}

		// PUT api/values/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/values/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
